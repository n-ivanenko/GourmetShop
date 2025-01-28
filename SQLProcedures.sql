USE GourmetShop
GO

-- Get all products
CREATE OR ALTER PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM Product;
END;
GO

-- Insert a new product
CREATE OR ALTER PROCEDURE InsertProduct
	@Id INT,
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
SET IDENTITY_INSERT Product ON;
    INSERT INTO Product (Id, ProductName, UnitPrice) 
    VALUES (@Id, @Name, @Price);
	SET IDENTITY_INSERT Product OFF;
END;
GO

-- Update an existing product
CREATE OR ALTER PROCEDURE  UpdateProduct
    @Id INT,
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    UPDATE Product
    SET ProductName = @Name, UnitPrice = @Price
    WHERE Id = @Id;
END;
GO

-- Delete a product
CREATE OR ALTER PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Product WHERE Id = @Id;
END;
GO

-- Get all suppliers
CREATE OR ALTER PROCEDURE GetAllSuppliers
AS
BEGIN
    SELECT * FROM Supplier;
END;
GO

-- Insert a new supplier
CREATE OR ALTER PROCEDURE InsertSupplier
	@Id INT,
    @Name NVARCHAR(100),
    @Contact NVARCHAR(100)
AS
BEGIN
SET IDENTITY_INSERT Supplier ON;
    INSERT INTO Supplier (Id, CompanyName, ContactName) 
    VALUES (@Id, @Name, @Contact);
	SET IDENTITY_INSERT Supplier OFF;
END;
GO

-- Update an existing supplier
CREATE OR ALTER PROCEDURE UpdateSupplier
    @Id INT,
    @Name NVARCHAR(100),
    @Contact NVARCHAR(100)
AS
BEGIN
    UPDATE Supplier 
    SET CompanyName = @Name, ContactName = @Contact
    WHERE Id = @Id;
END;
GO

-- Delete a supplier
CREATE OR ALTER PROCEDURE DeleteSupplier
    @Id INT
AS
BEGIN
    DELETE FROM Supplier WHERE Id = @Id;
END;
GO
