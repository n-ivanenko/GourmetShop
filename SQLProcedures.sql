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
	@SupplierId INT,
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Product (SupplierID, ProductName, UnitPrice) 
    VALUES ( @SupplierId, @Name, @Price);
END;
GO

-- Update an existing product
CREATE OR ALTER PROCEDURE  UpdateProduct
    @Id INT,
	@SupplierId INT,
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    UPDATE Product
    SET ProductName = @Name, UnitPrice = @Price, SupplierId = @SupplierId
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
    @Name NVARCHAR(100),
    @Contact NVARCHAR(100)
AS
BEGIN
    INSERT INTO Supplier (CompanyName, ContactName) 
    VALUES (@Name, @Contact);
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
