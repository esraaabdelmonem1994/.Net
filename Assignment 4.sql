CREATE DATABASE DB_Assignment4;
USE DB_Assignment4;

-- create a table Employees with columns: Id, FirstName, LastName, Salary.
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Salary MONEY
)

--1- Create a stored procedure named GetAllEmployees that selects all rows from Employees
GO
CREATE PROC GetAllEmployees
WITH ENCRYPTION
AS
	SELECT * 
	FROM Employees;

	--TO RUN THE SP
EXEC GetAllEmployees;

--2- Create a stored procedure GetHighSalaryEmployees with one input parameter @MinSalary which Select all employees with Salary > @MinSalary
GO
CREATE PROC GetHighSalaryEmployees @MinSalary MONEY
WITH ENCRYPTION
AS
Select * 
FROM Employees 
WHERE Salary > @MinSalary;

DECLARE @MinSlry MONEY=1000;
EXEC GetHighSalaryEmployees  @MinSlry;
--OR
EXEC GetHighSalaryEmployees 1000;

--3- Create AddEmployee SP with @FirstName, @LastName, @Salary which Insert a new row into Employees. 
GO
CREATE PROC AddEmployee @FirstName VARCHAR(50), @LastName VARCHAR(50), @Salary MONEY
WITH ENCRYPTION
AS
INSERT INTO Employees(FirstName ,LastName ,Salary)
VALUES(@FirstName, @LastName, @Salary);

DECLARE @FName VARCHAR(50) = 'Mohamed',@LName VARCHAR(50) = 'Ahmed', @Slry MONEY=5000;
EXEC AddEmployee  @FName, @LName, @Slry;
--OR
EXEC AddEmployee  'Esraa', 'Abd Elmonem', 3000;


--part 2 :
--Create a table EmployeeLog(Id, EmployeeId, Action, ActionDate).
CREATE TABLE EmployeeLog(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT REFERENCES Employees(Id), -- I assumed that it's FK for Employees table
	Action VARCHAR(50),
	ActionDate DATE
)

--create AFTER INSERT Trigger which Automatically log when a new employee is added.  
GO
CREATE TRIGGER TR_LogNewEmployee
ON Employees
AFTER INSERT
AS
INSERT INTO EmployeeLog (EmployeeId, Action, ActionDate )
SELECT Id, 'Employee Added', GETDATE()
FROM inserted;

--To test this trigger "TR_LogNewEmployee"
INSERT INTO Employees(FirstName ,LastName ,Salary)
VALUES('Tota', 'Mohamed', 10000);
-- OR
EXEC AddEmployee 'Sara', 'Omar', 7000;

--To make sure that log has been happened
SELECT * from EmployeeLog;

