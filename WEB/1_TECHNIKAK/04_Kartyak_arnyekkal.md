# 04 – Kártyák árnyékkal, középre igazítva

**Mikor kell?** „3 információs kártya … a kártyák legyenek árnyékoltak, középre igazítottak”

## HTML

```html
<section class="info">
    <div class="info-kartya">
        <img src="images/icons/gallery.png" alt="">
        <h2>Modern kiállítások</h2>
        <p>Fedezd fel legújabb időszaki és állandó kiállításainkat.</p>
    </div>
    <!-- még 2 ugyanilyen -->
</section>
```

## CSS

```css
.info {
    display: grid;
    grid-template-columns: 1fr;          /* mobil: egymás alatt (lásd 05) */
    gap: 20px;                           /* távolság a kártyák között */
    max-width: 1200px;
    margin: 0 auto;                      /* a SOR középre kerül az oldalon */
    padding: 30px 20px;
}

.info-kartya {
    background: #fff;
    border-radius: 10px;                               /* lekerekített sarok */
    box-shadow: 0 6px 20px rgba(0, 0, 0, 0.12);        /* ÁRNYÉK */
    padding: 22px;
    text-align: center;                                /* a szöveg KÖZÉPRE */
}

.info-kartya img {
    display: block;                      /* kell, hogy a margin: auto középre tegye */
    width: 48px;
    margin: 0 auto 10px;                 /* a kép középre */
}
```

## A box-shadow 4 értéke

```
box-shadow:  0      6px     20px     rgba(0, 0, 0, 0.12);
             vízsz. függ.   elmosás  szín (0.12 = 12%-os fekete)
```

## Ikon körben (mint a mintán)

```css
.ikon-kor {
    width: 80px; height: 80px;
    border-radius: 50%;                  /* 50% = kör */
    background: #f6efe4;
    display: flex; align-items: center; justify-content: center;   /* ikon a kör közepén */
    margin: 0 auto 12px;
}
```

## Hover-effekt (ha kéri, vagy szebbnek akarod)

```css
.info-kartya { transition: transform 0.2s; }
.info-kartya:hover { transform: translateY(-4px); }
```

**Élesben:** [01_Galeria/style.css](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/style.css) (3. rész)
