USE StoreDB;
GO

-- Insert data into Category table
INSERT INTO Category ([Name]) VALUES
('Electronics'),
('Clothing'),
('Home and Kitchen'),
('Sports'),
('Books');

-- Insert data into CategoryState table
INSERT INTO CategoryState ([Name]) VALUES
('Active'),
('Inactive');

-- Insert data into ProductState table
INSERT INTO ProductState ([Name]) VALUES
('Available'),
('Out of Stock');

-- Insert data into Product table
INSERT INTO Product ([Name], [Description], [Price], [CategoryId], [ProductStateId]) VALUES
('Laptop', 'High-performance laptop', 999.99, 1, 1),
('T-shirt', 'Comfortable cotton t-shirt', 19.99, 2, 1),
('Coffee Maker', 'Automatic coffee maker', 49.99, 3, 1),
('Running Shoes', 'Comfortable running shoes', 79.99, 4, 1),
('Programming Book', 'Introduction to programming', 29.99, 5, 1),
('Smartphone', 'Latest smartphone model', 699.99, 1, 2),
('Jeans', 'Blue denim jeans', 39.99, 2, 2),
('Blender', 'High-speed blender', 69.99, 3, 2),
('Basketball', 'Official size basketball', 24.99, 4, 2),
('Fiction Novel', 'Bestselling fiction novel', 14.99, 5, 2);

-- Insert data into Stock table
INSERT INTO Stock ([Quantity], [TransactionDate], [ProductId]) VALUES
(100, GETDATE(), 1),
(50, GETDATE(), 2),
(75, GETDATE(), 3),
(30, GETDATE(), 4),
(20, GETDATE(), 5),
(150, GETDATE(), 6),
(80, GETDATE(), 7),
(60, GETDATE(), 8),
(40, GETDATE(), 9),
(25, GETDATE(), 10);

-- Insert data into Order table
INSERT INTO [Order] ([Date], [CustomerName], [CustomerDocumentId], [CustomerPhone], [CustomerEmail], [CustomerAddress]) VALUES
(GETDATE(), 'John Doe', '123456789', '12345678', 'john.doe@example.com', '123 Main St'),
(GETDATE(), 'Jane Smith', '987654321', '87654321', 'jane.smith@example.com', '456 Oak St'),
(GETDATE(), 'Bob Johnson', '567890123', '34567890', 'bob.johnson@example.com', '789 Maple St'),
(GETDATE(), 'Alice Williams', '234567890', '56789012', 'alice.williams@example.com', '901 Pine St'),
(GETDATE(), 'Charlie Brown', '890123456', '67890123', 'charlie.brown@example.com', '234 Cedar St');

-- Insert data into OrderProduct table
INSERT INTO OrderProduct ([Quantity], [TotalPrice], [OrderId], [ProductId]) VALUES
(2, 1999.98, 1, 1),
(3, 59.97, 1, 2),
(1, 49.99, 2, 3),
(2, 159.98, 2, 4),
(5, 74.95, 3, 5),
(1, 699.99, 3, 6),
(2, 79.98, 4, 7),
(1, 69.99, 4, 8),
(3, 74.97, 5, 9),
(1, 24.99, 5, 10);