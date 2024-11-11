-- Bảng AdminUser
CREATE TABLE [dbo].[AdminUser] (
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [NameUser] NVARCHAR(255) NULL,
    [RoleUser] NVARCHAR(50) NULL,
    [PasswordUser] NCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Bảng Category
CREATE TABLE [dbo].[Category] (
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [IDCate] NCHAR(20) NOT NULL,
    [NameCate] NVARCHAR(255) NULL,
    PRIMARY KEY CLUSTERED ([IDCate] ASC)
);

-- Bảng Customer
CREATE TABLE [dbo].[Customer] (
    [IDCus] INT IDENTITY(1, 1) NOT NULL,
    [NameCus] NVARCHAR(255) NULL,
    [PhoneCus] NVARCHAR(15) NULL,
    [EmailCus] NVARCHAR(255) NULL,
    PRIMARY KEY CLUSTERED ([IDCus] ASC)
);

-- Bảng Products với cột DiscountPrice để lưu giá sau khi giảm
CREATE TABLE [dbo].[Products] (
    [ProductID] INT IDENTITY(1, 1) NOT NULL,
    [NamePro] NVARCHAR(255) NULL,
    [DecriptionPro] NVARCHAR(MAX) NULL,
    [Category] NCHAR(20) NULL,
    [Price] DECIMAL(18, 2) NULL,          -- Giá gốc
    [DiscountPrice] DECIMAL(18, 2) NULL,  -- Giá sau khi giảm
    [ImagePro] NVARCHAR(255) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Pro_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([IDCate])
);

-- Bảng OrderPro
CREATE TABLE [dbo].[OrderPro] (
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [DateOrder] DATE NULL,
    [IDCus] INT NULL,
    [AddressDeliverry] NVARCHAR(255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDCus]) REFERENCES [dbo].[Customer] ([IDCus])
);

-- Bảng OrderDetail
CREATE TABLE [dbo].[OrderDetail] (
    [ID] INT IDENTITY(1, 1) NOT NULL,
    [IDProduct] INT NULL,
    [IDOrder] INT NULL,
    [Quantity] INT NULL,
    [UnitPrice] DECIMAL(18, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDProduct]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([IDOrder]) REFERENCES [dbo].[OrderPro] ([ID])
);

-- Insert data into AdminUser
INSERT INTO [dbo].[AdminUser] (NameUser, RoleUser, PasswordUser)
VALUES
    (N'Admin1', N'Admin', N'password123'),
    (N'User1', N'User', N'password456');

-- Insert data into Category
INSERT INTO [dbo].[Category] (IDCate, NameCate)
VALUES
    (N'C001', N'Electronics'),
    (N'C002', N'Books'),
    (N'C003', N'Clothing');

-- Insert data into Customer
INSERT INTO [dbo].[Customer] (NameCus, PhoneCus, EmailCus)
VALUES
    (N'John Doe', N'1234567890', N'john@example.com'),
    (N'Jane Smith', N'0987654321', N'jane@example.com');

-- Insert data into Products
INSERT INTO [dbo].[Products] (NamePro, DecriptionPro, Category, Price, DiscountPrice, ImagePro)
VALUES
    (N'Laptop', N'15-inch laptop with 8GB RAM', N'C001', 1000.00, 900.00, N'laptop.jpg'),
    (N'Novel', N'Bestselling fiction novel', N'C002', 20.00, 15.00, N'novel.jpg'),
    (N'T-Shirt', N'Cotton T-shirt', N'C003', 10.00, 8.00, N'tshirt.jpg');

-- Insert data into OrderPro
INSERT INTO [dbo].[OrderPro] (DateOrder, IDCus, AddressDeliverry)
VALUES
    ('2024-10-01', 1, N'123 Main St'),
    ('2024-10-02', 2, N'456 Elm St');

-- Insert data into OrderDetail
INSERT INTO [dbo].[OrderDetail] (IDProduct, IDOrder, Quantity, UnitPrice)
VALUES
    (1, 1, 1, 900.00),       -- Product: Laptop, Order: 1
    (2, 2, 2, 15.00),        -- Product: Novel, Order: 2
    (3, 1, 3, 8.00);         -- Product: T-Shirt, Order: 1

