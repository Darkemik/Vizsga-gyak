<?php
// =====================================================================
// 1. feladat – config.php: KAPCSOLAT AZ ADATBÁZISHOZ (PDO)
//
// Ezt a fájlt a többi PHP fájl az elején betölti:  require_once "config.php";
// Utána a $pdo változón keresztül tudnak SQL-t futtatni.
//
// XAMPP alapbeállítás: felhasználó = root, jelszó = üres.
// Vizsgán CSAK az adatbázis nevét kell átírni ($dbname)!
// =====================================================================

$host = "localhost";            // a gép, amin az adatbázis fut (XAMPP: a saját géped)
$dbname = "babszem_webshop";    // az adatbázis neve: ez jön létre az .sql importálásakor
$user = "root";
$password = "";

$pdo = new PDO(
    "mysql:host=$host;dbname=$dbname;charset=utf8mb4",   // utf8mb4 = az ékezetek miatt (a feladat kéri)
    $user,
    $password,
    [
        // hiba esetén KIVÉTELT dobjon (a feladat kéri), ne csendben menjen tovább
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,
        // a lekérdezés sorai így jönnek: $sor["name"] (oszlopnév szerint)
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC
    ]
);
