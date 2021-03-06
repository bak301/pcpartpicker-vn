/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[cpu]
      ,[motherboard]
      ,[memory]
      ,[gpu]
      ,[storage]
      ,[powersupply]
      ,[pccase]
      ,[buildname]
      ,[builddate]
  FROM [PcPartPickerDatabase].[pc].[build]

USE PcPartPickerDatabase

CREATE TABLE pc.[user] 
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstname VARCHAR(20) NOT NULL,
	lastname VARCHAR(20) NOT NULL,
	username VARCHAR(20) NOT NULL UNIQUE,
	email VARCHAR(30) NOT NULL UNIQUE,
	passwordHash CHAR(86) NOT NULL,
	passwordSalt CHAR(86) NOT NULL
);

DROP TABLE pc.[user]
SELECT id, firstname, lastname, username, email, passwordHash, passwordSalt
FROM
    pc.[user]
WHERE 
    username = 'tungvu'
AND
    passwordHash = 'c11083b4b0a7743af748c85d343dfee9fbb8b2576c05f3a7f0d632b0926aadfc'

SELECT id, firstname, lastname, username, email, passwordHash, passwordSalt
FROM
    pc.[user]
WHERE
    username = 'tungvu';