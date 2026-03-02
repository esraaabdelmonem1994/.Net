--Assumptions
-- Email is UNIQUE in Patient, and Doctor tables
-- Name, YearOfExperience is Not Null in Patient, Doctor, and PharmaceuticalCompany tables
-- Added ID as a primary key in PharmaceuticalCompany, Drug, and Prescription tables
-- When delete Patient will delete all his/her Prescriptions

CREATE DATABASE BarwonHealth;
USE BarwonHealth;

CREATE TABLE Doctor (
	ID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Email VARCHAR(75) UNIQUE,
	PhoneNumber VARCHAR(20),
	Specialty VARCHAR(75),
	YearOfExperience INT NOT NULL,
)

CREATE TABLE Patient (
	URNumber INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Address VARCHAR(150),
	Age INT NOT NULL,
	Email VARCHAR(75) UNIQUE,
	PhoneNumber VARCHAR(20),
	MedicareCardNumber VARCHAR(50),
	PrimaryDoctorID INT NOT NULL REFERENCES Doctor(ID)
);

CREATE TABLE PharmaceuticalCompany (
	ID INT PRIMARY KEY IDENTITY(1,1), --it's not mentioned but I assume
	Name VARCHAR(50) NOT NULL UNIQUE,
	Address VARCHAR(150),
	PhoneNumber VARCHAR(20)
)

CREATE TABLE Drug (
	ID INT PRIMARY KEY IDENTITY(1,1), --it's not mentioned but I assume
	TradeName VARCHAR(50),
	strength VARCHAR(20),
	CompanyID INT REFERENCES PharmaceuticalCompany(ID) ON DELETE CASCADE
)

CREATE TABLE Prescription (
	ID INT PRIMARY KEY IDENTITY(1,1), --it's not mentioned but I assume
	URNumber INT REFERENCES Patient(URNumber) ON DELETE CASCADE,
	DoctorId INT REFERENCES Doctor(ID),
	DrugId INT REFERENCES Drug(ID),
	Date Date,
	Quantity INT NOT NULL CHECK (Quantity > 0)
)


--1. SELECT: Retrieve all columns from the Doctor table.
SELECT * 
FROM Doctor;

--2. ORDER BY: List patients in the Patient table in ascending order of their ages.
SELECT *
FROM Patient
ORDER BY Age ASC;

--3. OFFSET FETCH: Retrieve the first 10 patients from the Patient table, starting from the 5th record.
SELECT * 
FROM Patient
ORDER BY URNumber
OFFSET 4 ROWS FETCH NEXT 10 ROWS ONLY;

--4. SELECT TOP: Retrieve the top 5 doctors from the Doctor table.
SELECT TOP(5) *
FROM Doctor;

--5. SELECT DISTINCT: Get a list of unique address from the Patient table.
SELECT DISTINCT Address
FROM Patient; 

--6. WHERE: Retrieve patients from the Patient table who are aged 25.
SELECT *
FROM Patient
WHERE Age = 25;

--7. NULL: Retrieve patients from the Patient table whose email is not provided.
SELECT *
FROM Patient
WHERE Email IS NULL;

--8. AND: Retrieve doctors from the Doctor table who have experience greater than 5 years and specialize in 'Cardiology'.
SELECT *
FROM Doctor
WHERE YearOfExperience > 5 AND Specialty = 'Cardiology';

--9. IN: Retrieve doctors from the Doctor table whose speciality is either 'Dermatology' or 'Oncology'.
SELECT *
FROM Doctor
WHERE Specialty IN ('Dermatology', 'Oncology');

--10. BETWEEN: Retrieve patients from the Patient table whose ages are between 18 and 30.
SELECT *
FROM Patient
WHERE Age BETWEEN 18 AND 30;

--11. LIKE: Retrieve doctors from the Doctor table whose names start with 'Dr.'.
SELECT *
FROM Doctor
WHERE Name LIKE('Dr.%');

--12. Column & Table Aliases: Select the name and email of doctors, aliasing them as 'DoctorName' and 'DoctorEmail'.
SELECT Name AS DoctorName, Email AS DoctorEmail
FROM Doctor;

--13. Joins: Retrieve all prescriptions with corresponding patient names.
SELECT P.Name AS PatientName, PR.*
FROM Prescription PR LEFT OUTER JOIN Patient P
ON PR.URNumber = P.URNumber;
--OR--
SELECT P.Name AS PatientName, PR.*
FROM Prescription PR, Patient P
WHERE PR.URNumber = P.URNumber;

--14. GROUP BY: Retrieve the count of patients grouped by their cities.
SELECT Address, COUNT(*) AS PatientCount
FROM Patient
GROUP BY Address; --IN Patient table we have address only not city

--15. HAVING: Retrieve cities with more than 3 patients.
SELECT Address, COUNT(*) AS PatientCount
FROM Patient
GROUP BY Address
HAVING COUNT(*) > 3;

--16. EXISTS: Retrieve patients who have at least one prescription.
SELECT *
FROM Patient P
WHERE EXISTS (
    SELECT 1
    FROM Prescription PR
    WHERE P.URNumber = PR.URNumber
); 

--17. UNION: Retrieve a combined list of doctors and patients.
SELECT *
FROM Doctor 
UNION 
SELECT *
FROM Patient;
--OR we can add aliase to avoid the same name of columns like that 
-- SELECT Name AS PatientName, Address AS PatientAddress, Email AS PatientEmail.....

--18. INSERT: Insert a new doctor into the Doctor table.
INSERT INTO Doctor(Name, Email , PhoneNumber, Specialty, YearOfExperience )
VALUES('Dr.Osama', 'osama@gmail.com', '01283052845', 'Dermatology', 3);

--19. INSERT Multiple Rows: Insert multiple patients into the Patient table.
INSERT INTO Patient(Name, Address, Age, Email,PhoneNumber,MedicareCardNumber, PrimaryDoctorID)
VALUES('Ayman', 'Alex', 25, 'ayman@gmail.com', '01250204845', 'AS123432', 1),
	  ('Hassan', 'Aswan', 40, 'hassan@gmail.com', '01285030251', 'BC123432', 2),
      ('Eman', 'Cairo', 30, 'eman@gmail.com', '01005026984', 'VB123432', 3),
      ('Osama', 'El-Fayoum', 25, 'osama@gmail.com', '012850603215', 'DC123432', 2);

--20. UPDATE: Update the phone number of a doctor.
UPDATE Doctor
SET PhoneNumber = '01286030818'; -- this will update the phone number for all doctors
--OR--
UPDATE Doctor
SET PhoneNumber = '01286030818'
WHERE ID = 1;  --This will update the phone number for the doctor has id =1

--21. UPDATE JOIN: Update the city of patients who have a prescription from a specific doctor.

UPDATE P SET P.Address = 'Alex' 
FROM Patient P, Prescription PR
WHERE P.URNumber = PR.URNumber AND P.PrimaryDoctorID = PR.DoctorId

--22. DELETE: Delete a patient from the Patient table.
DELETE FROM Patient;	-- this will delete all Patients data
--OR--
DELETE FROM Patient WHERE URNumber = 1;	-- this will delete only the patient how has URNumber = 1

--23. Transaction: Insert a new doctor and a patient, ensuring both operations succeed or fail together.
BEGIN TRANSACTION;
BEGIN TRY
    INSERT INTO Doctor ( Name, Email, PhoneNumber, Specialty, YearOfExperience)
    VALUES ('Dr. Mona Adel', 'mona@hospital.com', '0128888888', 'Dermatology', 7);

    INSERT INTO Patient (Name, Address, Age, Email, PhoneNumber, MedicareCardNumber, PrimaryDoctorID )
    VALUES ('Ali Mostafa', 'Cairo', 30, 'ali@email.com', '0103333333', 'MC555', 1);
    
	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
END CATCH;
