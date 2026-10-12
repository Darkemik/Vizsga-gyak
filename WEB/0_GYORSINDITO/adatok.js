// =====================================================================
// [F] ADATOK: a kapott .json tartalma, elé "const termekek = ", a végére ";"
//     Így a weboldal szerver nélkül is működik (dupla kattintás az index.html-en).
//     Ellenőrizd a képek útvonalát! (lásd 1_TECHNIKAK/06)
// =====================================================================
const termekek = [
    { "id": 1, "nev": "Kalandregény",    "kategoria": "Könyv", "ar": "3 990 Ft",  "kep": "kepek/konyv.png", "elerheto": true },
    { "id": 2, "nev": "Szakácskönyv",    "kategoria": "Könyv", "ar": "5 490 Ft",  "kep": "kepek/konyv.png", "elerheto": false },
    { "id": 3, "nev": "Verseskötet",     "kategoria": "Könyv", "ar": "2 990 Ft",  "kep": "kepek/konyv.png", "elerheto": true },
    { "id": 4, "nev": "Társasjáték",     "kategoria": "Játék", "ar": "8 990 Ft",  "kep": "kepek/jatek.png", "elerheto": true },
    { "id": 5, "nev": "Kirakós (1000)",  "kategoria": "Játék", "ar": "4 490 Ft",  "kep": "kepek/jatek.png", "elerheto": true },
    { "id": 6, "nev": "Kártyajáték",     "kategoria": "Játék", "ar": "2 490 Ft",  "kep": "kepek/jatek.png", "elerheto": false },
    { "id": 7, "nev": "Bakelitlemez",    "kategoria": "Zene",  "ar": "11 990 Ft", "kep": "kepek/zene.png",  "elerheto": true },
    { "id": 8, "nev": "Koncertjegy",     "kategoria": "Zene",  "ar": "9 990 Ft",  "kep": "kepek/zene.png",  "elerheto": true }
];
