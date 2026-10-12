<?php
// =====================================================================
// [C] A LEGEGYSZERŰBB VÉGPONT: egy tábla összes sora JSON-ban, csak GET.
// Ez a minta a "kategoriak.php"-szerű feladatokhoz (1-2 pont, 2 perc).
// Kipróbálás: http://localhost/konyvtar/szerzok.php
// =====================================================================
require_once "config.php";
header("Content-Type: application/json; charset=utf-8");

// [H] csak GET; más metódusra 405
if ($_SERVER["REQUEST_METHOD"] !== "GET") {
    http_response_code(405);
    echo json_encode(["error" => "Method not allowed"]);
    exit;
}

// SQL: mit (oszlopok), honnan (tábla), milyen sorrendben
$stmt = $pdo->query("SELECT id, nev FROM szerzok ORDER BY nev");

$eredmeny = [];
foreach ($stmt->fetchAll() as $sor) {
    $eredmeny[] = [
        "id" => (int)$sor["id"],        // (int): szám legyen, ne "1"
        "nev" => $sor["nev"]
    ];
}

echo json_encode($eredmeny, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
