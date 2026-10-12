<?php
// =====================================================================
// termekek.php – a termékek végpontja. EGY fájl, de a METÓDUS szerint mást csinál:
//
//   GET     termekek.php          -> az összes termék              (3. feladat)
//   GET     termekek.php?id=2     -> egy termék                    (4. feladat)
//   POST    termekek.php          -> új termék (JSON a törzsben)   (5. feladat)
//   PATCH   termekek.php?id=6     -> készlet módosítása            (6. feladat)
//   DELETE  termekek.php?id=1     -> törlés                        (7. feladat)
//   más     termekek.php          -> 405                           (8. feladat)
//
// A fájl felépítése: 1) betöltés + fejléc, 2) segédfüggvények, 3) a metódusok sorban.
// =====================================================================

require_once "config.php";      // 1. feladat: innentől van $pdo

// 8. feladat: MINDEN válasz JSON, UTF-8 kódolással
header("Content-Type: application/json; charset=utf-8");


// =====================================================================
// SEGÉDFÜGGVÉNYEK (hogy ne kelljen ugyanazt sokszor leírni)
// =====================================================================

// Válasz küldése: státuszkód + adat JSON-ban, és utána KILÉP (exit).
// Használat:  valasz(404, ["error" => "A termék nem található."]);
function valasz($statusz, $adat)
{
    http_response_code($statusz);
    echo json_encode($adat, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
    exit;
}

// 3–4. feladat: a termékek a kategóriáikkal.
// Ha $id-t is kap, csak azt az egy terméket kérdezi le.
function termekekLekerdezese($pdo, $id = null)
{
    // LEFT JOIN: a termékhez hozzákapcsoljuk a kapcsolótáblát, azon keresztül a kategóriákat.
    // LEFT = akkor is jön a termék, ha NINCS kategóriája (ilyenkor a kategória oszlopai NULL-ok).
    // Egy termék TÖBB sorban jön, ha több kategóriája van (pl. a 2-es termék 2 sorban).
    $sql = "SELECT p.id, p.name, p.description, p.price, p.stock,
                   c.id AS category_id, c.name AS category_name
            FROM products p
            LEFT JOIN product_categories pc ON pc.product_id = p.id
            LEFT JOIN categories c ON c.id = pc.category_id";
    if ($id !== null) {
        $sql .= " WHERE p.id = :id";          // .= hozzáfűzés a szöveghez (C#-ban +=)
    }
    $sql .= " ORDER BY p.id, c.name";         // azonosító szerint (a feladat kéri)

    // ELŐKÉSZÍTETT LEKÉRDEZÉS (prepared statement, a 4. feladat kéri):
    // az SQL-ben :id a helye, az értéket KÜLÖN adjuk át -> biztonságos.
    $stmt = $pdo->prepare($sql);
    if ($id !== null) {
        $stmt->bindValue(":id", $id, PDO::PARAM_INT);
    }
    $stmt->execute();

    // CSOPORTOSÍTÁS termékenként: a $termekek tömb kulcsa a termék id-ja.
    // Ha a termék már benne van, csak a kategóriáját tesszük hozzá.
    $termekek = [];
    foreach ($stmt->fetchAll() as $sor) {
        $termekId = (int)$sor["id"];

        if (!isset($termekek[$termekId])) {           // ez a termék még nincs benne -> felvesszük
            $termekek[$termekId] = [
                "id" => $termekId,
                "name" => $sor["name"],
                "description" => $sor["description"],
                "price" => (int)$sor["price"],         // (int): SZÁM legyen a JSON-ban, ne "4290"
                "stock" => (int)$sor["stock"],
                "categories" => []                     // üres tömb, ide jönnek a kategóriák
            ];
        }

        // Ha van kategória ebben a sorban (nem NULL), hozzáadjuk.
        // A kategória nélküli termék így üres tömböt kap (a feladat kéri).
        if ($sor["category_id"] !== null) {
            $termekek[$termekId]["categories"][] = [
                "id" => (int)$sor["category_id"],
                "name" => $sor["category_name"]
            ];
        }
    }

    // array_values: a kulcsokat (2, 5, 9...) eldobja -> sima lista lesz -> JSON-ban [ ... ]
    return array_values($termekek);
}

// Létezik-e ilyen azonosítójú termék? (true / false)
function termekLetezik($pdo, $id)
{
    $stmt = $pdo->prepare("SELECT COUNT(*) FROM products WHERE id = :id");
    $stmt->execute([":id" => $id]);
    return $stmt->fetchColumn() > 0;        // fetchColumn = az első oszlop értéke (a darabszám)
}

// A kérés TÖRZSÉBEN érkező JSON beolvasása (POST, PATCH).
// php://input = a nyers törzs; json_decode(..., true) = PHP tömbbé alakítja.
function keresTorzse()
{
    $adat = json_decode(file_get_contents("php://input"), true);
    return is_array($adat) ? $adat : [];    // ha nem értelmes JSON jött, üres tömb
}


// =====================================================================
// MELYIK METÓDUS? VAN-E ID?
// =====================================================================
$metodus = $_SERVER["REQUEST_METHOD"];                    // "GET", "POST", "PATCH", "DELETE"...

// ?id=6  ->  $_GET["id"] = "6".   Ha nincs megadva (vagy üres): null
$id = isset($_GET["id"]) && $_GET["id"] !== "" ? $_GET["id"] : null;


// =====================================================================
// GET – 3. feladat (lista) és 4. feladat (egy termék)
// =====================================================================
if ($metodus === "GET") {

    if ($id === null) {
        valasz(200, termekekLekerdezese($pdo));           // nincs id -> MINDEN termék (tömb)
    }

    $termek = termekekLekerdezese($pdo, (int)$id);        // van id -> csak az az egy
    if (count($termek) === 0) {
        valasz(404, ["error" => "A termék nem található."]);
    }
    valasz(200, $termek[0]);                              // OBJEKTUMKÉNT, nem tömbben: [0]
}


// =====================================================================
// POST – 5. feladat: új termék
// Törzs pl.: {"name": "Kenyai AA 250 g", "description": "...", "price": 4590, "stock": 20, "categories": [1, 5]}
// =====================================================================
if ($metodus === "POST") {
    $adat = keresTorzse();

    // Az adatok kiolvasása.  ?? = "ha nincs ilyen kulcs, akkor ez" (mint a C#-ban)
    $name = isset($adat["name"]) ? trim($adat["name"]) : "";
    $description = isset($adat["description"]) && trim($adat["description"]) !== "" ? trim($adat["description"]) : null;
    $price = $adat["price"] ?? null;
    $stock = $adat["stock"] ?? null;
    $kategoriak = $adat["categories"] ?? [];

    // ELLENŐRZÉSEK a feladat sorrendjében. Az első hibánál 400 + üzenet, és kilép.
    if ($name === "") {
        valasz(400, ["error" => "A név megadása kötelező."]);
    }
    if (!is_int($price) || $price <= 0) {                 // is_int: egész szám-e
        valasz(400, ["error" => "Az ár csak pozitív egész szám lehet."]);
    }
    if (!is_int($stock) || $stock < 0) {
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }
    if (!is_array($kategoriak)) {
        valasz(400, ["error" => "Nem létező kategória."]);
    }
    $kategoriak = array_unique($kategoriak);              // ismétlődések kiszűrése

    // Minden megadott kategória létezik-e az adatbázisban?
    $ellenorzes = $pdo->prepare("SELECT COUNT(*) FROM categories WHERE id = :id");
    foreach ($kategoriak as $kategoriaId) {
        if (!is_int($kategoriaId)) {
            valasz(400, ["error" => "Nem létező kategória."]);
        }
        $ellenorzes->execute([":id" => $kategoriaId]);
        if ($ellenorzes->fetchColumn() == 0) {
            valasz(400, ["error" => "Nem létező kategória."]);
        }
    }

    // MENTÉS TRANZAKCIÓBAN (a feladat kéri): vagy MINDEN sikerül, vagy SEMMI nem mentődik.
    try {
        $pdo->beginTransaction();

        // 1) a termék
        $stmt = $pdo->prepare("INSERT INTO products (name, description, price, stock)
                               VALUES (:name, :description, :price, :stock)");
        $stmt->execute([
            ":name" => $name,
            ":description" => $description,
            ":price" => $price,
            ":stock" => $stock
        ]);
        $ujId = (int)$pdo->lastInsertId();                // az új termék id-ja (AUTO_INCREMENT)

        // 2) a kategóriakapcsolatok a kapcsolótáblába
        $kapcsolat = $pdo->prepare("INSERT INTO product_categories (product_id, category_id)
                                    VALUES (:product_id, :category_id)");
        foreach ($kategoriak as $kategoriaId) {
            $kapcsolat->execute([":product_id" => $ujId, ":category_id" => $kategoriaId]);
        }

        $pdo->commit();                                   // minden rendben -> véglegesítés
    } catch (PDOException $e) {
        $pdo->rollBack();                                 // hiba -> minden visszavonva
        valasz(500, ["error" => "A termék mentése sikertelen."]);
    }

    valasz(201, ["message" => "Termék sikeresen hozzáadva.", "id" => $ujId]);   // 201 = Created
}


// =====================================================================
// PATCH – 6. feladat: készlet módosítása.  termekek.php?id=6, törzs: {"stock": 15}
// =====================================================================
if ($metodus === "PATCH") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);          // 8. feladat
    }
    $id = (int)$id;

    $adat = keresTorzse();
    $stock = $adat["stock"] ?? null;
    if (!is_int($stock) || $stock < 0) {                         // hiányzó vagy negatív
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }
    if (!termekLetezik($pdo, $id)) {
        valasz(404, ["error" => "A termék nem található."]);
    }

    $stmt = $pdo->prepare("UPDATE products SET stock = :stock WHERE id = :id");
    $stmt->execute([":stock" => $stock, ":id" => $id]);

    valasz(200, ["message" => "Készlet frissítve.", "id" => $id, "stock" => $stock]);
}


// =====================================================================
// DELETE – 7. feladat: törlés.  termekek.php?id=1
// =====================================================================
if ($metodus === "DELETE") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);          // 8. feladat
    }
    $id = (int)$id;
    if (!termekLetezik($pdo, $id)) {
        valasz(404, ["error" => "A termék nem található."]);
    }

    // ELŐBB a kapcsolótábla sorai (a feladat kéri), UTÁNA a termék.
    // Fordítva hibát dobna, mert a kapcsolótábla még hivatkozik a termékre (idegen kulcs).
    $pdo->beginTransaction();
    $stmt = $pdo->prepare("DELETE FROM product_categories WHERE product_id = :id");
    $stmt->execute([":id" => $id]);
    $stmt = $pdo->prepare("DELETE FROM products WHERE id = :id");
    $stmt->execute([":id" => $id]);
    $pdo->commit();

    valasz(200, ["message" => "Termék törölve."]);
}


// =====================================================================
// Minden más metódus (pl. PUT) – 8. feladat: 405
// Ide csak akkor jut el a program, ha egyik fenti if sem futott le (mindegyik exit-tel ér véget).
// =====================================================================
valasz(405, ["error" => "Method not allowed"]);
