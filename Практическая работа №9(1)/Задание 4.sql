use [is1-26-tremasovad_db]

--1
SELECT Models.model_title, Sizes.size_text
FROM Orders, Models, Sizes
WHERE Models.size = Sizes.size_id AND Models.model_id = Orders.model AND
total_cost > 500

--2
SELECT Clients.client_name, Models.model_title
FROM Clients, Orders, Models
WHERE Clients.client_id = Orders.client AND Models.model_id = Orders.model

--3
SELECT Clients.client_name, Fittings.fitting_date
FROM Clients, Orders, Fittings
WHERE Clients.client_id = Orders.client AND Fittings.order_id = Orders.order_id

--4
SELECT Materials.material_text, Models.model_title, Colors.color_text
FROM Materials, Models, Colors
WHERE Materials.material_id = Models.material AND Models.color = Colors.color_id

--5
SELECT COUNT(Models.model_id) AS 'количество платьев', Orders.total_cost 
FROM Orders, Models
WHERE Orders.model = Models.model_id
GROUP BY (Orders.total_cost)

--6
SELECT Clients.client_name, COUNT(Fittings.fitting_date) AS 'количество примерок'
FROM Clients, Orders, Fittings
WHERE Clients.client_id = Orders.client AND Fittings.order_id = Orders.order_id
GROUP BY (Clients.client_name)

--7
SELECT Models.model_title AS '»м€ модели', COUNT(Sizes.size_id) AS ' оличество размеров'
FROM Models, Sizes
WHERE Models.size = Sizes.size_id
GROUP BY Models.model_title