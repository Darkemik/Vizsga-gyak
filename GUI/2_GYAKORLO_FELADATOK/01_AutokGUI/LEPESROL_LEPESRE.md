# AutoGUI – lépésről lépésre

Ezt a sorrendet kövesd. Minden lépés után futtathatod (F5), így hamar kiderül, ha valami nem jó.

---

## 1. lépés – Projekt létrehozása (2 perc)

1. Visual Studio → **Create a new project**
2. Keresőbe: `Windows Forms` → válaszd a **Windows Forms App** sablont (C#).
   ⚠️ NEM a „Windows Forms App (.NET **Framework**)”-et!
3. Project name: **`AutoGUI`** → Next → Framework: ami fel van ajánlva (.NET 8/9/10) → **Create**.

Megnyílik egy üres ablak: ez a **Designer** (`Form1.cs [Design]`).

---

## 2. lépés – Osztályok átvétele a konzolos részből (2 perc)

1. Solution Explorerben jobb klikk az **AutoGUI** projekten → **Add** → **Existing Item…**
2. Tallózd ki a konzolos projekted mappáját, jelöld ki: `Auto.cs`, `Gyarto.cs`, `Karosszeria.cs`, `Valto.cs` → **Add**.
   (A VS átmásolja őket, a konzolos projekt nem változik.)
3. Nyisd meg mind a 4 fájlt, és a második sorban írd át: `namespace AutoKonzol` → **`namespace AutoGUI`**.
4. Az `Auto.cs`-be, a `ToString()` alá másold be ezt a két metódust:

```csharp
public string TalalatSor()
{
    return $"{Azonosito}. - {Evjarat} - {Modell} - {KilometeroraAllas} km - {Ar} CAD";
}

public int Kor(int aktualisEv)
{
    return aktualisEv - Evjarat;
}
```

> Ha nincs konzolos projekted, a [Megoldas](Megoldas/) mappából másold ki a 4 fájl tartalmát:
> Add → Class… → név (pl. `Auto.cs`) → az egész tartalmát cseréld le.

---

## 3. lépés – Az adatfájl helye (1 perc)

1. Jobb klikk a projekten → **Open Folder in File Explorer**.
2. Ott hozz létre egy **`forras`** nevű mappát, és másold bele a `carsData.csv`-t.

A kódban az útvonal: `"../../../forras/carsData.csv"` (a program 3 mappával lejjebb fut, a `bin\Debug\net…-windows` mappában).

---

## 4. lépés – Az ablak megrajzolása (10 perc)

**Toolbox:** View → Toolbox (vagy Ctrl+Alt+X). **Properties:** jobb klikk egy vezérlőn → Properties (vagy F4).
A Properties ablak tetején a **(Name)** a vezérlő neve, ezzel hivatkozol rá a kódban. A **Text** a felirat.

Húzd fel a vezérlőket a mintakép szerint, és **mindegyiknek állítsd be a (Name)-et**:

| # | Toolboxból | (Name) | Text / beállítás | Hova |
|---|---|---|---|---|
| 0 | *(maga az ablak: kattints az üres részére)* | – | Text: `Használt autók` | húzd nagyobbra kb. 900×450-re |
| 1 | Label | *(mindegy)* | `Autó gyártók` | bal fent |
| 2 | **ListBox** | **`lbGyartok`** | – | alá, nagyobbra húzva |
| 3 | Label | *(mindegy)* | `Karosszéria típusa` | bal, a lista alatt |
| 4 | **ComboBox** | **`cbKarosszeria`** | DropDownStyle: **DropDownList** | alá |
| 5 | Label | *(mindegy)* | `Váltó típusa` | alá |
| 6 | **ComboBox** | **`cbValto`** | DropDownStyle: **DropDownList** | alá |
| 7 | **GroupBox** | `grpAjtok` | Text: `Ajtók száma` | középen fent |
| 8 | **RadioButton** ×4 | **`rb2`, `rb3`, `rb4`, `rb5`** | Text: `2`, `3`, `4`, `5` | **a GroupBoxon BELÜLRE** húzd! |
| 9 | Label | *(mindegy)* | `Évek száma` | középen |
| 10 | **TextBox** | **`txtKorTol`** | – | alá, keskenyre |
| 11 | Label | *(mindegy)* | `-` | mellé |
| 12 | **TextBox** | **`txtKorIg`** | – | mellé |
| 13 | **Button** | **`btnKereses`** | Text: `Keresés` | középen lent, nagyobbra |
| 14 | Label | *(mindegy)* | `A keresésnek megfelelő autók` | jobb fent |
| 15 | **ListBox** | **`lbTalalatok`** | – | jobb oldalt, nagyra húzva |

> **DropDownList:** így a legördülő listába nem lehet gépelni, csak választani. Nem kötelező, de biztonságosabb.
> **RadioButton a GroupBoxba:** a GroupBox fogja össze őket. Egyszerre csak egy lehet bejelölve a csoportban.

Ellenőrzés: **F5**. Megjelenik az üres ablak a vezérlőkkel? Akkor jó.

---

## 5. lépés – A kód (10 perc)

Az ablakon jobb klikk → **View Code** (vagy F7). Ez a `Form1.cs`. A teljes kész kód: [Megoldas/Form1.cs](Megoldas/Form1.cs). Részenként:

### 5/a – usingok a fájl tetejére

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
```

### 5/b – a lista és a konstruktor

```csharp
public partial class Form1 : Form
{
    List<Auto> autok = new List<Auto>();      // az összes autó; minden metódus látja

    public Form1()
    {
        InitializeComponent();                // MINDIG az első!
        this.Load += Form1_Load;              // ablak megnyitásakor
        btnKereses.Click += BtnKereses_Click; // gombnyomáskor
    }
```

> A `+=` után ha begépeled a nevet, és a VS aláhúzza (mert még nincs ilyen metódus),
> kattints rá → **Ctrl + .** → **Generate method**. A VS megírja a metódus vázát.

### 5/c – beolvasás

```csharp
    private void Beolvasas()
    {
        foreach (string sor in File.ReadAllLines("../../../forras/carsData.csv").Skip(1))
        {
            autok.Add(new Auto(sor));
        }
    }
```

### 5/d – betöltéskor (11–15. feladat)

Másold ki a [Megoldas/Form1.cs](Megoldas/Form1.cs) `Form1_Load` metódusát. Benne sorban:
- `Beolvasas();`
- gyártók: `Distinct()` → `lbGyartok.Items.Add(...)` → `lbGyartok.SelectedIndex = 0;`
- karosszériák, váltók → `SelectedIndex = -1;` (= nincs kiválasztva)
- rádiógombok `Checked = false`, és `this.ActiveControl = lbGyartok;` (különben az első rádiógomb magától bejelölődik!)
- `txtKorTol.Text = ""; txtKorIg.Text = "";`

Ellenőrzés: **F5**. Megjelennek a gyártók, az első ki van jelölve, a legördülők üresek?

### 5/e – Keresés gomb (16–17. feladat)

Másold ki a `BtnKereses_Click` metódust. Benne sorban:
1. `lbTalalatok.Items.Clear();`: régi találatok törlése
2. ellenőrzés: van-e kiválasztva gyártó, karosszéria, váltó → ha nincs: `MessageBox` + `return;`
3. melyik rádiógomb van bejelölve → `ajtok` szám
4. `int.TryParse` a két szövegmezőre → ha nem szám: `MessageBox` + `return;`
5. `Where(...)` minden feltétellel → `lbTalalatok.Items.Add(a.TalalatSor());`

---

## 6. lépés – Kipróbálás (2 perc)

| Mit csinálsz | Mit kell látnod |
|---|---|
| Elindítod (F5) | gyártók a listában, az első kijelölve; legördülők üresek; rádiógombok üresek |
| Keresés úgy, hogy semmi nincs kiválasztva | hibaüzenet, a program NEM áll le |
| Lamborghini, Coupe, 7 Speed Automatic, 2, `0` – `6`, Keresés | 5 találat (lásd [FELADAT.md](FELADAT.md)) |
| Újra Keresés | a lista nem duplázódik |

---

## 7. lépés – Leadás

Mentés (Ctrl+Shift+S), majd a **teljes projektmappát** (`AutoGUI`) másold a **MEGOLDÁS** mappába.
