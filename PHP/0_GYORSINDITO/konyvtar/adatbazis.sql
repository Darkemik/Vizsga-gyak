-- =======================================================================
-- Gyakorló adatbázis a PHP gyorsindítóhoz (phpMyAdmin -> Importálás)
-- Két tábla: szerzok (1) --- (N) konyvek
-- =======================================================================

SET NAMES utf8mb4;

DROP DATABASE IF EXISTS konyvtar;
CREATE DATABASE konyvtar CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE konyvtar;

CREATE TABLE szerzok (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nev VARCHAR(100) NOT NULL
);

CREATE TABLE konyvek (
  id INT AUTO_INCREMENT PRIMARY KEY,
  cim VARCHAR(150) NOT NULL,
  szerzo_id INT NOT NULL,
  ev INT NOT NULL,
  ar INT NOT NULL,
  keszlet INT NOT NULL DEFAULT 0,
  CONSTRAINT fk_konyv_szerzo FOREIGN KEY (szerzo_id) REFERENCES szerzok(id)
);

INSERT INTO szerzok (nev) VALUES
  ('Jókai Mór'),
  ('Gárdonyi Géza'),
  ('Molnár Ferenc'),
  ('Szabó Magda');

INSERT INTO konyvek (cim, szerzo_id, ev, ar, keszlet) VALUES
  ('A kőszívű ember fiai', 1, 1869, 3990, 5),
  ('Az arany ember', 1, 1872, 3490, 0),
  ('Egri csillagok', 2, 1899, 3290, 12),
  ('A láthatatlan ember', 2, 1902, 2990, 3),
  ('A Pál utcai fiúk', 3, 1906, 2490, 20),
  ('Abigél', 4, 1970, 3790, 7),
  ('Az ajtó', 4, 1987, 3590, 2);
