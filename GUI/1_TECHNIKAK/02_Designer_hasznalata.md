# 02 – A Designer használata (az ablak megrajzolása)

**Mikor kell?** „Készítse el a grafikus alkalmazás statikus részeit a mintához hasonló elrendezésben!”

## A három ablak, ami kell

| Ablak | Hogyan nyitod meg | Mire jó |
|---|---|---|
| **Designer** | dupla klikk a `Form1.cs`-en (Solution Explorer) | ide rajzolsz |
| **Toolbox** | View → Toolbox (Ctrl+Alt+X) | innen húzod a vezérlőket |
| **Properties** | jobb klikk egy vezérlőn → Properties (F4) | név, felirat, beállítások |

> **Tipp:** a Toolbox tetején van keresőmező, írd be: `listbox`, `button`…

## Egy vezérlő felrakása

1. Toolboxból **húzd** az ablakra (vagy kattints rá, majd kattints az ablakra).
2. **Properties → (Name)**: beszédes név, pl. `lbGyartok`. Ezzel éred el a kódban!
3. **Properties → Text**: a felirat (gombnál, Labelnél, GroupBoxnál, CheckBoxnál).
4. Méret: húzd a sarkát. Hely: fogd meg és húzd.

## Melyik vezérlő mire jó? (a mintakép alapján felismerni)

| A mintaképen ez látszik | Vezérlő | Előtag |
|---|---|---|
| sima szöveg, felirat | **Label** | `lbl` |
| egysoros beviteli mező | **TextBox** | `txt` |
| többsoros szövegdoboz | **RichTextBox** (vagy TextBox `Multiline = True`) | `rtb` |
| gomb | **Button** | `btn` |
| lista, amiből egyet választani lehet | **ListBox** | `lb` |
| legördülő lista (kis nyíl a jobb szélén) | **ComboBox** | `cb` |
| táblázat oszlopfejlécekkel | **DataGridView** | `dgv` |
| négyzet pipával | **CheckBox** | `chk` |
| kör, csoportban csak egy jelölhető | **RadioButton** (GroupBoxban) | `rb` |
| keret felirattal | **GroupBox** | `grp` |
| szám fel/le nyilakkal | **NumericUpDown** | `num` |
| kép | **PictureBox** | `pic` |

## Hasznos beállítások (Properties)

| Vezérlő | Beállítás | Mire jó |
|---|---|---|
| Form (az ablak maga) | **Text** | az ablak címe |
| Form | **StartPosition = CenterScreen** | középen nyílik meg |
| ComboBox | **DropDownStyle = DropDownList** | nem lehet beleírni, csak választani |
| TextBox | **ReadOnly = True** | csak kiírásra, a felhasználó nem írhat bele |
| TextBox | **Multiline = True** | többsoros |
| DataGridView | **ReadOnly = True**, **AllowUserToAddRows = False**, **SelectionMode = FullRowSelect** | lásd [07](07_DataGridView.md) |
| Label | **AutoSize = False** + átméretezés | fix méretű címke (pl. kerettel: BorderStyle) |
| Label / Button | **Font** | betűméret, félkövér (ha a minta ilyen) |

## Igazítás

Ha több vezérlőt kijelölsz (Ctrl + kattintás), a felső menüsorban: **Format → Align → Lefts / Tops**, illetve **Make Same Size**.

> „A mintához **hasonló** elrendezés” kell, nem pixelpontos. Ne tölts vele 10 percnél többet!

## Gyakori hibák

- RadioButtont nem a GroupBox **belsejébe** húztad: akkor nem egy csoportba tartoznak.
- Elfelejtett **(Name)**: marad `listBox1`, és a kimásolt kód (`lbGyartok`) nem találja → piros aláhúzás. Megoldás: nevezd át a Properties-ben.
- Véletlen dupla klikk egy vezérlőn: a VS létrehoz egy üres eseménykezelőt (pl. `label1_Click`). Nem baj, hagyd ott, vagy lásd [15_Buktatok](15_Buktatok.md).

**Élesben:** [01_AutokGUI/LEPESROL_LEPESRE.md](../2_GYAKORLO_FELADATOK/01_AutokGUI/LEPESROL_LEPESRE.md) (4. lépés, táblázattal)
