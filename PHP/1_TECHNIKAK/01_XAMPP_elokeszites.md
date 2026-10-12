# 01 – Előkészítés: XAMPP, adatbázis importálása, htdocs

**Mikor kell?** Mindig, a PHP-rész elején. Ha ez nincs meg, semmi nem működik.

## 1. XAMPP indítása

1. Start menü → **XAMPP Control Panel**.
2. **Apache** sor → **Start**. **MySQL** sor → **Start**. Mindkettő neve **zöld** lesz.

## 2. Az adatbázis importálása (phpMyAdmin)

1. Böngésző: **http://localhost/phpmyadmin** (vagy a Control Panelen a MySQL sor **Admin** gombja).
2. Felül: **Importálás** (Import) fül.
3. **Fájl kiválasztása** → a kapott `.sql` (pl. `babszem_webshop.sql`).
4. Görgess le → **Importálás** (Import / Go) gomb.
5. Bal oldalt megjelenik az adatbázis (pl. `babszem_webshop`). Kattints rá → nézd meg a **táblákat és az oszlopneveket**: ezeket fogod használni az SQL-ben.

> A legtöbb vizsga-SQL fájl maga hozza létre az adatbázist (`CREATE DATABASE ...`). Ha a tiéd nem: bal oldalt **Új** → név → Létrehozás, utána rákattintasz, és **abban** importálsz.

**Visszaállítás** (ha tesztelés közben töröltél): importáld újra ugyanazt a `.sql`-t.

## 3. A projekt a htdocs-ba

Másold a kapott mappát (pl. `babszem_webshop`) ide: **`C:\xampp\htdocs\`**

```
C:\xampp\htdocs\babszem_webshop\
├─ frontend\    (kész)
└─ backend\     ← IDE írod a PHP fájlokat: config.php, kategoriak.php, termekek.php
```

## 4. Megnyitás

- Frontend: **http://localhost/babszem_webshop/frontend/index.html**
- Egy végpont: **http://localhost/babszem_webshop/backend/kategoriak.php**

## 5. A PHP fájlok szerkesztése

VS Code → **File → Open Folder** → `C:\xampp\htdocs\babszem_webshop`. Új fájl: a `backend` mappán jobb klikk → **New File** → `config.php`. Mentés után a böngészőben elég **F5**, nem kell semmit újraindítani.

## Ha nem indul el

| Tünet | Ok | Megoldás |
|---|---|---|
| Apache nem lesz zöld, „Port 80 in use” | másik program foglalja a 80-as portot | szólj a felügyelőnek; vagy Apache → Config → httpd.conf: `Listen 80` → `Listen 8080`, majd a címekben `localhost:8080` |
| MySQL nem lesz zöld, „Port 3306 in use” | fut egy másik MySQL | Szolgáltatások (services.msc) → a másik MySQL leállítása, vagy szólj a felügyelőnek |
| „Access forbidden” / „Object not found” | rossz mappa vagy elírt cím | nézd meg, pontosan hol van a fájl a htdocs alatt |

**Élesben:** [Babszem lépésről lépésre, 0. lépés](../2_GYAKORLO_FELADATOK/01_Babszem/LEPESROL_LEPESRE.md)
