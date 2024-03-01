// ������������� ������ main �� pagination.js
import { mainAsync } from "./pagination.js";
// URL � ����������� API �������
const url = "https://localhost:7053/Chats/response-time-report?Distribution=day&Filters.From=2024-01-01&Filters.To=2024-01-14";
// ����� ����� �� ����� �������� � ��������
let rowCount = 7;
// ������ ������ mainAsync ����� ���� HTML �������� ���������� � ��������� �������
document.addEventListener("DOMContentLoaded", async () => {
    await mainAsync(url, rowCount);
});