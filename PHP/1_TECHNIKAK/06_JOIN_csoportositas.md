# 06 – Táblák összekapcsolása (JOIN) és csoportosítás

**Mikor kell?** „…a kategória nevével együtt”, „kapcsolja össze a három táblát (LEFT JOIN)”, „minden terméknél egy categories tömbben szerepeljenek a kategóriái”, „a kategóriába tartozó termékek számával (productCount)”

## 1. Egyszerű JOIN (1 – N kapcsolat): a termék mellé a kategória neve

```sql
SELECT p.id, p.name, c.name AS categoryName
FROM products p                              -- p = rövid név (alias)
JOIN categories c ON c.id = p.category_id    -- melyik oszlop melyikhez kapcsolódik
ORDER BY p.name
```

| | Mikor jön a sor? |
|---|---|
| `JOIN` (= INNER JOIN) | csak ha **van** párja a másik táblában |
| `LEFT JOIN` | **mindig** jön a bal oldali tábla sora; ha nincs párja, a másik tábla oszlopai **NULL**-ok |

> `AS categoryName`: az oszlop új neve az eredményben. Így `$sor["categoryName"]`-ként éred el, és nem keveredik a két `name`.

## 2. Kapcsolótábla (N – N): egy terméknek TÖBB kategóriája lehet

Táblák: `products` – `product_categories` (product_id, category_id) – `categories`

```sql
SELECT p.id, p.name, p.price,
       c.id AS category_id, c.name AS category_name
FROM products p
LEFT JOIN product_categories pc ON pc.product_id = p.id
LEFT JOIN categories c ON c.id = pc.category_id
ORDER BY p.id, c.name
```

Az eredményben egy termék **annyi sorban** jön, ahány kategóriája van:

```
id | name                     | price | category_id | category_name
 2 | Etióp Yirgacheffe 250 g  | 4290  | 6           | Ajándékötlet
 2 | Etióp Yirgacheffe 250 g  | 4290  | 1           | Szemes kávé
 3 | Kolumbiai Supremo 250 g  | 3790  | 1           | Szemes kávé
18 | Kategória nélküli        | 100   | NULL        | NULL
```

## 3. Csoportosítás PHP-ban: „a kategóriái egy tömbben”

```php
$termekek = [];                                       // KULCS = a termék id-ja
foreach ($stmt->fetchAll() as $sor) {
    $id = (int)$sor["id"];

    if (!isset($termekek[$id])) {                     // először látjuk -> felvesszük
        $termekek[$id] = [
            "id" => $id,
            "name" => $sor["name"],
            "price" => (int)$sor["price"],
            "categories" => []                        // üres tömb
        ];
    }
    if ($sor["category_id"] !== null) {               // van kategória ebben a sorban
        $termekek[$id]["categories"][] = [
            "id" => (int)$sor["category_id"],
            "name" => $sor["category_name"]
        ];
    }
}
$lista = array_values($termekek);                     // kulcsok el -> JSON-ban [ ... ] lista
```

Eredmény:

```json
{ "id": 2, "name": "Etióp Yirgacheffe 250 g", "price": 4290,
  "categories": [ {"id": 6, "name": "Ajándékötlet"}, {"id": 1, "name": "Szemes kávé"} ] }
```

> ⚠️ Az `array_values` nélkül a JSON **objektum** lenne (`{"2": {...}, "3": {...}}`), nem lista!

## 4. Darabszám / összeg csoportonként: GROUP BY (SQL-ben)

„az összes kategória a hozzá tartozó termékek számával (productCount)”:

```sql
SELECT c.id, c.name, COUNT(p.id) AS productCount
FROM categories c
LEFT JOIN products p ON p.category_id = c.id
GROUP BY c.id, c.name
ORDER BY c.id
```

| Függvény | Jelentés |
|---|---|
| `COUNT(p.id)` | hány darab (LEFT JOIN-nál a 0 is jó lesz) |
| `SUM(oi.quantity * oi.sale_price)` | összeg |
| `AVG(...)`, `MIN(...)`, `MAX(...)` | átlag, legkisebb, legnagyobb |

Kapcsolótáblával: `COUNT(pc.product_id)` és `LEFT JOIN product_categories pc ON pc.category_id = c.id`.

**Élesben:** [Babszem termekek.php → termekekLekerdezese()](../2_GYAKORLO_FELADATOK/01_Babszem/Megoldas/babszem_webshop/backend/termekek.php), [gyorsindító konyvek.php](../0_GYORSINDITO/konyvtar/konyvek.php) (egyszerű JOIN)
