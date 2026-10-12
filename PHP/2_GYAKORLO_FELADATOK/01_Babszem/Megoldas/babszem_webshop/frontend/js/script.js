// A backend végpontjai (a frontend mappából egy szinttel feljebb van a backend mappa)
const API_PRODUCTS = "../backend/termekek.php";
const API_CATEGORIES = "../backend/kategoriak.php";

const productsContainer = document.getElementById("products");
const searchInput = document.getElementById("product-search");
const categoryFilters = document.getElementById("category-filters");
const resultCount = document.getElementById("result-count");
const form = document.getElementById("new-product-form");
const newCategories = document.getElementById("new-categories");
const message = document.getElementById("message");

let products = [];
let categories = [];
let selectedCategoryId = "";

// Üzenet kiírása az admin panel alá
function showMessage(text, isError) {
    message.textContent = text;
    message.className = "message " + (isError ? "error" : "ok");
}

// Segédfüggvény: JSON kérés küldése, a válasz JSON-ját és státuszát adja vissza
async function sendJson(url, method, body) {
    const options = { method: method, headers: { "Content-Type": "application/json" } };
    if (body !== undefined) options.body = JSON.stringify(body);
    const response = await fetch(url, options);
    const data = await response.json();
    return { ok: response.ok, status: response.status, data: data };
}

function renderCategoryFilters() {
    categoryFilters.innerHTML = "";
    const all = [{ id: "", name: "Összes termék" }, ...categories];
    all.forEach(category => {
        const button = document.createElement("button");
        button.className = "category-button";
        button.textContent = category.name;
        button.dataset.categoryId = category.id;
        button.setAttribute("aria-pressed", String(String(category.id) === selectedCategoryId));
        categoryFilters.appendChild(button);
    });
}

function renderCategoryCheckboxes() {
    newCategories.innerHTML = "";
    categories.forEach(category => {
        const label = document.createElement("label");
        label.innerHTML = `<input type="checkbox" value="${category.id}"> `;
        label.append(category.name);
        newCategories.appendChild(label);
    });
}

function createProductCard(product) {
    const card = document.createElement("div");
    card.className = "product-card";
    card.innerHTML = `
        <div class="product-categories"></div>
        <h3></h3>
        <p class="product-description"></p>
        <div class="product-footer">
            <p class="product-price"></p>
            <p class="product-stock"></p>
        </div>
        <div class="product-admin">
            <input type="number" min="0" aria-label="Új készlet">
            <button class="small-button save-stock">Készlet mentése</button>
            <button class="small-button danger delete">Törlés</button>
        </div>
    `;
    const categoryList = card.querySelector(".product-categories");
    product.categories.forEach(category => {
        const tag = document.createElement("p");
        tag.className = "category-tag";
        tag.textContent = category.name;
        categoryList.appendChild(tag);
    });
    card.querySelector("h3").textContent = product.name;
    card.querySelector(".product-description").textContent = product.description || "Nincs leírás.";
    card.querySelector(".product-price").textContent = `${Number(product.price).toLocaleString("hu-HU")} Ft`;
    const stock = card.querySelector(".product-stock");
    stock.textContent = Number(product.stock) > 0 ? `Készleten: ${product.stock} db` : "Jelenleg nem elérhető";
    if (Number(product.stock) === 0) stock.classList.add("out-of-stock");

    const stockInput = card.querySelector(".product-admin input");
    stockInput.value = product.stock;

    // Készlet módosítása: PATCH kérés
    card.querySelector(".save-stock").addEventListener("click", async () => {
        const result = await sendJson(`${API_PRODUCTS}?id=${product.id}`, "PATCH", { stock: Number(stockInput.value) });
        showMessage(result.data.message || result.data.error, !result.ok);
        if (result.ok) loadProducts();
    });

    // Törlés: DELETE kérés
    card.querySelector(".delete").addEventListener("click", async () => {
        if (!confirm(`Biztosan törlöd: ${product.name}?`)) return;
        const result = await sendJson(`${API_PRODUCTS}?id=${product.id}`, "DELETE");
        showMessage(result.data.message || result.data.error, !result.ok);
        if (result.ok) loadProducts();
    });

    return card;
}

function renderProducts() {
    const searchText = searchInput.value.toLowerCase();
    const filtered = products.filter(product => {
        const categoryNames = product.categories.map(c => c.name).join(" ");
        const text = `${product.name} ${product.description} ${categoryNames}`.toLowerCase();
        const matchesSearch = text.includes(searchText);
        const matchesCategory = selectedCategoryId === "" ||
            product.categories.some(c => String(c.id) === selectedCategoryId);
        return matchesSearch && matchesCategory;
    });

    productsContainer.innerHTML = "";
    resultCount.textContent = `${filtered.length} termék`;
    if (filtered.length === 0) {
        productsContainer.innerHTML = "<p class='empty-state'>Nincs ilyen termék.</p>";
        return;
    }
    filtered.forEach(product => productsContainer.appendChild(createProductCard(product)));
}

async function loadProducts() {
    try {
        const response = await fetch(API_PRODUCTS);
        products = await response.json();
        renderProducts();
    } catch (error) {
        console.log("A termékek betöltése sikertelen:", error);
        productsContainer.innerHTML = "<p class='empty-state error-state'>A termékeket most nem sikerült betölteni.</p>";
    }
}

async function loadCategories() {
    try {
        const response = await fetch(API_CATEGORIES);
        categories = await response.json();
        renderCategoryFilters();
        renderCategoryCheckboxes();
    } catch (error) {
        console.log("A kategóriák betöltése sikertelen:", error);
    }
}

searchInput.addEventListener("input", renderProducts);

categoryFilters.addEventListener("click", event => {
    const clicked = event.target.closest("button");
    if (clicked === null) return;
    selectedCategoryId = clicked.dataset.categoryId;
    categoryFilters.querySelectorAll("button").forEach(button => {
        button.setAttribute("aria-pressed", String(button === clicked));
    });
    renderProducts();
});

// Új termék: POST kérés
form.addEventListener("submit", async event => {
    event.preventDefault();
    const checked = [...newCategories.querySelectorAll("input:checked")].map(input => Number(input.value));
    const body = {
        name: document.getElementById("new-name").value,
        description: document.getElementById("new-description").value,
        price: Number(document.getElementById("new-price").value),
        stock: Number(document.getElementById("new-stock").value),
        categories: checked
    };
    const result = await sendJson(API_PRODUCTS, "POST", body);
    showMessage(result.data.message || result.data.error, !result.ok);
    if (result.ok) {
        form.reset();
        loadProducts();
    }
});

loadCategories();
loadProducts();
