# 02 – PHP alapok (a vizsgához kellő minimum)

## A fájl

```php
<?php
// az első sor MINDIG <?php, és ELŐTTE nem lehet semmi (szóköz, üres sor sem!)
// a végére NEM kell ?>
```

## Változók, szövegek, számok

```php
$nev = "Anna";                       // minden változó előtt $
$ar = 4590;
$szoveg = "Szia " . $nev;            // összefűzés: PONT
$szoveg2 = "Szia $nev";              // idézőjelben a $nev magától behelyettesítődik
$szam = (int)"42";                   // számmá alakítás
$egesz = is_int($ar);                // egész szám-e? true / false
$tisztitott = trim("  Kávé  ");      // szóközök le a széléről: "Kávé"
```

## Tömbök (ez a lényeg: ebből lesz a JSON)

```php
// "lista" (JSON-ban: [ ... ])
$szamok = [1, 5, 9];
$szamok[] = 12;                      // hozzáadás a végére (mint List.Add)
echo count($szamok);                 // 4

// "objektum" / kulcs-érték (JSON-ban: { ... })
$termek = [
    "id" => 2,
    "name" => "Etióp Yirgacheffe",
    "categories" => []               // benne egy üres lista
];
echo $termek["name"];
$termek["categories"][] = ["id" => 1, "name" => "Szemes kávé"];   // lista az objektumban

// lista objektumokból (JSON-ban: [ {...}, {...} ])
$lista = [];
$lista[] = ["id" => 1, "name" => "A"];
$lista[] = ["id" => 2, "name" => "B"];
```

```php
isset($termek["id"])                 // létezik-e a kulcs (és nem null)
$termek["price"] ?? 0                // ha nincs, akkor 0
```

## Feltételek, ciklusok

```php
if ($ar <= 0) {
    // ...
} elseif ($ar > 10000) {             // elseif egybe!
    // ...
} else {
    // ...
}

foreach ($lista as $elem) {          // C#: foreach (var elem in lista)
    echo $elem["name"];
}

if ($nev === "Anna" && $ar !== 0) {  // === és !== : szigorú összehasonlítás -> ezt használd
    // && || !  : ÉS, VAGY, NEM (mint a C#-ban)
}
```

## Függvény

```php
function valasz($statusz, $adat)
{
    http_response_code($statusz);
    echo json_encode($adat, JSON_UNESCAPED_UNICODE);
    exit;                             // a program itt VÉGET ÉR
}

valasz(404, ["error" => "A termék nem található."]);
```

> ⚠️ A függvényen belül **nem látszanak** a kinti változók (pl. a `$pdo`)! Paraméterként add át: `function lekerdez($pdo, $id) { ... }`.

## Amit a webkérésből kapsz

```php
$_SERVER["REQUEST_METHOD"]           // "GET", "POST", "PATCH", "DELETE"...
$_GET["id"]                          // termekek.php?id=6  ->  "6"  (SZÖVEG!)
file_get_contents("php://input")     // a kérés törzse (POST/PATCH JSON-ja), nyers szöveg
```

## Kiírás = válasz

```php
header("Content-Type: application/json; charset=utf-8");   // ELŐBB a fejléc
http_response_code(201);                                    // státuszkód (alapból 200)
echo json_encode($adat, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
```

**Élesben:** [Babszem termekek.php](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/termekek.php)
