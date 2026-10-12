# 09 – Tesztelés és buktatók (PHP)

## Hogyan próbálod ki?

| Kérés | Hogyan |
|---|---|
| GET | böngészőbe a cím: `http://localhost/babszem_webshop/backend/termekek.php?id=2` |
| bármi | a [teszt.html](../0_GYORSINDITO/konyvtar/teszt.html): másold a PHP fájlok mellé, és nyisd meg **http://localhost/...**/teszt.html címen |
| bármi | a kész frontend gombjai; F12 → **Network** fül → kattints a kérésre → **Response** (válasz) és **Headers** (státuszkód) |
| bármi | VS Code **Thunder Client** bővítmény vagy **Postman**, ha telepítve van |
| bármi | böngésző F12 → **Console**: `fetch("termekek.php?id=6", {method: "PATCH", body: JSON.stringify({stock: 15})}).then(r => r.json()).then(console.log)` |

## Buktatók

| Tünet | Ok | Megoldás |
|---|---|---|
| a böngésző a **PHP kódot** mutatja, vagy letölti a fájlt | nem Apache-on keresztül nyitottad meg | **http://localhost/...** cím, és fusson az Apache |
| `Not Found` az egész fájlra | rossz útvonal / fájlnév | a htdocs alatt pontosan hol van? kis/nagybetű! |
| `Access denied for user 'root'` | rossz jelszó a config.php-ban | XAMPP: `""` (üres) |
| `Unknown database` | nem importáltad / elírtad a nevet | phpMyAdmin bal oldal |
| `Base table or view not found` / `Unknown column` | elírt tábla- vagy oszlopnév | phpMyAdminban nézd meg a pontos nevet |
| `SQLSTATE[HY093]: Invalid parameter number` | a `:helyőrző` neve nem egyezik az `execute([...])` kulcsával | mindkettő pontosan ugyanaz legyen (`:id` – `":id"`) |
| `Cannot modify header information - headers already sent` | a `header()` előtt már ki lett írva valami: **szóköz vagy üres sor a `<?php` előtt**, vagy egy `echo` | a `<?php` legyen az első karakter, a `header` az elején |
| a frontend: `Unexpected token '<'` / `is not valid JSON` | a PHP hibaüzenetet írt ki JSON helyett | nyisd meg a végpontot a böngészőben → ott látod a PHP-hibát |
| `"id": "6"` (szövegként) | nem alakítottad számmá | `(int)$sor["id"]` |
| `á` az ékezet helyén | hiányzik a flag | `json_encode($x, JSON_UNESCAPED_UNICODE)` |
| `{"2": {...}, "3": {...}}` lista helyett | a tömb kulcsai nem 0-tól mennek | `array_values($tomb)` |
| a 405 után mégis lefut a többi | hiányzik az `exit;` | `exit;` minden válasz után (vagy a `valasz()` függvény) |
| `Undefined array key "id"` (Warning) | a paraméter nincs megadva | `isset($_GET["id"])` vagy `$adat["x"] ?? null` |
| a PATCH/POST törzse üres | rossz kulcs vagy nem JSON-t küldtél | `json_decode(file_get_contents("php://input"), true)`; teszteléskor valódi JSON-t küldj |
| `Integrity constraint violation` törléskor | a kapcsolótábla még hivatkozik rá | előbb a kapcsolótáblából törölj |
| a teszt után „eltűntek” az adatok | törölted | importáld újra a `.sql`-t |

## A leadás

A **teljes projektmappát** add le (pl. `babszem_webshop` a `backend` és `frontend` mappával), a `.sql`-lel együtt, ha kérik.
