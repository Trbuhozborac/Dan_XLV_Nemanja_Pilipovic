IF DB_ID('WarehouseDb') IS NULL
CREATE DATABASE WarehouseDb
GO

USE WarehouseDb
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblProducts')
DROP TABLE tblProducts

CREATE TABLE tblProducts(
Id int PRIMARY KEY IDENTITY(1,1),
Name varchar(30),
Code int,
Quantity int,
Price money,
Stored bit
);