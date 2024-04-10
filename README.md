# BuildingTrendTask

## Задание

Создать приложение на asp net. Приложение должно получать данные по API при запросе страницы (когда пользователь переходит на страницу).
В проекте должна быть главная страница с проектами (например: project1, project2… ), при переходе на страницу любого проекта должна быть навигация (table, nav1,nav2,nav3).
При нажатии на кнопку table  должна выводиться таблица с данными из API запросов, данные должны выводиться по неделям.

## Docker (пояснения)

Image проекта размещён на docker hub - https://hub.docker.com/repository/docker/gamshikk/buildtrend/general
При настройке контейнера необходимо указать порт - 8080.
Для перехода на главную страницу в строке браузера введите следующуй URL:
http://localhost:8080/index.html
