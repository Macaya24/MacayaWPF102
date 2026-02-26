-- Database Setup Script for SmartPhone Management System
-- Run this script to create the database, table, and stored procedures

USE master;
GO

-- Create Database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'sajordb1')
BEGIN
    CREATE DATABASE sajordb1;
END
GO

USE sajordb1;
GO

-- Create SmartPhone Table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmartPhone]') AND type in (N'U'))
BEGIN
    CREATE TABLE SmartPhone (
        SmartPhoneId INT IDENTITY(1,1) PRIMARY KEY,
        Brand NVARCHAR(100) NOT NULL,
        Model NVARCHAR(100) NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        Storage NVARCHAR(100) NOT NULL
    );
END
GO

-- Create Stored Procedure: CreateSmartPhone
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateSmartPhone]') AND type in (N'P', N'PC'))
    DROP PROCEDURE CreateSmartPhone;
GO

CREATE PROCEDURE CreateSmartPhone
    @Brand NVARCHAR(100),
    @Model NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Storage NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO SmartPhone (Brand, Model, Price, Storage)
    VALUES (@Brand, @Model, @Price, @Storage);
END
GO

-- Create Stored Procedure: UpdateSmartPhone
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateSmartPhone]') AND type in (N'P', N'PC'))
    DROP PROCEDURE UpdateSmartPhone;
GO

CREATE PROCEDURE UpdateSmartPhone
    @SmartPhoneId INT,
    @Brand NVARCHAR(100),
    @Model NVARCHAR(100),
    @Price DECIMAL(18,2),
    @Storage NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE SmartPhone
    SET Brand = @Brand,
        Model = @Model,
        Price = @Price,
        Storage = @Storage
    WHERE SmartPhoneId = @SmartPhoneId;
END
GO

-- Create Stored Procedure: DeleteSmartPhone
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteSmartPhone]') AND type in (N'P', N'PC'))
    DROP PROCEDURE DeleteSmartPhone;
GO

CREATE PROCEDURE DeleteSmartPhone
    @SmartPhoneId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM SmartPhone
    WHERE SmartPhoneId = @SmartPhoneId;
END
GO

-- Create Stored Procedure: GetAllSmartPhones
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllSmartPhones]') AND type in (N'P', N'PC'))
    DROP PROCEDURE GetAllSmartPhones;
GO

CREATE PROCEDURE GetAllSmartPhones
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SmartPhoneId, Brand, Model, Price, Storage
    FROM SmartPhone
    ORDER BY SmartPhoneId;
END
GO

-- Create Stored Procedure: ReadSmartPhoneById
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadSmartPhoneById]') AND type in (N'P', N'PC'))
    DROP PROCEDURE ReadSmartPhoneById;
GO

CREATE PROCEDURE ReadSmartPhoneById
    @SmartPhoneId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SmartPhoneId, Brand, Model, Price, Storage
    FROM SmartPhone
    WHERE SmartPhoneId = @SmartPhoneId;
END
GO

-- Insert Sample Data (Optional - uncomment if you want sample data)
-- INSERT INTO SmartPhone (Brand, Model, Price, Storage) VALUES
-- ('Apple', 'iPhone 15 Pro', 999.99, '256GB'),
-- ('Samsung', 'Galaxy S24 Ultra', 1199.99, '512GB'),
-- ('Google', 'Pixel 8 Pro', 899.99, '128GB'),
-- ('OnePlus', '12 Pro', 799.99, '256GB'),
-- ('Xiaomi', '14 Ultra', 1099.99, '512GB');
-- GO

PRINT 'Database setup completed successfully!';
