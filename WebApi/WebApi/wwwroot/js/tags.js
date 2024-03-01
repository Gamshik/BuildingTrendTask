// URL � ����������� API �������
const url = "https://localhost:7053/Chats/tags-report?Distribution=day&Filters.From=2024-01-01&Filters.To=2024-01-14";
// ������ �� ������� � ������� JSON
let data = [];
// ������ ������� "records" �� �������
let records;
// ������ ���� �������
let arrayRecords = [];
// ����� ������ ������
let recordKeys = [];
// ������� ��������
let currentPage = 1;
// ���������� ����� �� ����� ��������
let rowCount = 7;
// ���������� �������
let countColumns;
// ������ ������� ��������� � ��������� ������ ����� ���� HTML �������� ���������� � ��������� �������
document.addEventListener("DOMContentLoaded", async () => {
    await getData(url);
    diaplayTable(1, rowCount);
    displayPagination(Object.keys(records).length, rowCount);
});
// ��������� ������ �� �������
async function getData(url) {
    try {
        const response = await fetch(url);
        if (response.ok) {
            data = await response.json();
            records = data["Records"];
            // ��������� �������� records � ������, ��� �������� ������
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
// ��������� �������
function diaplayTable(currentPage, rows) {
    // �������� ���������� �������� ��� �����������
    let start = (currentPage - 1) * rows;
    // ������ ��������� ��������
    let end = start + rows;
    // ��������, ����� �������� �� ����� �� ����� �������
    if (end > recordKeys.length) {
        end = recordKeys.length;
    }
    // ������ ���������� ������ ��� ������ ������
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
    // ���������� ������� �������
    for (const date in sliceArrayRecords) {
        // ������ �� ������� ������������ ��� ��������� � ��������� �������
        for (const user in sliceArrayRecords[date]) {
            let tableRow = document.createElement("tr");

            let tableCell = document.createElement("td");
            tableCell.innerText = date;
            tableRow.appendChild(tableCell);

            tableCell = document.createElement("td");
            tableCell.innerText = user;
            tableRow.appendChild(tableCell);

            tableCell = document.createElement("td");
            // ������������� ������ ����������� � ����������� ���� � ����������� ������������
            tableCell.innerText = sliceArrayRecords[date][user];
            tableRow.appendChild(tableCell);

            table.appendChild(tableRow);
        }
    }
    // ���������� � ������� footer �� ��������� total, ���� ������� ��������� �������
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
// ����������� ������ ������
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
// �������� ������
function createPaginationBtn(page, rows) {
    const liElement = document.createElement("li");
    liElement.classList.add('paginationItem');
    liElement.innerText = page;

    if (currentPage == page) liElement.classList.add('paginationActive');
    // ���������� ��������� �������
    liElement.addEventListener("click", () => {
        currentPage = page;
        diaplayTable(currentPage, rows);

        let currentItemLi = document.querySelector('li.paginationActive');
        currentItemLi.classList.remove('paginationActive');
        liElement.classList.add('paginationActive');
    })

    return liElement;
}