# Babszem PHP – lépésről lépésre

A sorrend a pontok olcsósága szerint halad. **Minden lépés után próbáld ki a böngészőben** (mentés, majd F5).

---

## 0. Előkészítés (5 perc) – enélkül semmi nem működik

1. **XAMPP Control Panel** → Apache **Start**, MySQL **Start** (zöld).
2. **http://localhost/phpmyadmin** → **Importálás** → Fájl kiválasztása: `babszem_webshop.sql` → lent **Importálás**.
   Bal oldalt megjelenik a `babszem_webshop`, benne 3 tábla.
3. A `babszem_webshop` mappát (benne `frontend` és az üres `backend`) másold ide: **`C:\xampp\htdocs\`**
4. VS Code → **File → Open Folder** → `C:\xampp\htdocs\babszem_webshop`
5. Próba: **http://localhost/babszem_webshop/frontend/index.html** → az oldal megjelenik, de termékek még nincsenek (nincs backend).

---

## 1. config.php (2 perc) → 1 pont

`backend` mappán jobb klikk → **New File** → `config.php` → másold be a [Megoldas/.../config.php](Megoldas/babszem_webshop/backend/config.php) tartalmát.

**Próba:** http://localhost/babszem_webshop/backend/config.php → **üres fehér oldal** = jó. (Ha hibaüzenet: [03 technika](../../1_TECHNIKAK/03_Kapcsolat_config_PDO.md) táblázata.)

---

## 2. kategoriak.php (3 perc) → 1 pont

Új fájl: `kategoriak.php` → másold be a [kategoriak.php](Megoldas/babszem_webshop/backend/kategoriak.php) tartalmát. A lényeg:

```php
<?php
require_once "config.php";
header("Content-Type: application/json; charset=utf-8");
if ($_SERVER["REQUEST_METHOD"] !== "GET") { http_response_code(405); echo json_encode(["error" => "Method not allowed"]); exit; }
$stmt = $pdo->query("SELECT id, name FROM categories ORDER BY name");
$kategoriak = [];
foreach ($stmt->fetchAll() as $sor) { $kategoriak[] = ["id" => (int)$sor["id"], "name" => $sor["name"]]; }
echo json_encode($kategoriak, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
```

**Próba:** http://localhost/babszem_webshop/backend/kategoriak.php → 6 kategória, az első az „Ajándékötlet” (id 6). A frontend frissítése után megjelennek a **szűrőgombok**.

---

## 3. termekek.php – az eleje + GET lista (10 perc) → 4 pont

Új fájl: `termekek.php`. Másold be a [termekek.php](Megoldas/babszem_webshop/backend/termekek.php) **elejét a GET ággal együtt** (a `// GET` blokk végéig). Benne:

1. `require_once` + `header(...)`
2. `valasz()` segédfüggvény
3. `termekekLekerdezese()`: **LEFT JOIN** a 3 táblára, majd csoportosítás termékenként (lásd [06 technika](../../1_TECHNIKAK/06_JOIN_csoportositas.md))
4. `$metodus` és `$id`
5. a GET ág

**Próba:** http://localhost/babszem_webshop/backend/termekek.php → 16 termék, mindegyikben `categories` tömb. **A frontenden megjelennek a termékkártyák!**

> Ha a JOIN/csoportosítás nem megy, akkor is adj le valamit: egy sima `SELECT id, name, description, price, stock FROM products ORDER BY id` lista (mint a kategoriak.php) már részpontot érhet.

---

## 4. GET ?id= (már benne van a 3. lépésben) → 2 pont

**Próba:**
- http://localhost/babszem_webshop/backend/termekek.php?id=2 → Etióp Yirgacheffe, **objektumként** (`{ ... }`, nem `[ ... ]`)
- http://localhost/babszem_webshop/backend/termekek.php?id=99 → `{"error": "A termék nem található."}`

---

## 5. A fájl vége: 405 (1 perc) → része a 8. feladatnak

A fájl **legvégére**:

```php
valasz(405, ["error" => "Method not allowed"]);
```

---

## 6. POST: új termék (10 perc) → 3 pont

Másold be a **POST** ágat a fájl végén lévő `valasz(405, ...)` sor **ELÉ**, a `keresTorzse()` függvényt pedig a többi segédfüggvény mellé. A POST ág lépései:

1. törzs beolvasása: `json_decode(file_get_contents("php://input"), true)`
2. ellenőrzések sorban: név → ár → készlet → kategóriák (400)
3. tranzakció: INSERT `products` → `lastInsertId()` → INSERT `product_categories` (foreach) → commit
4. `valasz(201, ["message" => "Termék sikeresen hozzáadva.", "id" => $ujId])`

**Próba:** a frontend alján lévő **űrlappal** vegyél fel egy terméket. Üres névvel küldve az űrlap alatt meg kell jelennie: „A név megadása kötelező.”

---

## 7. PATCH és DELETE (8 perc) → 3 pont

Másold be a **PATCH** és **DELETE** ágat szintén a `valasz(405, ...)` sor **ELÉ**, a `termekLetezik()` függvényt a segédfüggvények mellé.

**Próba a frontenden:** egy kártyán írj át a készletet → **Készlet mentése**; egy kártyán → **Törlés**.

> Teszt után az adatbázist a `.sql` **újraimportálásával** állíthatod vissza.

---

## 8. Végső ellenőrzés

| Mit nézel | Hol |
|---|---|
| minden válasz JSON, ékezetek rendben | böngészőben a végpontok |
| a frontend mindent megjelenít, nincs hiba | F12 → Console / Network |
| PUT-ra 405 | [teszt.html](../../0_GYORSINDITO/konyvtar/teszt.html) (a `backend` mappába másolva, `http://localhost/babszem_webshop/backend/teszt.html`) |

✅ **Leadás:** a teljes `babszem_webshop` mappa (`backend` + `frontend`).
