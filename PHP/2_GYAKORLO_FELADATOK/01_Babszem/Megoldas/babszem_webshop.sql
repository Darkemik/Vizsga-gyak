-- =======================================================================
-- Babszem Kávézó webshop – MySQL / MariaDB adatbázis (XAMPP, phpMyAdmin)
-- =======================================================================

SET NAMES utf8mb4;

DROP DATABASE IF EXISTS babszem_webshop;
CREATE DATABASE babszem_webshop CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE babszem_webshop;

CREATE TABLE categories (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(50) NOT NULL
);

CREATE TABLE products (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  description VARCHAR(255),
  price INT NOT NULL,
  stock INT NOT NULL DEFAULT 0
);

-- Kapcsolótábla: egy termék több kategóriába is tartozhat
CREATE TABLE product_categories (
  product_id INT NOT NULL,
  category_id INT NOT NULL,
  PRIMARY KEY (product_id, category_id),
  CONSTRAINT fk_pc_product FOREIGN KEY (product_id) REFERENCES products(id),
  CONSTRAINT fk_pc_category FOREIGN KEY (category_id) REFERENCES categories(id)
);

INSERT INTO categories (name) VALUES
  ('Szemes kávé'),
  ('Őrölt kávé'),
  ('Kapszula'),
  ('Kiegészítők'),
  ('Bio'),
  ('Ajándékötlet');

INSERT INTO products (name, description, price, stock) VALUES
  ('Brazil Santos 250 g', 'Csokoládés, mogyorós, alacsony savasságú szemes kávé.', 3490, 42),
  ('Etióp Yirgacheffe 250 g', 'Virágos, citrusos jegyek, világos pörkölés.', 4290, 18),
  ('Kolumbiai Supremo 250 g', 'Karamellás édesség, kerek test.', 3790, 25),
  ('Házi espresso blend 1 kg', 'A kávézóinkban használt keverék, nagy kiszerelésben.', 11900, 9),
  ('Guatemalai Antigua őrölt 250 g', 'Fűszeres, kakaós, filteres főzéshez őrölve.', 3590, 30),
  ('Koffeinmentes Kolumbia őrölt 250 g', 'Svájci vizes eljárással koffeinmentesített.', 3890, 0),
  ('Lungo kapszula (10 db)', 'Nespresso-kompatibilis, lebomló kapszulák.', 1990, 60),
  ('Ristretto kapszula (10 db)', 'Intenzív, sűrű kávé kis csészébe.', 1990, 55),
  ('Bio Peru Cajamarca 250 g', 'Bio minősítésű, gyümölcsös, enyhe kávé.', 4190, 14),
  ('Bio espresso kapszula (10 db)', 'Bio kávé lebomló kapszulában.', 2290, 33),
  ('French press 600 ml', 'Hőálló üveg kanna, rozsdamentes szűrővel.', 7990, 7),
  ('Kotyogós kávéfőző 3 csészés', 'Klasszikus alumínium mokafőző.', 6490, 12),
  ('Kézi kávédaráló', 'Kerámia őrlőkővel, állítható őrlési finomság.', 12490, 4),
  ('Babszem bögre', 'Kézzel festett kerámia bögre, 300 ml.', 3290, 40),
  ('Filterpapír 100 db', 'Fehérítetlen papírfilter 1x4-es tölcsérhez.', 990, 120),
  ('Kávékóstoló ajándékcsomag', 'Három 100 g-os kávé és egy kóstolójegyzet díszdobozban.', 8990, 10);

INSERT INTO product_categories (product_id, category_id) VALUES
  (1, 1),
  (2, 1), (2, 6),
  (3, 1),
  (4, 1),
  (5, 2),
  (6, 2),
  (7, 3),
  (8, 3),
  (9, 1), (9, 5),
  (10, 3), (10, 5),
  (11, 4), (11, 6),
  (12, 4),
  (13, 4), (13, 6),
  (14, 4), (14, 6),
  (15, 4),
  (16, 1), (16, 6);
