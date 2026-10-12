# Alapok kezdőknek – mi az a PHP, és hogyan működik?

10 perc olvasás. Ha ezt megérted, a többi már csak másolás és átírás.

## 1. Mi a PHP?

A weboldal (HTML + JS) a **böngészőben** fut, és **nem fér hozzá** közvetlenül az adatbázishoz. Kell egy program a **szerveren**, ami:

1. megkapja a kérést (pl. „add ide a 2-es terméket”),
2. lekérdezi az adatbázist (**SQL**),
3. visszaküldi az eredményt **JSON**-ban.

Ez a program a **backend**. A vizsgán **PHP** nyelven kell megírni. A frontend (a weboldal) általában **kész**, és pontosan megmondja, milyen fájlneveket hív.

```
 Böngésző: a kész weboldal (index.html + script.js)
     │
     │  fetch("../backend/termekek.php?id=2")       ← KÉRÉS: cím + metódus (GET/POST/PATCH/DELETE) + törzs
     ▼
 Apache (a XAMPP webszervere)  ──►  lefuttatja a termekek.php-t
                                        │
                                        │  SELECT ... FROM products WHERE id = 2
                                        ▼
                                    MySQL adatbázis (babszem_webshop)
                                        │
                                        │  a sorok
                                        ▼
 Böngésző  ◄──  JSON + státuszkód  ◄──  termekek.php:  echo json_encode(...)
               {"id": 2, "name": "Etióp...", ...}   200
```

## 2. A XAMPP: ez futtat mindent

A XAMPP egy csomag, ami a saját gépeden elindít egy webszervert és egy adatbázist.

| Rész | Mi ez | Hol látod |
|---|---|---|
| **XAMPP Control Panel** | itt indítod: **Apache → Start**, **MySQL → Start** (zöld lesz) | Start menü: XAMPP Control Panel |
| **Apache** | webszerver: lefuttatja a `.php` fájlokat | |
| **MySQL** (valójában MariaDB) | az adatbázis | |
| **phpMyAdmin** | weboldal az adatbázis kezeléséhez (importálás, táblák megnézése) | http://localhost/phpmyadmin |
| **htdocs** mappa | ami ide kerül, az elérhető a böngészőből | `C:\xampp\htdocs` |

**Fájl ↔ cím:**

```
C:\xampp\htdocs\babszem_webshop\backend\termekek.php
  =  http://localhost/babszem_webshop/backend/termekek.php
```

⚠️ A PHP-t **mindig a http://localhost/... címen** nyisd meg, ne dupla kattintással! Dupla kattintásra a böngésző csak a kódot mutatja, mert nem fut le.

## 3. A metódusok és a státuszkódok

**Metódus** = mit akar a kérés:

| Metódus | Jelentés | Példa |
|---|---|---|
| **GET** | lekérdezés | `termekek.php`, `termekek.php?id=2` |
| **POST** | új elem létrehozása (az adat a **törzsben**, JSON) | `{"name": "Kenyai AA", "price": 4590, ...}` |
| **PATCH** / **PUT** | módosítás | `termekek.php?id=6` + `{"stock": 15}` |
| **DELETE** | törlés | `termekek.php?id=1` |

**Státuszkód** = hogyan sikerült:

| Kód | Jelentés | Mikor adod vissza |
|---|---|---|
| **200** | OK | sikeres lekérdezés / módosítás / törlés |
| **201** | Created | sikeres létrehozás (POST) |
| **400** | Bad Request | rossz bemenet (üres név, negatív ár, hiányzó id) |
| **404** | Not Found | nincs ilyen elem |
| **405** | Method Not Allowed | olyan metódus, amit nem kezelünk (pl. PUT) |
| **409** | Conflict | ütközés (pl. nem törölhető, mert hivatkoznak rá) |
| **500** | szerverhiba | elszállt a mentés |

## 4. PHP a C# szemével

A PHP nagyon hasonlít a C#-ra. A különbségek:

| | C# | PHP |
|---|---|---|
| a fájl eleje | – | `<?php` (kötelező, az első sorban!) |
| változó | `string nev = "Anna";` | `$nev = "Anna";` (minden változó előtt `$`, típus nincs) |
| szöveg összefűzése | `"a" + "b"` | `"a" . "b"` (pont!) |
| érték a szövegben | `$"Szia {nev}"` | `"Szia $nev"` (idézőjelben magától behelyettesíti) |
| lista | `var t = new List<int>(); t.Add(5);` | `$t = []; $t[] = 5;` |
| „objektum” / szótár | `new { id = 1, name = "X" }` | `["id" => 1, "name" => "X"]` |
| elem elérése | `t["name"]` | `$t["name"]` |
| hossz | `t.Count` | `count($t)` |
| van-e kulcs | `d.ContainsKey("id")` | `isset($t["id"])` |
| ha nincs, akkor | `x ?? 0` | `$x ?? 0` (ugyanaz) |
| egyenlő-e | `==` | `===` (szigorú, ezt használd) / `!==` |
| ciklus | `foreach (var e in lista)` | `foreach ($lista as $e)` |
| függvény | `int Osszeg(int a, int b) { ... }` | `function osszeg($a, $b) { ... }` |
| számmá alakítás | `(int)x`, `int.Parse(s)` | `(int)$x` |
| egész szám-e | – | `is_int($x)` |
| kiírás | `Console.Write(...)` | `echo ...;` |
| JSON-ná alakítás | `JsonSerializer.Serialize(t)` | `json_encode($t)` |
| JSON-ból | `JsonSerializer.Deserialize(...)` | `json_decode($szoveg, true)` |
| program vége | – | `exit;` |

## 5. Egy teljes, működő PHP végpont (10 sor)

```php
<?php
require_once "config.php";                                   // kapcsolat az adatbázishoz ($pdo)
header("Content-Type: application/json; charset=utf-8");     // a válasz JSON

$stmt = $pdo->query("SELECT id, name FROM categories ORDER BY name");   // SQL
$eredmeny = [];
foreach ($stmt->fetchAll() as $sor) {
    $eredmeny[] = ["id" => (int)$sor["id"], "name" => $sor["name"]];
}
echo json_encode($eredmeny, JSON_UNESCAPED_UNICODE);         // KIÍRJUK = ez a válasz
```

Böngészőben (http://localhost/.../kategoriak.php):

```json
[{"id":6,"name":"Ajándékötlet"},{"id":5,"name":"Bio"}, ...]
```

**Ennyi a lényeg.** A többi feladat ennek a változata: más SQL, `?id=` paraméter, hibakódok, POST-nál beolvasott törzs.

## 6. Kipróbálás

| Mit | Hogyan |
|---|---|
| GET | beírod a címet a böngészőbe: `http://localhost/babszem_webshop/backend/termekek.php?id=2` |
| POST / PATCH / DELETE | a **kész frontenden** (gombok, űrlap), vagy a [teszt.html](0_GYORSINDITO/konyvtar/teszt.html)-lel, vagy VS Code **Thunder Client** / Postman |
| hiba keresése | a böngészőben a válasz szövegében ott a PHP-hibaüzenet (sor számával); frontendnél F12 → **Network** fül → a kérés → **Response** |

**Tovább:** [README.md](README.md) (keresőtábla) · [Babszem lépésről lépésre](2_GYAKORLO_FELADATOK/01_Babszem/LEPESROL_LEPESRE.md)
