# 10 – CheckBox és RadioButton

**Mikor kell?** „Ha bejelöljük a … jelölőnégyzetet, csak a … jelenjenek meg”, „A rádiógombok közül induláskor egyik se legyen kijelölve”, „…a kiválasztott ajtószám szerint”

## CheckBox (négyzet pipával, egymástól független)

```csharp
chkVega.Checked          // true, ha be van pipálva
chkVega.Checked = false; // kivesszük a pipát
```

### Szűrés több CheckBox szerint EGYSZERRE

„Ha a vega be van jelölve, csak a vega pizzák; ha a csípős is, akkor csak a vega ÉS csípős pizzák”:

```csharp
// konstruktorban: mindkettő ugyanazt hívja
chkVega.CheckedChanged += Szures_Esemeny;
chkCsipos.CheckedChanged += Szures_Esemeny;

private void Szures_Esemeny(object sender, EventArgs e)
{
    Szures();
}

private void Szures()
{
    lbPizzak.Items.Clear();
    foreach (Pizza p in pizzak.Where(p => (!chkVega.Checked || p.Vega)
                                       && (!chkCsipos.Checked || p.Csipos)))
    {
        lbPizzak.Items.Add(p);
    }
}
```

> **A trükk:** `(!chkVega.Checked || p.Vega)` jelentése: „ha nincs bepipálva, mindegy; ha be van, akkor legyen vega”.

## RadioButton (kör, csoportban csak EGY jelölhető)

**Designer:** húzz fel egy **GroupBox**-ot, és a rádiógombokat a **belsejébe**. Egy GroupBoxon belül csak egy lehet bejelölve.

### Melyik van bejelölve?

```csharp
int ajtok = 0;
if (rb2.Checked) ajtok = 2;
else if (rb3.Checked) ajtok = 3;
else if (rb4.Checked) ajtok = 4;
else if (rb5.Checked) ajtok = 5;

if (ajtok == 0)
{
    MessageBox.Show("Válassza ki az ajtók számát!");
    return;
}
```

Rövidebben, ha a gombok felirata maga a szám:

```csharp
RadioButton bejelolt = grpAjtok.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
if (bejelolt == null) { MessageBox.Show("Válasszon!"); return; }
int ajtok = int.Parse(bejelolt.Text);
```

### Induláskor egyik se legyen bejelölve

```csharp
rb2.Checked = false;
rb3.Checked = false;
rb4.Checked = false;
rb5.Checked = false;
this.ActiveControl = lbGyartok;     // ⚠️ fontos, lásd lent
```

> ⚠️ **Buktató:** ha induláskor egy rádiógomb kapja a **fókuszt** (mert az a legkisebb TabIndexű), a Windows **automatikusan bejelöli**. Ezért a fókuszt egy másik vezérlőre tesszük: `this.ActiveControl = ...`.

### Azonnali szűrés rádiógombra

```csharp
rbMind.CheckedChanged += Szures_Esemeny;
rbVega.CheckedChanged += Szures_Esemeny;
```

> A `CheckedChanged` kétszer fut le váltáskor: a régi kikapcsolásakor és az új bekapcsolásakor. Szűrésnél ez nem baj (a második futás a jó).

**Élesben:** [01_AutokGUI](../2_GYAKORLO_FELADATOK/01_AutokGUI/Megoldas/Form1.cs) (RadioButton), [03_RendelesGUI](../2_GYAKORLO_FELADATOK/03_RendelesGUI/Megoldas/Form1.cs) (CheckBox-szűrés)
