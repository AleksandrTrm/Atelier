use [is1-26-tremasovad_db]

CREATE TABLE Sizes(
size_id INT PRIMARY KEY IDENTITY,
size_text nVarChar(7)
);

CREATE TABLE Colors(
color_id INT PRIMARY KEY IDENTITY,
color_text nVarChar(20)
);

CREATE TABLE Materials(
material_id INT PRIMARY KEY IDENTITY,
material_text nVarChar(50)
);

CREATE TABLE Models(
model_id INT PRIMARY KEY IDENTITY,
size INT FOREIGN KEY (size) REFERENCES Sizes(size_id),
color INT FOREIGN KEY (color) REFERENCES Colors(color_id),
material INT FOREIGN KEY (material) REFERENCES Materials(material_id)
);

CREATE TABLE Clients(
client_id INT PRIMARY KEY IDENTITY,
client_name nVarChar(50),
client_surname nVarChar(100),
client_phone nVarChar(11)
);

CREATE TABLE Orders(
order_id INT PRIMARY KEY IDENTITY,
date_of_order DATE,
prepaid_expense FLOAT(2),
total_cost FLOAT(2),
model INT FOREIGN KEY (model) REFERENCES Models(model_id),
client INT FOREIGN KEY (client) REFERENCES Clients(client_id)
);

CREATE TABLE Fittings(
fitting_id INT PRIMARY KEY IDENTITY,
fitting_date DATE,
order_id INT FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);