# GUI – Windows Forms (C#)

> **Először:** ha a GUI még idegen, olvasd el a [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md)-t (5 perc).

## A vizsga GUI-része lépésről lépésre

A tanárotok 8 mintafeladata (Auto, Paralimpia, Várak, Pizza, Menhely, Laptops, Fesztivál, Éremtábla) mind ugyanezt a 6 lépést kéri, csak más adatokkal:

| # | Lépés | Tipikus feladatszöveg | Idő | Hol a kód |
|---|---|---|---|---|
| 1 | **Projekt + osztály + beolvasás** | „Készítsen grafikus alkalmazást … néven! … olvassa be…” | 5 perc | [01](1_TECHNIKAK/01_Projekt_es_osztaly.md), gyorsindító **[A]** |
| 2 | **Ablak megrajzolása** | „Készítse el a statikus részeit a mintához hasonló elrendezésben!” | 10 perc | [02](1_TECHNIKAK/02_Designer_hasznalata.md) |
| 3 | **Betöltéskor feltöltés** | „Az alkalmazás betöltésekor jelenjen meg…” | 5 perc | [04](1_TECHNIKAK/04_Betoltes_Load.md), **[B] [C] [E]** |
| 4 | **Kiválasztáskor részletek** | „Ha kiválasztunk / kijelölünk egy…, jelenjen meg…” | 5 perc | [08](1_TECHNIKAK/08_Reszletek_Labelbe.md), **[D]** |
| 5 | **Szűrés** | „Ha gépelünk…”, „Ha bejelöljük…”, „csak azok jelenjenek meg…” | 10 perc | [09](1_TECHNIKAK/09_Szures_gepelesre.md), [10](1_TECHNIKAK/10_CheckBox_RadioButton.md), **[F] [G]** |
| 6 | **Gomb → megerősítés → fájlba** | „A gombra kattintva… megerősítő üzenetablak… írja ki a … fájlba” | 10 perc | [12](1_TECHNIKAK/12_MessageBox.md), [13](1_TECHNIKAK/13_Fajlba_iras_hozzafuzes.md), **[H] [I]** |

> **Részpontok számítanak!** Ha a 2–3. lépés megvan (ablak + betöltés), az már pont. Ne hagyd üresen.
> Mindig futtasd (F5) egy-egy lépés után, hogy hamar kiderüljön, ha valami nem jó.

---

## KERESŐTÁBLA: mit kér a feladat → hol a kód

| Ha ezt kéri a feladat… | Vezérlő / esemény | Gyorsindító | Technika |
|---|---|---|---|
| „Készítsen grafikus alkalmazást … néven” | Windows Forms App | | [01](1_TECHNIKAK/01_Projekt_es_osztaly.md) |
| „…a mintához hasonló elrendezésben” | Designer, Toolbox, (Name), Text | | [02](1_TECHNIKAK/02_Designer_hasznalata.md) |
| bármilyen esemény bekötése | `+=` a konstruktorban | | [03](1_TECHNIKAK/03_Esemenyek_bekotese.md) |
| „Az alkalmazás betöltésekor…” | `Load` | [A] | [04](1_TECHNIKAK/04_Betoltes_Load.md) |
| „…jelenjen meg a listában” | `ListBox.Items.Add` | [B] | [05](1_TECHNIKAK/05_ListBox.md) |
| „…az első elem legyen kiválasztva” | `SelectedIndex = 0` | [B] | [05](1_TECHNIKAK/05_ListBox.md) |
| „…a legördülő listában”, „mindegyik csak egyszer” | `ComboBox` + `Distinct` | [C] | [06](1_TECHNIKAK/06_ComboBox.md) |
| „…ne legyen kiválasztva semmi” | `SelectedIndex = -1` | [C] | [06](1_TECHNIKAK/06_ComboBox.md) |
| „…az adatrácsban / táblázatban” | `DataGridView.Rows.Add` | [E] | [07](1_TECHNIKAK/07_DataGridView.md) |
| „Ha kijelöljük az adatrácsban egy sort…” | `CellClick` | [E] | [07](1_TECHNIKAK/07_DataGridView.md) |
| „Ha kiválasztunk egy elemet, jelenjen meg…” | `SelectedIndexChanged` → Label | [D] | [08](1_TECHNIKAK/08_Reszletek_Labelbe.md) |
| „…a jobb oldali szövegdobozban” (többsoros) | `RichTextBox` | [D] | [08](1_TECHNIKAK/08_Reszletek_Labelbe.md) |
| „Ha a beviteli mezőbe gépelünk…” | `TextChanged` + `StartsWith` / `Contains` | [F] | [09](1_TECHNIKAK/09_Szures_gepelesre.md) |
| „Ha bejelöljük a … jelölőnégyzetet” | `CheckBox.CheckedChanged` | [G] | [10](1_TECHNIKAK/10_CheckBox_RadioButton.md) |
| „…rádiógombok, egyik se legyen bejelölve” | `RadioButton.Checked = false` | [G] | [10](1_TECHNIKAK/10_CheckBox_RadioButton.md) |
| „A gombra kattintva…” | `Click` | [H] | [03](1_TECHNIKAK/03_Esemenyek_bekotese.md) |
| szám a szövegmezőből, „ha nem szám, hibaüzenet” | `int.TryParse`, `NumericUpDown` | [H] | [11](1_TECHNIKAK/11_Szam_bevitel_ellenorzes.md) |
| „…üzenetablak”, „megerősítés”, „Igen/Nem” | `MessageBox.Show(..., YesNo)` | [I] | [12](1_TECHNIKAK/12_MessageBox.md) |
| „…írja ki a … fájlba”, „…a további javaslatok is” | `StreamWriter(fájl, true)` | [I] | [13](1_TECHNIKAK/13_Fajlba_iras_hozzafuzes.md) |
| „A sor elejére a rendszeridőt írja” | `DateTime.Now` | [I] | [13](1_TECHNIKAK/13_Fajlba_iras_hozzafuzes.md) |
| „kosár”, „részösszeg”, „végösszeg”, „szállítási díj” | összeg változóban + Label | [J] | [14](1_TECHNIKAK/14_Szamolas_kosar_osszeg.md) |
| „…majd az alkalmazás záródjon be” | `Application.Exit()` | [K] | [12](1_TECHNIKAK/12_MessageBox.md) |
| Hiba: nem találja a fájlt, rossz elemet választ ki, kétszer fut le… | | | [15](1_TECHNIKAK/15_Buktatok.md) |

---

## A mappák

| Mappa | Mi van benne | Mikor nyisd meg |
|---|---|---|
| [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md) | Designer vs. kód, (Name), Text, események | **először** |
| [0_GYORSINDITO](0_GYORSINDITO/) | Kész Form, minden gyakori vezérlő bekötve, blokkok [A]–[K] | vizsgán, ebből másolsz |
| [1_TECHNIKAK](1_TECHNIKAK/) | 15 fájl, mindegyik egy dolog: Designer-lépés + kód + gyakori hiba | ha egy konkrét dolog nem jut eszedbe |
| [2_GYAKORLO_FELADATOK](2_GYAKORLO_FELADATOK/) | teljes feladatok `LEPESROL_LEPESRE.md`-vel | gyakorláshoz |

### A gyakorlófeladatok

| Mappa | Mintája | Fő témák |
|---|---|---|
| [01_AutokGUI](2_GYAKORLO_FELADATOK/01_AutokGUI/) | **a te vizsgád** | ListBox, ComboBox, RadioButton, TextBox-számok, keresés gombra |
| [02_ErmekGUI](2_GYAKORLO_FELADATOK/02_ErmekGUI/) | Paralimpia, Éremtábla | DataGridView, szűrés gépelésre, sor kijelölése, javaslat fájlba |
| [03_RendelesGUI](2_GYAKORLO_FELADATOK/03_RendelesGUI/) | Pizza | CheckBox-szűrés, kosár, végösszeg, rendelés megerősítése |
| [04_ReszletekGUI](2_GYAKORLO_FELADATOK/04_ReszletekGUI/) | Menhely, Laptops, Várak | ComboBox-szűrés, részletek címkékben, Igen/Nem, fájlba írás |

> A megoldások Linuxon, Mono alatt le vannak fordítva és ki vannak próbálva (a képek onnan vannak),
> de a valódi célgép a Windows: gyakorláskor egyszer indítsd el őket a saját gépeden is.
