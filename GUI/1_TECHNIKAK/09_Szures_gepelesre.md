# 09 – Szűrés gépelésre (TextChanged)

**Mikor kell?** „Ha a szöveges beviteli mezőbe gépelünk, a lista / adatrács csak azokat tartalmazza, ahol…”

## A kód

```csharp
// konstruktorban:
txtSzuro.TextChanged += TxtSzuro_TextChanged;

private void TxtSzuro_TextChanged(object sender, EventArgs e)
{
    string minta = txtSzuro.Text.ToLower();      // kisbetűsre: a kis/nagybetű ne számítson

    List<Paralimpia> talalatok = adatok
        .Where(p => p.Orszag.ToLower().StartsWith(minta)
                 || p.Varos.ToLower().StartsWith(minta))
        .ToList();

    TablaFeltoltes(talalatok);                   // ugyanaz a metódus, mint a betöltésnél
}
```

> Az esemény **minden leütésnél** lefut: „B” → „Bu” → „Bud”… Üres mezőnél a `StartsWith("")` mindenre igaz → újra minden megjelenik. Jó így.

## Olvasd el pontosan, mit kér a feladat!

| Feladatszöveg | Kód |
|---|---|
| „…a mező tartalmával **kezdődik**” | `.StartsWith(minta)` |
| „…**tartalmazza** a mező tartalmát” | `.Contains(minta)` |
| „…**megegyezik** a mező tartalmával” | `== minta` |
| „…az ország **vagy** a város…” | `\|\|` |
| „…az ország **és** a város…” | `&&` |

> ⚠️ A ParalimpiaGUI repó megoldása `Contains`-t használ, de a feladat „kezdődik”-et kér, vagyis `StartsWith` kell.

## ListBoxszal ugyanígy

```csharp
lbKutyak.Items.Clear();
foreach (Kutya k in kutyak.Where(k => k.Nev.ToLower().StartsWith(minta)))
{
    lbKutyak.Items.Add(k);
}
```

## Szám szerinti szűrés gépelésre

```csharp
int max;
if (int.TryParse(txtMaxAr.Text, out max))
    TablaFeltoltes(adatok.Where(a => a.Ar <= max).ToList());
else
    TablaFeltoltes(adatok);        // nem szám vagy üres -> mindent mutat
```

**Élesben:** [02_ErmekGUI](../2_GYAKORLO_FELADATOK/02_ErmekGUI/Megoldas/Form1.cs)
