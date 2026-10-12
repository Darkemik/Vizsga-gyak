# 04 – Lekérdezés → JSON válasz (a legegyszerűbb végpont)

**Mikor kell?** „GET kérésre adja vissza az összes …-t (id, name) név szerint rendezve. Más metódusra 405 és {"error": "Method not allowed"}.”

## A teljes fájl (pl. kategoriak.php)

```php
<?php
require_once "config.php";
header("Content-Type: application/json; charset=utf-8");      // 1. a válasz JSON lesz

// 2. csak GET-et fogadunk el
if ($_SERVER["REQUEST_METHOD"] !== "GET") {
    http_response_code(405);
    echo json_encode(["error" => "Method not allowed"]);
    exit;
}

// 3. SQL lekérdezés
$stmt = $pdo->query("SELECT id, name FROM categories ORDER BY name");

// 4. tömb építése, számok SZÁMMÁ alakítva
$eredmeny = [];
foreach ($stmt->fetchAll() as $sor) {
    $eredmeny[] = [
        "id" => (int)$sor["id"],
        "name" => $sor["name"]
    ];
}

// 5. kiírás
echo json_encode($eredmeny, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
```

## Részenként

| Sor | Mit csinál |
|---|---|
| `header("Content-Type: application/json; charset=utf-8")` | megmondja a böngészőnek, hogy JSON jön. **Minden kiírás ELŐTT!** |
| `$pdo->query("SELECT ...")` | lefuttatja az SQL-t (paraméter nélküli lekérdezéshez jó) |
| `$stmt->fetchAll()` | az összes sor, tömbként |
| `(int)$sor["id"]` | **szám** legyen a JSON-ban: `6` és nem `"6"` (a feladat gyakran kéri) |
| `json_encode(..., JSON_UNESCAPED_UNICODE)` | JSON szöveggé alakít, az ékezetek olvashatók maradnak |
| `JSON_PRETTY_PRINT` | szépen tördel (nem kötelező) |

## A JSON mezőnevei a FELADAT szerint!

A feladat mintaválasza mondja meg a kulcsokat (`"id"`, `"name"`, `"productCount"`…). Ha az adatbázis oszlopa más nevű, a tömbben nevezd át:

```php
"categoryName" => $sor["name"]
```

## Válasz-segédfüggvény (ha sok helyen kell válaszolni)

```php
function valasz($statusz, $adat)
{
    http_response_code($statusz);
    echo json_encode($adat, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
    exit;
}

valasz(200, $eredmeny);
valasz(405, ["error" => "Method not allowed"]);
```

## Tört szám (DECIMAL oszlop)

A DECIMAL szövegként jön (`"950.00"`) → `(float)$sor["unitPrice"]`.

**Élesben:** [Babszem kategoriak.php](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/kategoriak.php), [gyorsindító szerzok.php](../0_GYORSINDITO/konyvtar/szerzok.php)
