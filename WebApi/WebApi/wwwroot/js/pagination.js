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
// Количество колонок
let countColumns;
// Асинхронный метод для экспорта, который запускает операцию получения даннхы и отрисовку таблицы
export async function mainAsync(url, rows) {
    await getData(url);
    diaplayTable(1, rows);
    displayPagination(Object.keys(records).length, rows);
};
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
    // Наименование колонок по наименованию полей
    for (const field in arrayRecords[recordKeys[0]]) {
        tableHeader = document.createElement("th");
        tableHeader.innerText = field;
        tableRow.appendChild(tableHeader);
    }

    table.appendChild(tableRow);
    // Заполнение таблицы данными
    for (const date in sliceArrayRecords) {
        let tableRow = document.createElement("tr");

        let tableCell = document.createElement("td");
        tableCell.innerText = date;
        tableRow.appendChild(tableCell);
        // Ключи для каждого поля
        let dateKey = Object.keys(sliceArrayRecords[date]);

        for (const key in dateKey) {
            tableCell = document.createElement("td");
            // Инициализция значения ячейки таблицы информацией за определённую дату 
            tableCell.innerText = sliceArrayRecords[date][dateKey[key]];
            tableRow.appendChild(tableCell);
        }

        table.appendChild(tableRow);
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