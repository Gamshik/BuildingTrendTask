// Импортировние метода main из pagination.js
import { mainAsync } from "./pagination.js";
// URL с параметрами API запроса
const url = "https://localhost:7053/Chats/response-time-report?Distribution=day&Filters.From=2024-01-01&Filters.To=2024-01-14";
// Число строк на одной странице с таблицей
let rowCount = 7;
// Запуск метода mainAsync когда весь HTML документ разработан и загружены скрипты
document.addEventListener("DOMContentLoaded", async () => {
    await mainAsync(url, rowCount);
});