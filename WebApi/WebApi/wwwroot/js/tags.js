// URL с параметрами API запроса
const url = "https://localhost:7053/Chats/tags-report?Distribution=day&Filters.From=2024-01-01&Filters.To=2024-01-14";
// Данные из запроса в формате JSON
let data = [];
// Данные объекта "records" из запроса
let records;
// Массив всех записей
let arrayRecords = [];
// Ключи каждой записи
let recordKeys = [];
// Текущая страница
let currentPage = 1;
// Количество строк на одной странице
let rowCount = 7;
// Количество колонок
let countColumns;
// Запуск методов получения и отрисовки данных когда весь HTML документ разработан и загружены скрипты
document.addEventListener("DOMContentLoaded", async () => {
    await getData(url);
    diaplayTable(1, rowCount);
    displayPagination(Object.keys(records).length, rowCount);
});
// Получение данных из запроса
async function getData(url) {
    try {
        const response = await fetch(url);
        if (response.ok) {
            data = await response.json();
            records = data["Records"];
            // Занесение значений records в массив, для удобства работы
            for (const date in records) {
                arrayRecords[date] = records[date];
            }
            recordKeys = Object.keys(arrayRecords);
            countColumns = Object.keys(arrayRecords[recordKeys[0]]).length;
        } else {
            console.error("Network response was not ok.");
        }
    } catch (error) {
        console.error("An error occurred:", error);
    }
}
// Отрисовка таблицы
function diaplayTable(currentPage, rows) {
    // Инледекс начального элемента для отображения
    let start = (currentPage - 1) * rows;
    // Индекс конечного элемента
    let end = start + rows;
    // Проверка, чтобы значение не вышло за рамки массива
    if (end > recordKeys.length) {
        end = recordKeys.length;
    }
    // Массив содержащий нужные для вывода данные
    const sliceArrayRecords = [];

    for (let i = start; i < end; i++) {
        sliceArrayRecords[recordKeys[i]] = arrayRecords[recordKeys[i]];
    }

    let container = document.getElementById("tableData");

    container.innerHTML = " ";

    let table = document.createElement("table");

    let tableRow = document.createElement("tr");

    let tableHeader = document.createElement("th");
    tableHeader.innerText = "Date";
    tableRow.appendChild(tableHeader);

    tableHeader = document.createElement("th");
    tableHeader.innerText = "Name";
    tableRow.appendChild(tableHeader);

    tableHeader = document.createElement("th");
    tableHeader.innerText = "Total";
    tableRow.appendChild(tableHeader);

    table.appendChild(tableRow);
    // Заполнение таблицы данными
    for (const date in sliceArrayRecords) {
        // Проход по каждому пользователю для отрисовки в отдельных строках
        for (const user in sliceArrayRecords[date]) {
            let tableRow = document.createElement("tr");

            let tableCell = document.createElement("td");
            tableCell.innerText = date;
            tableRow.appendChild(tableCell);

            tableCell = document.createElement("td");
            tableCell.innerText = user;
            tableRow.appendChild(tableCell);

            tableCell = document.createElement("td");
            // Инициализация ячейки информацией в определённый день о определённом пользователе
            tableCell.innerText = sliceArrayRecords[date][user];
            tableRow.appendChild(tableCell);

            table.appendChild(tableRow);
        }
    }
    // Добавление в таблицу footer со значением total, если вывелся последний элемент
    if (end == recordKeys.length) {
        let tableFooter = document.createElement("tfoot");

        let tableRow = document.createElement("tr");

        let tableCell = document.createElement("td");
        tableCell.innerText = "TOTAL";
        tableRow.appendChild(tableCell);

        tableCell = document.createElement("td");
        tableCell.innerText = data["Total"];
        tableCell.colSpan = countColumns;
        tableRow.appendChild(tableCell);

        tableFooter.appendChild(tableRow);

        table.appendChild(tableFooter);
    }    

    container.appendChild(table)
}
// Отображение списка кнопок
function displayPagination(arrLenght, rows) {
    const paginationEl = document.getElementById('paginationButton');
    const pagesCount = Math.ceil(arrLenght / rows);

    const ulEl = document.createElement("ul");
    ulEl.classList.add('paginationList');

    for (let i = 0; i < pagesCount; i++) {
        const liEl = createPaginationBtn(i + 1, rows);
        ulEl.appendChild(liEl);
    }

    paginationEl.appendChild(ulEl);
}
// Создание кнопки
function createPaginationBtn(page, rows) {
    const liElement = document.createElement("li");
    liElement.classList.add('paginationItem');
    liElement.innerText = page;

    if (currentPage == page) liElement.classList.add('paginationActive');
    // Добавление обработки события
    liElement.addEventListener("click", () => {
        currentPage = page;
        diaplayTable(currentPage, rows);

        let currentItemLi = document.querySelector('li.paginationActive');
        currentItemLi.classList.remove('paginationActive');
        liElement.classList.add('paginationActive');
    })

    return liElement;
}