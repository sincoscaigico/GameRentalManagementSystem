-- =========================================================
-- ĐỒ ÁN: HỆ THỐNG QUẢN LÝ CHO THUÊ GAME
-- PHẦN: LẬP TRÌNH CƠ SỞ DỮ LIỆU (T-SQL)
-- =========================================================

USE master;
GO

CREATE DATABASE GameRentalDB;
GO

USE GameRentalDB;
GO

-- =========================================================
-- BẢNG Categories
-- Lưu danh mục / thể loại game
-- =========================================================
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);
GO

-- =========================================================
-- BẢNG Games
-- Lưu thông tin game cho thuê
-- =========================================================
CREATE TABLE Games (
    GameID INT PRIMARY KEY IDENTITY(1,1),
    GameName NVARCHAR(150) NOT NULL,
    Genre NVARCHAR(100),
    Platform NVARCHAR(50),
    ReleaseYear INT,
    RentalPrice DECIMAL(10,2),
    StockQuantity INT CHECK (StockQuantity >= 0),
    Status NVARCHAR(20) DEFAULT 'Available',
    CreatedDate DATETIME DEFAULT GETDATE(),
    CategoryID INT,

    CONSTRAINT FK_Games_Categories
    FOREIGN KEY (CategoryID)
    REFERENCES Categories(CategoryID)
);
GO

-- =========================================================
-- BẢNG Customers
-- Lưu thông tin khách hàng
-- =========================================================
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    Address NVARCHAR(200),
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- =========================================================
-- BẢNG Employees
-- Lưu thông tin nhân viên
-- =========================================================
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(100)
);
GO

-- =========================================================
-- BẢNG Rentals
-- Lưu phiếu thuê game
-- =========================================================
CREATE TABLE Rentals (
    RentalID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    EmployeeID INT NOT NULL,
    RentalDate DATE NOT NULL,
    ReturnDate DATE,
    TotalAmount DECIMAL(10,2),
    Status NVARCHAR(30) DEFAULT 'Renting',

    CONSTRAINT FK_Rentals_Customers
    FOREIGN KEY (CustomerID)
    REFERENCES Customers(CustomerID),

    CONSTRAINT FK_Rentals_Employees
    FOREIGN KEY (EmployeeID)
    REFERENCES Employees(EmployeeID)
);
GO

-- =========================================================
-- BẢNG RentalDetails
-- Lưu chi tiết game trong phiếu thuê
-- =========================================================
CREATE TABLE RentalDetails (
    RentalDetailID INT PRIMARY KEY IDENTITY(1,1),
    RentalID INT NOT NULL,
    GameID INT NOT NULL,
    Quantity INT CHECK (Quantity > 0),
    Price DECIMAL(10,2),

    CONSTRAINT FK_RentalDetails_Rentals
    FOREIGN KEY (RentalID)
    REFERENCES Rentals(RentalID),

    CONSTRAINT FK_RentalDetails_Games
    FOREIGN KEY (GameID)
    REFERENCES Games(GameID)
);
GO

-- =========================================================
-- VIEW
-- Hiển thị danh sách game đang được thuê
-- =========================================================
CREATE VIEW vw_CurrentlyRentedGames
AS
SELECT
    r.RentalID,
    c.FullName AS CustomerName,
    e.FullName AS EmployeeName,
    g.GameName,
    r.RentalDate,
    r.Status
FROM Rentals r
JOIN Customers c
    ON r.CustomerID = c.CustomerID
JOIN Employees e
    ON r.EmployeeID = e.EmployeeID
JOIN RentalDetails rd
    ON r.RentalID = rd.RentalID
JOIN Games g
    ON rd.GameID = g.GameID
WHERE r.Status = 'Renting';
GO

-- =========================================================
-- VIEW
-- Hiển thị tồn kho game
-- =========================================================
CREATE VIEW vw_GameInventory
AS
SELECT
    GameID,
    GameName,
    StockQuantity,
    Status
FROM Games;
GO

-- =========================================================
-- FUNCTION
-- Tính tổng tiền của phiếu thuê
-- =========================================================
CREATE FUNCTION fn_TotalRentalAmount
(
    @RentalID INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN

    DECLARE @Total DECIMAL(10,2);

    SELECT @Total = SUM(Price * Quantity)
    FROM RentalDetails
    WHERE RentalID = @RentalID;

    RETURN ISNULL(@Total, 0);

END;
GO

-- =========================================================
-- STORED PROCEDURE
-- Lấy danh sách tất cả game
-- =========================================================
CREATE PROCEDURE sp_GetAllGames
AS
BEGIN

    SELECT * FROM Games;

END;
GO

-- =========================================================
-- STORED PROCEDURE
-- Thêm khách hàng mới
-- =========================================================
CREATE PROCEDURE sp_AddCustomer
(
    @FullName NVARCHAR(100),
    @Phone VARCHAR(20),
    @Email VARCHAR(100),
    @Address NVARCHAR(200)
)
AS
BEGIN

    INSERT INTO Customers
    (
        FullName,
        Phone,
        Email,
        Address
    )
    VALUES
    (
        @FullName,
        @Phone,
        @Email,
        @Address
    );

END;
GO

-- =========================================================
-- STORED PROCEDURE
-- Cập nhật số lượng game
-- =========================================================
CREATE PROCEDURE sp_UpdateGameStock
(
    @GameID INT,
    @Quantity INT
)
AS
BEGIN

    UPDATE Games
    SET StockQuantity = StockQuantity - @Quantity
    WHERE GameID = @GameID;

END;
GO

-- =========================================================
-- TRIGGER
-- Tự động cập nhật trạng thái game
-- =========================================================
CREATE TRIGGER trg_OutOfStock
ON Games
AFTER UPDATE
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE g
    SET Status =
        CASE
            WHEN i.StockQuantity <= 0 THEN 'Out Of Stock'
            ELSE 'Available'
        END
    FROM Games g
    INNER JOIN inserted i
        ON g.GameID = i.GameID
    WHERE g.Status <>
        CASE
            WHEN i.StockQuantity <= 0 THEN 'Out Of Stock'
            ELSE 'Available'
        END;

END;
GO

-- =========================================================
-- TRANSACTION
-- Xử lý quá trình thuê game
-- =========================================================
BEGIN TRANSACTION;

BEGIN TRY

    INSERT INTO Rentals
    (
        CustomerID,
        EmployeeID,
        RentalDate,
        TotalAmount,
        Status
    )
    VALUES
    (
        1,
        1,
        GETDATE(),
        100000,
        'Renting'
    );

    DECLARE @RentalID INT;
    SET @RentalID = SCOPE_IDENTITY();

    INSERT INTO RentalDetails
    (
        RentalID,
        GameID,
        Quantity,
        Price
    )
    VALUES
    (
        @RentalID,
        1,
        1,
        100000
    );

    UPDATE Games
    SET StockQuantity = StockQuantity - 1
    WHERE GameID = 1;

    COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;

END CATCH;
GO

-- =========================================================
-- VIEW
-- Top game được thuê nhiều
-- =========================================================
CREATE VIEW vw_TopRentedGames
AS
SELECT
    g.GameID,
    g.GameName,
    COUNT(rd.GameID) AS TotalRented
FROM RentalDetails rd
JOIN Games g ON rd.GameID = g.GameID
GROUP BY g.GameID, g.GameName;
GO

-- =========================================================
-- VIEW
-- Thống kê tổng số lần thuê và tổng tiền của khách hàng
-- =========================================================

CREATE VIEW vw_CustomerRentalSummary
AS
SELECT
    c.CustomerID,
    c.FullName,
    COUNT(r.RentalID) AS TotalRentals,
    SUM(r.TotalAmount) AS TotalSpent
FROM Customers c
JOIN Rentals r
    ON c.CustomerID = r.CustomerID
GROUP BY
    c.CustomerID,
    c.FullName;
GO

-- =========================================================
-- FUNCTION
-- Tính tổng số game trong một phiếu thuê
-- =========================================================

CREATE FUNCTION fn_TotalGamesRented
(
    @RentalID INT
)
RETURNS INT
AS
BEGIN

    DECLARE @TotalGames INT;

    SELECT @TotalGames = SUM(Quantity)
    FROM RentalDetails
    WHERE RentalID = @RentalID;

    RETURN ISNULL(@TotalGames,0);

END;
GO

CREATE FUNCTION fn_CheckGameStock
(
    @GameID INT
)
RETURNS INT
AS
BEGIN

    DECLARE @Stock INT;

    SELECT @Stock = StockQuantity
    FROM Games
    WHERE GameID = @GameID;

    RETURN ISNULL(@Stock,0);

END;
GO

-- =========================================================
-- STORED PROCEDURE
-- Lấy danh sách tất cả game
-- =========================================================
CREATE PROCEDURE sp_GetAllGames
AS
BEGIN

    SELECT *
    FROM Games;

END;
GO



-- =========================================================
-- STORED PROCEDURE
-- Thêm khách hàng mới
-- =========================================================
CREATE PROCEDURE sp_AddCustomer
(
    @FullName NVARCHAR(100),
    @Phone VARCHAR(20),
    @Email VARCHAR(100),
    @Address NVARCHAR(200)
)
AS
BEGIN

    INSERT INTO Customers
    (
        FullName,
        Phone,
        Email,
        Address
    )
    VALUES
    (
        @FullName,
        @Phone,
        @Email,
        @Address
    );

END;
GO



-- =========================================================
-- STORED PROCEDURE
-- Cập nhật số lượng game
-- =========================================================
CREATE PROCEDURE sp_UpdateGameStock
(
    @GameID INT,
    @Quantity INT
)
AS
BEGIN

    UPDATE Games
    SET StockQuantity = StockQuantity - @Quantity
    WHERE GameID = @GameID;

END;
GO



-- =========================================================
-- STORED PROCEDURE
-- Tìm game theo tên
-- =========================================================
CREATE PROCEDURE sp_SearchGame
(
    @Keyword NVARCHAR(100)
)
AS
BEGIN

    SELECT *
    FROM Games
    WHERE GameName LIKE '%' + @Keyword + '%';

END;
GO



-- =========================================================
-- STORED PROCEDURE
-- Thuê game
-- =========================================================
CREATE PROCEDURE sp_RentGame
(
    @CustomerID INT,
    @EmployeeID INT,
    @GameID INT,
    @Quantity INT,
    @Price DECIMAL(10,2)
)
AS
BEGIN

    BEGIN TRANSACTION;

    BEGIN TRY

        INSERT INTO Rentals
        (
            CustomerID,
            EmployeeID,
            RentalDate,
            TotalAmount,
            Status
        )
        VALUES
        (
            @CustomerID,
            @EmployeeID,
            GETDATE(),
            @Price * @Quantity,
            'Renting'
        );

        DECLARE @RentalID INT;
        SET @RentalID = SCOPE_IDENTITY();

        INSERT INTO RentalDetails
        (
            RentalID,
            GameID,
            Quantity,
            Price
        )
        VALUES
        (
            @RentalID,
            @GameID,
            @Quantity,
            @Price
        );

        UPDATE Games
        SET StockQuantity = StockQuantity - @Quantity
        WHERE GameID = @GameID;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

    END CATCH

END;
GO



-- =========================================================
-- STORED PROCEDURE
-- Trả game
-- =========================================================
CREATE PROCEDURE sp_ReturnGame
(
    @RentalID INT,
    @GameID INT,
    @Quantity INT
)
AS
BEGIN
    UPDATE Rentals SET Status = 'Returned', ReturnDate = GETDATE() WHERE RentalID = @RentalID;
    UPDATE Games SET StockQuantity = StockQuantity + @Quantity WHERE GameID = @GameID;
END;
GO

CREATE PROCEDURE sp_UpdateCustomer
    @CustomerID INT,
    @FullName NVARCHAR(100),
    @Phone VARCHAR(20),
    @Email VARCHAR(100),
    @Address NVARCHAR(255)
AS
BEGIN
    UPDATE Customers
    SET
        FullName = @FullName,
        Phone = @Phone,
        Email = @Email,
        Address = @Address
    WHERE CustomerID = @CustomerID
END
GO


CREATE PROCEDURE sp_DeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customers
    WHERE CustomerID = @CustomerID
END
GO