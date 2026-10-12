<?php
// =====================================================================
// [A] KAPCSOLAT – config.php
// Vizsgán: CSAK a $dbname-et írd át a feladatban megadott adatbázis nevére!
// =====================================================================
$host = "localhost";
$dbname = "konyvtar";           // <-- ITT az adatbázis neve
$user = "root";                 // XAMPP: root
$password = "";                 // XAMPP: üres jelszó

$pdo = new PDO(
    "mysql:host=$host;dbname=$dbname;charset=utf8mb4",
    $user,
    $password,
    [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION,          // hiba esetén kivétel
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC      // $sor["oszlopnev"]
    ]
);
