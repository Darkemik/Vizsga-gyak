# 07 – POST (új), PATCH (módosítás), DELETE (törlés)

**Mikor kell?** „új termék felvétele a kérés törzsében érkező JSON alapján … ellenőrzések … 400 … siker esetén 201”, „készletének módosítása”, „törlése … nem létező: 404”

## A váz: metódus szerint elágazás

```php
$metodus = $_SERVER["REQUEST_METHOD"];
$id = isset($_GET["id"]) && $_GET["id"] !== "" ? (int)$_GET["id"] : null;

if ($metodus === "GET")    { ... }
if ($metodus === "POST")   { ... }
if ($metodus === "PATCH")  { ... }
if ($metodus === "DELETE") { ... }
valasz(405, ["error" => "Method not allowed"]);    // ha egyik sem futott le
```

> Minden ág a végén a `valasz(...)`-szal **kilép** (`exit`), ezért nem fut tovább a következő `if`-be.

## A törzs (JSON) beolvasása

```php
$adat = json_decode(file_get_contents("php://input"), true);   // true = tömb legyen
if (!is_array($adat)) { $adat = []; }

$name  = isset($adat["name"]) ? trim($adat["name"]) : "";
$price = $adat["price"] ?? null;
```

## POST: ellenőrzés → INSERT → 201

```php
if ($metodus === "POST") {
    $adat = keresTorzse();
    $name = isset($adat["name"]) ? trim($adat["name"]) : "";
    $price = $adat["price"] ?? null;
    $stock = $adat["stock"] ?? null;

    // a feladatban felsorolt SORRENDBEN, az első hibánál kilép
    if ($name === "") {
        valasz(400, ["error" => "A név megadása kötelező."]);
    }
    if (!is_int($price) || $price <= 0) {
        valasz(400, ["error" => "Az ár csak pozitív egész szám lehet."]);
    }
    if (!is_int($stock) || $stock < 0) {
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }

    $stmt = $pdo->prepare("INSERT INTO products (name, price, stock) VALUES (:name, :price, :stock)");
    $stmt->execute([":name" => $name, ":price" => $price, ":stock" => $stock]);
    $ujId = (int)$pdo->lastInsertId();          // az új sor id-ja

    valasz(201, ["message" => "Termék sikeresen hozzáadva.", "id" => $ujId]);
}
```

**„Nem létező kategória”** ellenőrzése:

```php
$ell = $pdo->prepare("SELECT COUNT(*) FROM categories WHERE id = :id");
$ell->execute([":id" => $kategoriaId]);
if ($ell->fetchColumn() == 0) {
    valasz(400, ["error" => "Nem létező kategória."]);
}
```

## Tranzakció: „a mentés tranzakcióban történjen”

Ha több tábla is változik (termék + kapcsolótábla), vagy mind sikerül, vagy egyik sem:

```php
try {
    $pdo->beginTransaction();
    // ... INSERT products ...
    // ... INSERT product_categories (foreach) ...
    $pdo->commit();                              // véglegesítés
} catch (PDOException $e) {
    $pdo->rollBack();                            // visszavonás
    valasz(500, ["error" => "A mentés sikertelen."]);
}
```

## PATCH: módosítás

```php
if ($metodus === "PATCH") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);
    }
    $adat = keresTorzse();
    $stock = $adat["stock"] ?? null;
    if (!is_int($stock) || $stock < 0) {
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }
    $ell = $pdo->prepare("SELECT COUNT(*) FROM products WHERE id = :id");
    $ell->execute([":id" => $id]);
    if ($ell->fetchColumn() == 0) {
        valasz(404, ["error" => "A termék nem található."]);
    }

    $stmt = $pdo->prepare("UPDATE products SET stock = :stock WHERE id = :id");
    $stmt->execute([":stock" => $stock, ":id" => $id]);
    valasz(200, ["message" => "Készlet frissítve.", "id" => $id, "stock" => $stock]);
}
```

## DELETE: törlés

```php
if ($metodus === "DELETE") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);
    }
    // ha van kapcsolótábla: ELŐBB onnan! (különben idegenkulcs-hiba)
    $pdo->prepare("DELETE FROM product_categories WHERE product_id = :id")->execute([":id" => $id]);

    $stmt = $pdo->prepare("DELETE FROM products WHERE id = :id");
    $stmt->execute([":id" => $id]);
    if ($stmt->rowCount() === 0) {               // 0 sor törlődött = nem létezett
        valasz(404, ["error" => "A termék nem található."]);
    }
    valasz(200, ["message" => "Termék törölve."]);
}
```

> **409 Conflict** („nem törölhető, mert már szerepel rendelésben”): előtte `SELECT COUNT(*) FROM order_items WHERE product_id = :id`, és ha > 0 → `valasz(409, [...])`.

## Ellenőrző függvények

| Függvény | Mire |
|---|---|
| `trim($s) === ""` | üres-e a szöveg |
| `is_int($x)` | egész szám-e (a `"5"` szöveg NEM az!) |
| `is_numeric($x)` | szám-e (szöveg is lehet: `"5"`) |
| `is_array($x)` | tömb-e |
| `isset($adat["kulcs"])` | megérkezett-e a mező |

**Élesben:** [Babszem termekek.php](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/termekek.php), [gyorsindító konyvek.php [E]–[G]](../0_GYORSINDITO/konyvtar/konyvek.php)
