# 01 – Projekt létrehozása, osztály átvétele, adatfájl helye

**Mikor kell?** Mindig, az elején. „Készítsen grafikus alkalmazást … néven!”, „Készítsen saját osztályt…”

## Projekt

1. Visual Studio → **Create a new project** → keresőbe: `Windows Forms`
2. **Windows Forms App** (C#) → Next.
   ⚠️ NEM a „(.NET **Framework**)” változatot!
3. Project name: **a feladatban kért név** (pl. `ParalimpiaGUI`) → Next → Create.

## Osztály

**Ha a konzolos részben már megírtad:** jobb klikk a projekten → **Add → Existing Item…** → kiválasztod az osztály `.cs` fájljait → Add.
Utána minden átvett fájlban írd át a `namespace`-t a GUI-projekt nevére:

```csharp
namespace AutoKonzol   →   namespace AutoGUI
```

**Ha új osztály kell:** jobb klikk a projekten → **Add → Class…** → név (pl. `Paralimpia.cs`), és ugyanúgy megírod, mint a CLI-ben (lásd [CLI/1_TECHNIKAK/02](../../CLI/1_TECHNIKAK/02_Osztaly_konstruktor.md)).

> Az osztály elé írj `public`-ot vagy hagyd `internal`-on, mindkettő jó. A lényeg, hogy ugyanabban a `namespace`-ben legyen, mint a `Form1`.

## Az adatfájl helye: a tanárotok módszere

1. Jobb klikk a projekten → **Open Folder in File Explorer**.
2. Hozz létre egy **`forras`** mappát, és másold bele az adatfájlt (pl. `ermek.txt`).
3. A kódban:

```csharp
File.ReadAllLines("../../../forras/ermek.txt")
```

**Miért `../../../`?** A program innen fut: `ProjektMappa\bin\Debug\net10.0-windows\`. Három `..` = három mappát fellépünk → a projekt mappájába.

```
ParalimpiaGUI\                    ← ../../../  ide jutunk
├─ forras\ermek.txt               ← ../../../forras/ermek.txt
└─ bin\Debug\net10.0-windows\      ← innen fut a program
```

**Másik mód:** a fájlt húzd be a Solution Explorerbe → Properties → **Copy to Output Directory: Copy if newer**. Ekkor elég: `File.ReadAllLines("ermek.txt")`.

## Beolvasás

Ugyanaz, mint a konzolban, csak egy metódusba téve, amit a `Load` hív meg (lásd [04](04_Betoltes_Load.md)):

```csharp
List<Paralimpia> adatok = new List<Paralimpia>();   // az osztály szintjén!

private void Beolvasas()
{
    foreach (string sor in File.ReadAllLines("../../../forras/ermek.txt").Skip(1))
    {
        adatok.Add(new Paralimpia(sor));
    }
}
```

> **Fejléc?** Nézd meg a fájl első sorát. Ha **nincs** benne fejléc (mezőnevek), hagyd el a `.Skip(1)`-et.
> **Tabulátor az elválasztó?** A konstruktorban: `sor.Split('\t')`.

## Gyakori hibák

- `DirectoryNotFoundException` / `FileNotFoundException`: rossz az útvonal vagy a fájlnév (kis/nagybetű, `.txt` / `.csv`).
- `namespace` nem egyezik: a Form1 nem „látja” az osztályt (piros aláhúzás az osztály nevén).

**Élesben:** [01_AutokGUI/LEPESROL_LEPESRE.md](../2_GYAKORLO_FELADATOK/01_AutokGUI/LEPESROL_LEPESRE.md) (1–3. lépés)
