-- Bs"d
-- Only by Hashem we do & succeed!!!
--   Create DB called 'FinalProject'
--CREATE DATABASE FinalProject
--;

----------------------------------- Does it works ??? -----------------------------------
 -- Yes, it works well!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

USE FinalProject
;
----   Craete table called 'employees'
--CREATE TABLE employees(
--employeeNumber INT IDENTITY(1,1) NOT NULL,
--employeeId NVARCHAR(9) NOT NULL,
--firstName NVARCHAR(15) NOT NULL,
--lastName NVARCHAR(25) NOT NULL,
--dateAdded DATETIME NOT NULL,
--numUploadedProfiles INT NOT NULL
--CONSTRAINT [PK_employees] PRIMARY KEY (employeeNumber ASC) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
--CONSTRAINT [UQ_employees] UNIQUE  (employeeId)
--)
--;
--
----   Craete table called 'activities'
--CREATE TABLE activities(
--activityId INT IDENTITY(1,1) NOT NULL,
--employeeNumber INT NOT NULL,
--activityDate DATETIME NOT NULL,
--activityStatus BIT NOT NULL
--CONSTRAINT [PK_activities] PRIMARY KEY (activityId ASC) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
--CONSTRAINT [FK_activities] FOREIGN KEY (employeeNumber) REFERENCES employees(employeeNumber)
--)
--;
--
----   Craete table called 'uploadedProfiles'
--CREATE TABLE uploadedProfiles(
--uploadedProfileNumber NVARCHAR(100) NOT NULL,
--employeeNumber INT NOT NULL,
--CONSTRAINT [PK_uploadedProfiles] PRIMARY KEY (uploadedProfileNumber) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
--CONSTRAINT [FK_uploadedProfiles] FOREIGN KEY (employeeNumber) REFERENCES employees(employeeNumber)
--)
--;


--CREATE PROCEDURE sampleProcedure
--AS
--BEGIN
--SELECT * 
--FROM employees
--END
--GO
--;


--   Trigger for cnt++ after insert a recors into 'uploadedProfiles' table
--CREATE TRIGGER increaseNumUploadedProfiles ON uploadedProfiles
--AFTER INSERT
--AS
--BEGIN
--UPDATE employees 
--SET numUploadedProfiles = 1 + (SELECT numUploadedProfiles 
--                               FROM employees e
--	                           WHERE e.employeeNumber = employees.employeeNumber)  
--WHERE employeeNumber = (SELECT employeeNumber FROM inserted)
--END
--GO
--;




--   Is current employeeId exists?
--SELECT (CASE WHEN '012345678' IN (SELECT employeeId FROM employees) THEN 1 ELSE 0 END) AS isExist
--;

SELECT * FROM employees
;

;

SELECT * FROM uploadedProfiles u WHERE u.uploadedProfileNumber = '940584be-9dd7-4093-afe8-61f726f46a63'

SELECT LEN(lastName) FROM employees WHERE employeeNumber = 46
;

UPDATE employees
SET numUploadedProfiles = 0

SELECT * FROM uploadedProfiles
;

SELECT * FROM activities 
where MONTH(activityDate) = 11;
