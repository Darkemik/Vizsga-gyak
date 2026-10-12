<?php
// =====================================================================
// 2. feladat – kategoriak.php
// Böngészőben kipróbálva:  http://localhost/babszem_webshop/backend/kategoriak.php
// =====================================================================

require_once "config.php";      // a kapcsolat: innentől van $pdo

// A válasz JSON lesz, UTF-8 kódolással (ékezetek!)
header("Content-Type: application/json; charset=utf-8");

// Csak GET kérést fogadunk el. Minden másra (POST, DELETE...): 405-ös hibakód.
// $_SERVER["REQUEST_METHOD"] = a kérés metódusa: "GET", "POST", "PATCH", "DELETE"...
if ($_SERVER["REQUEST_METHOD"] !== "GET") {
    http_response_code(405);                                  // a hibakód beállítása
    echo json_encode(["error" => "Method not allowed"]);     // a válasz szövege
    exit;                                                     // VÉGE, a fájl többi része nem fut le
}

// SQL lekérdezés: minden kategória, NÉV szerint rendezve
$stmt = $pdo->query("SELECT id, name FROM categories ORDER BY name");

// A sorokból tömböt építünk. Az id-t (int)-tel SZÁMMÁ alakítjuk,
// különben a JSON-ban "6" (szöveg) lenne 6 (szám) helyett.
$kategoriak = [];
foreach ($stmt->fetchAll() as $sor) {
    $kategoriak[] = [                     // [] = a tömb végére tesszük (mint a C#-ban a List.Add)
        "id" => (int)$sor["id"],
        "name" => $sor["name"]
    ];
}

// A tömb JSON-ná alakítva kiírva. Ez a válasz.
//   JSON_UNESCAPED_UNICODE: az "Ő" ne Ő legyen, hanem Ő
//   JSON_PRETTY_PRINT: szépen tördelve (böngészőben olvashatóbb)
echo json_encode($kategoriak, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
