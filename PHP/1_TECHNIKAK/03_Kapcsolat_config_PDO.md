# 03 – Kapcsolat az adatbázishoz: config.php (PDO)

**Mikor kell?** Mindig. „config.php: hozzon létre PDO kapcsolatot a … adatbázishoz utf8mb4 karakterkódolással úgy, hogy hiba esetén kivételt dobjon! A többi fájl ezt töltse be (require_once).”

## config.php (másold, és csak a `$dbname`-et írd át!)

```php
<?php
$host = "localhost";
$dbname = "babszem_webshop";     // <-- a feladat adatbázisának neve (phpMyAdminban bal oldalt látod)
$user = "root";                  // XAMPP alapból
$password = "";                  // XAMPP alapból: üres

$pdo = new PDO(
    "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
    $user,
    $password,
    [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,         // hiba -> kivétel
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC     // $sor["oszlop"]
    ]
);
```

## Betöltés a többi fájlban (az első sorok)

```php
<?php
require_once "config.php";       // innentől van $pdo
```

> A `require_once` a fájlhoz képest keres: a `config.php` ugyanabban a mappában legyen (pl. mindkettő a `backend`-ben).

## Kipróbálás

Nyisd meg: `http://localhost/<projekt>/backend/config.php`. Ha **üres fehér oldal** jön: a kapcsolat jó. Ha hibaüzenet:

| Hibaüzenet | Ok | Megoldás |
|---|---|---|
| `Access denied for user 'root'` | rossz jelszó | XAMPP-ban üres: `$password = "";` (ha a vizsgán mást adnak meg, azt írd) |
| `Unknown database 'xyz'` | nincs ilyen adatbázis | importáltad? jó a név? (phpMyAdmin bal oldalt) |
| `Connection refused` / `No such file or directory` | nem fut a MySQL | XAMPP Control Panel → MySQL → Start |
| `could not find driver` | ritka, a PHP-ban ki van kapcsolva a pdo_mysql | szólj a felügyelőnek |

## Ha mysqli-t kér a feladat (nem PDO-t)

```php
$conn = new mysqli("localhost", "root", "", "babszem_webshop");
$conn->set_charset("utf8mb4");
$eredmeny = $conn->query("SELECT id, name FROM categories");
$sorok = $eredmeny->fetch_all(MYSQLI_ASSOC);
```

**Élesben:** [Babszem config.php](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/config.php)
