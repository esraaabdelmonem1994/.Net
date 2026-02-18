
CREATE DATABASE TEST;
USE TEST;

-- 1.Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
CREATE TABLE Employees (
	ID INT NOT NULL,
	Name VARCHAR(50),
	Salary DEC(16,2)
);

-- 2.Add a new column named "Department" to the "Employees" table with data type varchar(50).

ALTER TABLE Employees
ADD Department VARCHAR(50);

-- 3.Remove the "Salary" column from the "Employees" table.
ALTER TABLE Employees
DROP COLUMN Salary;

-- 4.Rename the "Department" column in the "Employees" table to "DeptName".
EXEC sp_rename 'Employees.Department', 'DeptName', 'COLUMN';

-- 5.Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
CREATE TABLE Projects (
	ProjectID INT PRIMARY KEY IDENTITY(1,1),	--Identity not mentiened but I added it to make a PK
	ProjectName VARCHAR(50) NOT NULL, 
);

-- 6.Add a primary key constraint to the "Employees" table for the "ID" column.
ALTER TABLE Employees
ADD CONSTRAINT PK_Employees_ID PRIMARY KEY(ID);

-- 7.Add a unique constraint to the "Name" column in the "Employees" table.
ALTER TABLE Employees
ADD CONSTRAINT UQ_Employees_Name UNIQUE (Name);

-- 8.Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar), and Email (varchar), and Status (varchar).
CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30),
	LastName VARCHAR(30),
	Email VARCHAR(75),
	Status VARCHAR(20)
)

-- 9.Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
ALTER TABLE Customers
ADD CONSTRAINT UQ_Customers_FirstName_LastName UNIQUE (FirstName, LastName);

-- 10.Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime), and TotalAmount (decimal).
CREATE TABLE Orders (
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT REFERENCES Customers(CustomerID),  --it's not mensioned but I apply as FK
	OrderDate DATETIME,
	TotalAmount DEC(16,4)
);

-- 11.Add a check constraint to the "TotalAmount" column in the "Orders" table to ensure that it is greater than zero.
ALTER TABLE Orders
ADD CONSTRAINT CK_Orders_TotalAmount CHECK (TotalAmount > 0);

-- 12.Create a schema named "Sales" and move the "Orders" table into this schema.
CREATE SCHEMA Sales;

ALTER SCHEMA Sales
TRANSFER Orders;

-- 13.Rename the "Orders" table to "SalesOrders."
EXEC sp_rename 'Sales.Orders', 'SalesOrders';

-----------------------------------------------------------
-- FOR IMAGE

CREATE TABLE actor (
	act_id INT PRIMARY KEY IDENTITY(1,1),
	act_fname CHAR(20),
	act_lname CHAR(20),
	act_gender CHAR(1)
)

CREATE TABLE movie (
	mov_id INT PRIMARY KEY IDENTITY(1,1),
	mov_title CHAR(50),
	mov_year INT,
	mov_time INT,
	mov_lang CHAR(50),
	mov_dt_rel DATE,
	mov_rel_country CHAR(5)
)

CREATE TABLE movie_cast (
	act_id INT REFERENCES actor(act_id),
	mov_id INT REFERENCES movie(mov_id),
	role CHAR(30),
	PRIMARY KEY(act_id, mov_id)
)

CREATE TABLE director (
	dir_id INT PRIMARY KEY IDENTITY(1,1),
	dir_fname CHAR(20),
	dir_lname CHAR(20)
)

CREATE TABLE movie_direction (
	dir_id INT REFERENCES director(dir_id),
	mov_id INT REFERENCES movie(mov_id),
	PRIMARY KEY(dir_id, mov_id)
)

CREATE TABLE genres (
	gen_id INT PRIMARY KEY IDENTITY(1,1),
	gen_title CHAR(20)
)

CREATE TABLE movie_genres (
	mov_id INT REFERENCES  movie(mov_id),
	gen_id INT REFERENCES  genres(gen_id),
	PRIMARY KEY(mov_id, gen_id)
)

CREATE TABLE reviewer (
	rev_id INT PRIMARY KEY IDENTITY(1,1),
	rev_name CHAR(30)
)

CREATE TABLE rating (
	mov_id INT REFERENCES  movie(mov_id),
	rev_id INT REFERENCES  reviewer(rev_id),
	rev_stars INT,
	num_o_ratings INT, 
	PRIMARY KEY(mov_id, rev_id)
)
