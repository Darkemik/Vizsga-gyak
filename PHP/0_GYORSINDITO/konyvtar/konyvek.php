<?php
// =====================================================================
// PHP GYORSINDÍTÓ – egy "teljes" végpont minden metódussal.
// Minden blokk fölött: HA A FELADAT EZT KÉRI.
// Vizsgán: másold, és írd át a TÁBLA- és OSZLOPNEVEKET, meg az ÜZENETEKET a feladat szerint.
//
//   GET     konyvek.php                    -> lista                     [C]
//   GET     konyvek.php?szerzo_id=2        -> szűrt lista               [C]
//   GET     konyvek.php?kereses=ember      -> keresés a címben          [C]
//   GET     konyvek.php?id=3               -> egy elem (404, ha nincs)  [D]
//   POST    konyvek.php   + JSON törzs     -> új elem (201)             [E]
//   PATCH   konyvek.php?id=3 + JSON törzs  -> módosítás                 [F]
//   DELETE  konyvek.php?id=3               -> törlés                    [G]
//   más                                    -> 405                       [H]
// =====================================================================

// ---------------------------------------------------------------------
// [A] BETÖLTÉS + FEJLÉC + SEGÉDFÜGGVÉNYEK (ezt mindig másold!)
// ---------------------------------------------------------------------
require_once "config.php";
header("Content-Type: application/json; charset=utf-8");

// Válasz: státuszkód + JSON, és KILÉP
function valasz($statusz, $adat)
{
    http_response_code($statusz);
    echo json_encode($adat, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
    exit;
}

// A kérés törzsében érkező JSON -> PHP tömb  (POST, PATCH, PUT)
function keresTorzse()
{
    $adat = json_decode(file_get_contents("php://input"), true);
    return is_array($adat) ? $adat : [];
}

// Egy adatbázis-sorból a válasz-objektum. ITT alakítsd SZÁMMÁ a számokat!
function konyvAlakitas($sor)
{
    return [
        "id" => (int)$sor["id"],
        "cim" => $sor["cim"],
        "szerzo_id" => (int)$sor["szerzo_id"],
        "szerzo" => $sor["szerzo"],             // a JOIN-ból jön (lásd lent)
        "ev" => (int)$sor["ev"],
        "ar" => (int)$sor["ar"],
        "keszlet" => (int)$sor["keszlet"]
    ];
}

// A közös SELECT eleje: a könyv + a szerző neve (JOIN)
$alapSql = "SELECT k.id, k.cim, k.szerzo_id, sz.nev AS szerzo, k.ev, k.ar, k.keszlet
            FROM konyvek k
            JOIN szerzok sz ON sz.id = k.szerzo_id";

// ---------------------------------------------------------------------
// [B] METÓDUS ÉS ID
// ---------------------------------------------------------------------
$metodus = $_SERVER["REQUEST_METHOD"];
$id = isset($_GET["id"]) && $_GET["id"] !== "" ? (int)$_GET["id"] : null;


if ($metodus === "GET") {

    // -----------------------------------------------------------------
    // [D] EGY ELEM ?id= alapján, 404 ha nincs
    // HA A FELADAT EZT KÉRI: "...?id=N: egyetlen elem", "ha nincs ilyen: 404"
    // -----------------------------------------------------------------
    if ($id !== null) {
        $stmt = $pdo->prepare($alapSql . " WHERE k.id = :id");    // prepared statement
        $stmt->execute([":id" => $id]);
        $sor = $stmt->fetch();                                    // EGY sor, vagy false
        if ($sor === false) {
            valasz(404, ["error" => "A könyv nem található."]);
        }
        valasz(200, konyvAlakitas($sor));
    }

    // -----------------------------------------------------------------
    // [C] LISTA, elhagyható szűrőkkel
    // HA A FELADAT EZT KÉRI: "az összes ... név szerint rendezve",
    //                        "elhagyható paraméter: ...Id esetén csak az adott ...",
    //                        "search: a nevében szerepel a keresett szöveg"
    // -----------------------------------------------------------------
    $sql = $alapSql . " WHERE 1 = 1";      // trükk: így minden szűrő " AND ..." lehet
    $parameterek = [];

    if (isset($_GET["szerzo_id"]) && $_GET["szerzo_id"] !== "") {
        $sql .= " AND k.szerzo_id = :szerzo_id";
        $parameterek[":szerzo_id"] = (int)$_GET["szerzo_id"];
    }
    if (isset($_GET["kereses"]) && $_GET["kereses"] !== "") {
        $sql .= " AND k.cim LIKE :kereses";                  // LIKE + %...% = "tartalmazza"
        $parameterek[":kereses"] = "%" . $_GET["kereses"] . "%";   // . = szövegösszefűzés
    }
    $sql .= " ORDER BY k.cim";                               // rendezés (ASC = növekvő, DESC = csökkenő)

    $stmt = $pdo->prepare($sql);
    $stmt->execute($parameterek);

    $eredmeny = [];
    foreach ($stmt->fetchAll() as $sor) {
        $eredmeny[] = konyvAlakitas($sor);
    }
    valasz(200, $eredmeny);
}


// ---------------------------------------------------------------------
// [E] POST: ÚJ ELEM. Törzs: {"cim": "...", "szerzo_id": 1, "ev": 1900, "ar": 2990, "keszlet": 4}
// HA A FELADAT EZT KÉRI: "új ... felvétele", "ellenőrzések ... 400", "siker esetén 201"
// ---------------------------------------------------------------------
if ($metodus === "POST") {
    $adat = keresTorzse();
    $cim = isset($adat["cim"]) ? trim($adat["cim"]) : "";
    $szerzoId = $adat["szerzo_id"] ?? null;
    $ev = $adat["ev"] ?? null;
    $ar = $adat["ar"] ?? null;
    $keszlet = $adat["keszlet"] ?? 0;

    // ellenőrzések a feladat SORRENDJÉBEN, az első hibánál 400
    if ($cim === "") {
        valasz(400, ["error" => "A cím megadása kötelező."]);
    }
    if (!is_int($ar) || $ar <= 0) {
        valasz(400, ["error" => "Az ár csak pozitív egész szám lehet."]);
    }
    if (!is_int($ev)) {
        valasz(400, ["error" => "Az év megadása kötelező."]);
    }
    if (!is_int($keszlet) || $keszlet < 0) {
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }
    // létezik-e a hivatkozott szerző? (COUNT(*) = hány ilyen sor van)
    if (!is_int($szerzoId)) {
        valasz(400, ["error" => "Nem létező szerző."]);
    }
    $ell = $pdo->prepare("SELECT COUNT(*) FROM szerzok WHERE id = :id");
    $ell->execute([":id" => $szerzoId]);
    if ($ell->fetchColumn() == 0) {
        valasz(400, ["error" => "Nem létező szerző."]);
    }

    $stmt = $pdo->prepare("INSERT INTO konyvek (cim, szerzo_id, ev, ar, keszlet)
                           VALUES (:cim, :szerzo_id, :ev, :ar, :keszlet)");
    $stmt->execute([":cim" => $cim, ":szerzo_id" => $szerzoId, ":ev" => $ev, ":ar" => $ar, ":keszlet" => $keszlet]);
    $ujId = (int)$pdo->lastInsertId();                     // az új sor azonosítója

    valasz(201, ["message" => "Könyv sikeresen hozzáadva.", "id" => $ujId]);
}


// ---------------------------------------------------------------------
// [F] PATCH (vagy PUT): MÓDOSÍTÁS. konyvek.php?id=3, törzs: {"keszlet": 10}
// HA A FELADAT EZT KÉRI: "... módosítása", "hiányzó azonosító: 400", "nem létező: 404"
// ---------------------------------------------------------------------
if ($metodus === "PATCH") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);
    }
    $adat = keresTorzse();
    $keszlet = $adat["keszlet"] ?? null;
    if (!is_int($keszlet) || $keszlet < 0) {
        valasz(400, ["error" => "A készlet nem lehet negatív."]);
    }

    // létezik-e?
    $ell = $pdo->prepare("SELECT COUNT(*) FROM konyvek WHERE id = :id");
    $ell->execute([":id" => $id]);
    if ($ell->fetchColumn() == 0) {
        valasz(404, ["error" => "A könyv nem található."]);
    }

    $stmt = $pdo->prepare("UPDATE konyvek SET keszlet = :keszlet WHERE id = :id");
    $stmt->execute([":keszlet" => $keszlet, ":id" => $id]);

    valasz(200, ["message" => "Készlet frissítve.", "id" => $id, "keszlet" => $keszlet]);
}


// ---------------------------------------------------------------------
// [G] DELETE: TÖRLÉS. konyvek.php?id=3
// HA A FELADAT EZT KÉRI: "... törlése", "nem létező: 404", "siker: 200 + üzenet"
// (Ha kapcsolótábla is van: ELŐBB onnan törölj! Lásd 01_Babszem/termekek.php)
// ---------------------------------------------------------------------
if ($metodus === "DELETE") {
    if ($id === null) {
        valasz(400, ["error" => "Hiányzó azonosító."]);
    }
    $stmt = $pdo->prepare("DELETE FROM konyvek WHERE id = :id");
    $stmt->execute([":id" => $id]);
    if ($stmt->rowCount() === 0) {                         // 0 sor törlődött = nem létezett
        valasz(404, ["error" => "A könyv nem található."]);
    }
    valasz(200, ["message" => "Könyv törölve."]);
}


// ---------------------------------------------------------------------
// [H] MINDEN MÁS METÓDUS: 405
// ---------------------------------------------------------------------
valasz(405, ["error" => "Method not allowed"]);
