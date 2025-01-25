USE GourmetShop
GO

-- Get all products
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM Product;
END;
GO

-- Insert a new product
CREATE PROCEDURE InsertProduct
    @Name NVARCHAR(100),
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Product (ProductName, UnitPrice) 
    VALUES (@Name, @Price);
END;
GO

-- Update an existing product
CREATE PROCEDURE UpdateProduct
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
CREATE PROCEDURE DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Product WHERE Id = @Id;
END;
GO

-- Get all suppliers
CREATE PROCEDURE GetAllSuppliers
AS
BEGIN
    SELECT * FROM Supplier;
END;
GO

-- Insert a new supplier
CREATE PROCEDURE InsertSupplier
    @Name NVARCHAR(100),
    @Contact NVARCHAR(100)
AS
BEGIN
    INSERT INTO Supplier (CompanyName, ContactName) 
    VALUES (@Name, @Contact);
END;
GO

-- Update an existing supplier
CREATE PROCEDURE UpdateSupplier
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
CREATE PROCEDURE DeleteSupplier
    @Id INT
AS
BEGIN
    DELETE FROM Supplier WHERE Id = @Id;
END;
GO
