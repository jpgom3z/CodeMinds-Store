USE StoreDB;
GO

-- INSERT CATEGORY STATES
IF NOT EXISTS (SELECT * FROM CategoryState WHERE [Name] = 'Active')
BEGIN
    INSERT INTO CategoryState ([Name]) VALUES ('Active');
END

IF NOT EXISTS (SELECT * FROM CategoryState WHERE [Name] = 'Inactive')
BEGIN
    INSERT INTO CategoryState ([Name]) VALUES ('Inactive');
END

-- INSERT CATEGORIES
IF NOT EXISTS (SELECT * FROM Category WHERE [Name] = 'Electronics')
BEGIN
    INSERT INTO Category ([Name], [CategoryStateId]) VALUES ('Electronics', 1);
END

IF NOT EXISTS (SELECT * FROM Category WHERE [Name] = 'Clothing')
BEGIN
    INSERT INTO Category ([Name], [CategoryStateId]) VALUES ('Clothing', 1);
END

IF NOT EXISTS (SELECT * FROM Category WHERE [Name] = 'Books')
BEGIN
    INSERT INTO Category ([Name], [CategoryStateId]) VALUES ('Books', 2);
END

-- INSERT PRODUCT STATES
IF NOT EXISTS (SELECT * FROM ProductState WHERE [Name] = 'In Stock')
BEGIN
    INSERT INTO ProductState ([Name]) VALUES ('In Stock');
END

IF NOT EXISTS (SELECT * FROM ProductState WHERE [Name] = 'Out of Stock')
BEGIN
    INSERT INTO ProductState ([Name]) VALUES ('Out of Stock');
END

-- INSERT PRODUCTS
IF NOT EXISTS (SELECT * FROM Product WHERE [Name] = 'Smartphone')
BEGIN
    INSERT INTO Product ([Name], [Description], [Price], [CategoryId], [ProductStateId], [Stock]) VALUES ('Smartphone', 'High-end smartphone with advanced features', 699.99, 1, 1, 50);
END

IF NOT EXISTS (SELECT * FROM Product WHERE [Name] = 'T-Shirt')
BEGIN
    INSERT INTO Product ([Name], [Description], [Price], [CategoryId], [ProductStateId], [Stock]) VALUES ('T-Shirt', 'Comfortable cotton T-shirt in various colors', 19.99, 2, 1, 100);
END

IF NOT EXISTS (SELECT * FROM Product WHERE [Name] = 'Novel')
BEGIN
    INSERT INTO Product ([Name], [Description], [Price], [CategoryId], [ProductStateId], [Stock]) VALUES ('Novel', 'Bestselling fiction novel', 29.99, 3, 1, 10);
END

-- INSERT ORDERS

IF NOT EXISTS (SELECT * FROM [Order] WHERE [CustomerDocumentId] = '123456789')
BEGIN
INSERT INTO [Order] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [TotalPrice]) VALUES 
('2023-02-15 14:30:00.000', 'John Doe', '123456789', '12345678', 'john.doe@email.com', '123 Main St', 699.99);
END

IF NOT EXISTS (SELECT * FROM [Order] WHERE [CustomerDocumentId] = '123453388')
BEGIN
INSERT INTO [Order] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [TotalPrice]) VALUES 
('2024-01-15 10:30:00.000', 'Harrison Ford', '123453388', '12345678', 'harrison.ford@email.com', '456 Main St', 889.92);
END

IF NOT EXISTS (SELECT * FROM [Order] WHERE [CustomerDocumentId] = '123450055')
BEGIN
INSERT INTO [Order] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress], [TotalPrice]) VALUES 
('2024-01-17 10:30:00.000', 'John F. Kennedy', '123450055', '12345678', 'harrison.ford@email.com', '789 Main St', 2839.94);
END

-- INSERT ORDER PRODUCTS
DECLARE @OrderId1 INT, @OrderId2 INT, @OrderId3 INT;
DECLARE @ProductId1 INT, @ProductId2 INT, @ProductId3 INT;

SELECT @OrderId1 = Id FROM [Order] WHERE [CustomerDocumentId] = '123456789';
SELECT @OrderId2 = Id FROM [Order] WHERE [CustomerDocumentId] = '123453388';
SELECT @OrderId3 = Id FROM [Order] WHERE [CustomerDocumentId] = '123450055';
SELECT @ProductId1 = Id FROM Product WHERE [Name] = 'Smartphone';
SELECT @ProductId2 = Id FROM Product WHERE [Name] = 'T-Shirt';
SELECT @ProductId3 = Id FROM Product WHERE [Name] = 'Novel';

--OrderProducts of Order1
IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId1 AND [ProductId] = @ProductId1)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (1, @OrderId1, @ProductId1, 699.99);
END

--OrderProducts of Order2

IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId2 AND [ProductId] = @ProductId1)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (1, @OrderId2, @ProductId1, 699.99);
END

IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId2 AND [ProductId] = @ProductId2)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (2, @OrderId2, @ProductId2, 19.99);
END

IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId2 AND [ProductId] = @ProductId3)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (5, @OrderId2, @ProductId3, 29.99);
END

--OrderProduct of Order3

IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId3 AND [ProductId] = @ProductId2)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (2, @OrderId3, @ProductId2, 19.99);
END

IF NOT EXISTS (SELECT * FROM OrderProduct WHERE [OrderId] = @OrderId3 AND [ProductId] = @ProductId1)
BEGIN
    INSERT INTO OrderProduct ([Quantity], [OrderId], [ProductId], [ProductPrice]) VALUES (4, @OrderId3, @ProductId1, 699.99);
END