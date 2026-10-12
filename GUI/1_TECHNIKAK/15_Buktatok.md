# 15 – Buktatók (GUI)

## 0. Piros vagy zöld aláhúzás?

**Piros** hullámos vonal = **hiba**: a program nem indul el, javítani kell (a hibalista: View → Error List).
**Zöld** hullámos vonal = **figyelmeztetés** (warning), pl. `object sender` alatt: a program **ugyanúgy fut**, nyugodtan hagyd.

## 1. Szűrés után ROSSZ elem adatai jelennek meg

```csharp
// ROSSZ: a ListBoxban szűrt elemek vannak, de a TELJES listába indexelsz
lblNev.Text = kutyak[lbKutyak.SelectedIndex].Nev;

// JÓ: objektumot teszel a ListBoxba, és azt veszed ki
Kutya k = (Kutya)lbKutyak.SelectedItem;
lblNev.Text = k.Nev;
```

Lásd [05_ListBox](05_ListBox.md). (A MenhelyGUI repó megoldása ebbe a hibába fut bele.)

## 2. NullReferenceException a SelectedItem-nél

Ha semmi nincs kiválasztva (vagy a lista épp ki lett ürítve), a `SelectedItem` **null**. Minden eseménykezelő elejére:

```csharp
if (lbAdatok.SelectedItem == null) return;
```

> Az `Items.Clear()` is elsüti a `SelectedIndexChanged`-et, null kiválasztással!

## 3. A metódus kétszer fut le

Dupla klikk a Designerben **és** `+=` a konstruktorban is → kétszer bekötötted. Csak az egyik kell. Ellenőrzés: `Form1.Designer.cs`-ben keresd a `+= new System.EventHandler(...)` sort.

## 4. Véletlen dupla klikk → üres eseménykezelő

Ha véletlenül duplán kattintottál egy Labelre, lesz egy `label1_Click` metódusod. **Ne töröld csak úgy**, mert a Designer.cs még hivatkozik rá → fordítási hiba. Hagyd üresen, nem árt. (Vagy: Properties → ⚡ → a Click mellől töröld a nevet, és utána a metódust.)

## 5. Nem találja a fájlt

`DirectoryNotFoundException` / `FileNotFoundException` → rossz az útvonal. Lásd [01](01_Projekt_es_osztaly.md): `"../../../forras/fajl.txt"`, és a `forras` mappa a projekt mappájában legyen (ahol a `.csproj` is van).

## 6. A rádiógomb magától bejelölődik induláskor

Az első rádiógomb kapja a fókuszt → bejelölődik. Megoldás a `Load` végén:

```csharp
this.ActiveControl = lbAdatok;   // vagy bármelyik nem-rádiógomb vezérlő
```

## 7. DataGridView: hiba fejlécre / üres sorra kattintáskor

```csharp
if (e.RowIndex < 0) return;                 // fejléc
dgv.AllowUserToAddRows = false;             // nincs üres "új sor" alul
```

## 8. A lista duplázódik

Újratöltés előtt nincs `Items.Clear()` / `Rows.Clear()`. **Minden** feltöltés elé.

## 9. `Text` szöveget vár

```csharp
lblKor.Text = k.Kor;              // HIBA: int nem string
lblKor.Text = k.Kor.ToString();   // JÓ
lblKor.Text = $"{k.Kor} év";      // JÓ
```

## 10. A ParalimpiaGUI-ban `Contains` van `StartsWith` helyett

A feladat szerint „**kezdődik**” → `StartsWith`. Olvasd el pontosan a feladat szövegét!

## 11. A vezérlő nevét nem találja (piros aláhúzás)

A kimásolt kód `lbGyartok`-ot keres, de nálad `listBox1` a neve → Properties → **(Name)** → írd át. Vagy a kódban írd át a nevet.

## 12. „Windows Forms App (.NET Framework)” sablont választottál

Régebbi C#, más projektfájl. Nem tragédia, de a modern szintaxis (pl. `$"..."`) itt is működik. Ha még az elején vagy: hozd létre újra a sima „Windows Forms App” sablonnal.
