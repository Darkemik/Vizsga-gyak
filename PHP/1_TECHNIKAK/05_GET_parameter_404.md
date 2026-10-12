# 05 – GET paraméterek (?id=, szűrők), prepared statement, 404

**Mikor kell?** „termekek.php?id=N: egyetlen termék … objektumként. Ha nincs ilyen: 404 … előkészített lekérdezéssel”, „elhagyható paraméter: categoryId esetén csak …, search esetén …”

## A paraméter kiolvasása

```php
// termekek.php?id=6   ->   $_GET["id"] = "6"   (szöveg!)
$id = isset($_GET["id"]) && $_GET["id"] !== "" ? (int)$_GET["id"] : null;
```

## Egy elem + 404

```php
if ($id !== null) {
    $stmt = $pdo->prepare("SELECT id, name, price FROM products WHERE id = :id");
    $stmt->execute([":id" => $id]);
    $sor = $stmt->fetch();                     // EGY sor, vagy false, ha nincs

    if ($sor === false) {
        http_response_code(404);
        echo json_encode(["error" => "A termék nem található."], JSON_UNESCAPED_UNICODE);
        exit;
    }

    echo json_encode([
        "id" => (int)$sor["id"],
        "name" => $sor["name"],
        "price" => (int)$sor["price"]
    ], JSON_UNESCAPED_UNICODE);                // OBJEKTUM, nem tömb!
    exit;
}
// ... ide jön a lista (ha nincs id)
```

## Prepared statement = előkészített lekérdezés

```php
$stmt = $pdo->prepare("SELECT ... WHERE id = :id");   // 1. az SQL, :id = HELYŐRZŐ
$stmt->execute([":id" => $id]);                        // 2. az érték KÜLÖN
```

> **Soha** ne fűzd bele az értéket az SQL-be (`"... WHERE id = " . $_GET["id"]`): az SQL-injekció, és a feladat kifejezetten a prepared statementet pontozza.

| Módszer | Mikor |
|---|---|
| `$pdo->query("SELECT ...")` | nincs paraméter |
| `$pdo->prepare(...)` + `execute([...])` | van paraméter (id, szűrő, POST adatai) |
| `$stmt->fetchAll()` | több sor (lista) |
| `$stmt->fetch()` | egy sor (vagy `false`) |
| `$stmt->fetchColumn()` | egyetlen érték (pl. `COUNT(*)`) |

## Elhagyható szűrők

```php
$sql = "SELECT p.id, p.name, c.name AS categoryName
        FROM products p JOIN categories c ON c.id = p.category_id
        WHERE 1 = 1";                         // trükk: utána minden szűrő " AND ..."
$parameterek = [];

if (isset($_GET["categoryId"]) && $_GET["categoryId"] !== "") {
    $sql .= " AND p.category_id = :kat";
    $parameterek[":kat"] = (int)$_GET["categoryId"];
}
if (isset($_GET["search"]) && $_GET["search"] !== "") {
    $sql .= " AND p.name LIKE :keres";          // LIKE + %...% = "tartalmazza"
    $parameterek[":keres"] = "%" . $_GET["search"] . "%";
}
$sql .= " ORDER BY p.name";

$stmt = $pdo->prepare($sql);
$stmt->execute($parameterek);
$sorok = $stmt->fetchAll();
```

> A `_ci` végű kódolásnál (pl. `utf8mb4_hungarian_ci`) a `LIKE` alapból **nem** kis/nagybetű-érzékeny: „Kis- és nagybetűtől függetlenül” → kész.

**Élesben:** [gyorsindító konyvek.php, [C] és [D]](../0_GYORSINDITO/konyvtar/konyvek.php), [Babszem termekek.php](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/termekek.php)
