# KonyvtarGUI – lépésről lépésre

## 1. Projekt, osztály, adatfájl (5 perc)

1. **Windows Forms App** → név: `KonyvtarGUI`.
2. Add → Class… → `Konyv.cs` → tartalma: [Megoldas/Konyv.cs](Megoldas/Konyv.cs).
3. `forras` mappa → bele a `konyvek.txt`.

## 2. Az ablak (10 perc)

| # | Toolboxból | (Name) | Text / beállítás |
|---|---|---|---|
| 0 | *(az ablak)* | – | Text: `Iskolai könyvtár`, kb. 750×420 |
| 1 | **Label** | **`lblValasztek`** | Font: 11pt, Bold |
| 2 | Label | – | `Műfaj:` |
| 3 | **ComboBox** | **`cbMufaj`** | DropDownStyle: **DropDownList** |
| 4 | **ListBox** | **`lbKonyvek`** | – |
| 5 | **GroupBox** | `grpReszletek` | `A kiválasztott könyv` |
| 6 | Label ×6 (a GroupBoxba!) | – | `Cím:`, `Szerző:`, `Műfaj:`, `Kiadás éve:`, `Oldalszám:`, `Állapot:` |
| 7 | **Label** ×6 (a GroupBoxba!) | **`lblCim`, `lblSzerzo`, `lblMufaj`, `lblKiadas`, `lblOldal`, `lblAllapot`** | `-` |
| 8 | **Button** | **`btnKolcsonzes`** | `Kölcsönzés` |
| 9 | **Button** | **`btnKilepes`** | `Kilépés` |

> Tipp: a 6 felirat + 6 értékcímke felrakása gyorsabb, ha egy párt felraksz, kijelölöd mindkettőt, **Ctrl+C / Ctrl+V** ötször, és csak a Textet és a (Name)-et írod át.

## 3. A kód (15 perc)

Teljes kód: [Megoldas/Form1.cs](Megoldas/Form1.cs).

### 3/a – listák + események

```csharp
List<Konyv> konyvek = new List<Konyv>();
List<int> megtekintettek = new List<int>();     // a megnézett könyvek Id-jai
const string MIND = "(mindegyik)";

// konstruktorban:
this.Load += Form1_Load;
cbMufaj.SelectedIndexChanged += CbMufaj_SelectedIndexChanged;
lbKonyvek.SelectedIndexChanged += LbKonyvek_SelectedIndexChanged;
btnKolcsonzes.Click += BtnKolcsonzes_Click;
btnKilepes.Click += BtnKilepes_Click;
```

### 3/b – betöltés (12.)

```csharp
int mufajDb = konyvek.Select(k => k.Mufaj).Distinct().Count();
lblValasztek.Text = $"VÁLASSZON {mufajDb} MŰFAJ {konyvek.Count} KÖNYVE KÖZÜL!";

cbMufaj.Items.Add(MIND);
foreach (string m in konyvek.Select(k => k.Mufaj).Distinct().OrderBy(m => m))
    cbMufaj.Items.Add(m);
cbMufaj.SelectedIndex = 0;      // ez elsüti a CbMufaj_SelectedIndexChanged-et -> megtelik a lista
```

### 3/c – műfaj kiválasztása (13.)

```csharp
string mufaj = cbMufaj.SelectedItem.ToString();
lbKonyvek.Items.Clear();
foreach (Konyv k in konyvek.Where(k => mufaj == MIND || k.Mufaj == mufaj))
    lbKonyvek.Items.Add(k);
if (lbKonyvek.Items.Count > 0) lbKonyvek.SelectedIndex = 0;
```

### 3/d – könyv kiválasztása (14.): ⚠️ a legfontosabb rész

```csharp
if (lbKonyvek.SelectedItem == null) return;
Konyv k = (Konyv)lbKonyvek.SelectedItem;       // NEM konyvek[SelectedIndex]!
lblCim.Text = k.Cim;
// ...
if (!megtekintettek.Contains(k.Id)) megtekintettek.Add(k.Id);
```

> Ha `konyvek[lbKonyvek.SelectedIndex]`-et írnál: a Dráma szűrésnél a 0. sor az „Az ember tragédiája”,
> de a `konyvek[0]` az „Egri csillagok” → **rossz könyv adatai** jelennének meg.

### 3/e – Kölcsönzés (15.) és Kilépés (16.)

Másold ki a `BtnKolcsonzes_Click` és `BtnKilepes_Click` metódust. A kölcsönzés sorrendje:
1. nincs kiválasztva → üzenet, `return`
2. már ki van kölcsönözve → üzenet, `return`
3. YesNo → Igen: fájlba írás (`true` = hozzáfűzés), `k.Kikolcsonozve = true;`, címkék frissítése

## 4. Kipróbálás

| Mit csinálsz | Mit kell látnod |
|---|---|
| Indítás | felirat: 5 műfaj, 20 könyv; „(mindegyik)”; 20 könyv; Egri csillagok adatai |
| Műfaj: Dráma | 3 könyv |
| Bánk bán → Kölcsönzés | „már ki van kölcsönözve” üzenet |
| Csongor és Tünde → Kölcsönzés → Igen | állapot: Kikölcsönözve; a fájlban 1 sor |
| Kilépés → Nem | marad nyitva |
| Kilépés → Igen | bezárul |
