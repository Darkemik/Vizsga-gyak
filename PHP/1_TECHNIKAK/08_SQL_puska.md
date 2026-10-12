# 08 – SQL-puska

> Tipp: phpMyAdminban az adatbázison belül az **SQL** fülön bármelyik lekérdezést kipróbálhatod, mielőtt beírod a PHP-ba.

## Lekérdezés

```sql
SELECT id, name, price                 -- mely oszlopok (* = mind)
FROM products                          -- melyik táblából
WHERE price > 3000 AND stock > 0       -- feltétel (AND, OR, NOT)
ORDER BY name                          -- rendezés: ASC (növekvő, alap) / DESC (csökkenő)
LIMIT 5;                               -- csak az első 5
```

| Feltétel | Jelentés |
|---|---|
| `=`, `<>` vagy `!=`, `<`, `>`, `<=`, `>=` | összehasonlítás |
| `name LIKE '%kávé%'` | tartalmazza (`%` = bármi) |
| `name LIKE 'Bio%'` | ezzel kezdődik |
| `description IS NULL` / `IS NOT NULL` | üres-e (NEM `= NULL`!) |
| `id IN (1, 3, 5)` | benne van-e a felsorolásban |
| `price BETWEEN 1000 AND 5000` | a két érték között |

## Összesítés

```sql
SELECT COUNT(*) FROM products;                          -- hány sor
SELECT SUM(stock), AVG(price), MIN(price), MAX(price) FROM products;

SELECT category_id, COUNT(*) AS db                      -- csoportonként
FROM product_categories
GROUP BY category_id
HAVING COUNT(*) > 2                                      -- csoportokra szűrés (WHERE helyett)
ORDER BY db DESC;
```

## Összekapcsolás

```sql
SELECT p.name, c.name AS categoryName
FROM products p
JOIN categories c ON c.id = p.category_id               -- csak ha van párja
-- LEFT JOIN: akkor is, ha nincs (a hiányzó oszlopok NULL-ok)
```

## Módosítás

```sql
INSERT INTO products (name, price, stock) VALUES ('Új kávé', 3990, 10);
UPDATE products SET stock = 15 WHERE id = 6;            -- WHERE nélkül MINDEN sort átír!
DELETE FROM products WHERE id = 1;                      -- WHERE nélkül MINDENT töröl!
```

## PHP-ban: az értékek helyén :helyőrző

```php
$stmt = $pdo->prepare("UPDATE products SET stock = :stock WHERE id = :id");
$stmt->execute([":stock" => 15, ":id" => 6]);
```

> SQL-ben a szöveg **aposztrófok** között: `'Bio'`. PHP-ban a helyőrzőnél nem kell (a PDO intézi).

## C# LINQ ↔ SQL

| LINQ | SQL |
|---|---|
| `.Where(p => p.Price > 3000)` | `WHERE price > 3000` |
| `.OrderBy(p => p.Name)` | `ORDER BY name` |
| `.OrderByDescending(...)` | `ORDER BY ... DESC` |
| `.Select(p => p.Name)` | `SELECT name` |
| `.Count()` | `COUNT(*)` |
| `.GroupBy(p => p.CategoryId)` | `GROUP BY category_id` |
| `.Take(5)` | `LIMIT 5` |
| `.Contains("kávé")` | `LIKE '%kávé%'` |
