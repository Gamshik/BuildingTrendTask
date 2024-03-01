const url = "https://localhost:7053/Chats/total-chats-report?Distribution=day&Filters.From=2024-01-01&Filters.To=2024-01-14";

let data = [];
let records;

document.addEventListener("DOMContentLoaded", async () => {
    await getData();
    drawingTable();
});


async function getData() {
    try {
        const response = await fetch(url);  
        if (response.ok) {
            data = await response.json();
            records = data.Records;
        } else {
            console.error("Network response was not ok.");
        }
    } catch (error) {
        console.error("An error occurred:", error);
    }
}

function drawingTable() {
    let container = document.getElementById("table");

    let table = document.createElement("table");

    let tableRow = document.createElement("tr");

    let tableHeader = document.createElement("th");
    tableHeader.innerText = "Date"
    tableRow.appendChild(tableHeader);

    tableHeader = document.createElement("th");
    tableHeader.innerText = "Total"
    tableRow.appendChild(tableHeader);

    table.appendChild(tableRow);

    for (const date in records) {
        let tableRow = document.createElement("tr");

        let tableCell = document.createElement("td");
        tableCell.innerText = date;
        tableRow.appendChild(tableCell);

        tableCell = document.createElement("td");
        tableCell.innerText = records[date].Total; 
        tableRow.appendChild(tableCell);

        table.appendChild(tableRow); 
    }

    tableRow = document.createElement("tr");

    let tableCell = document.createElement("td");
    tableCell.innerText = "TOTAL";
    tableRow.appendChild(tableCell);

    tableCell = document.createElement("td");
    tableCell.innerText = data.Total;
    tableRow.appendChild(tableCell);

    table.appendChild(tableRow); 

    container.appendChild(table)
}