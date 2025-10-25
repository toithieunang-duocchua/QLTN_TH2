-- =============================================
-- Script SQL để thêm bảng Payments cho VietQR
-- Hệ thống Quản lý Thuê nhà - VietQR Integration
-- Version: 1.0
-- =============================================

USE QLTN;
GO

-- Tạo bảng Payments cho VietQR
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payments]') AND type in (N'U'))
BEGIN
    CREATE TABLE Payments (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ContractId NVARCHAR(50) NOT NULL,
        RoomId NVARCHAR(50) NOT NULL,
        TenantName NVARCHAR(100) NOT NULL,
        Period NVARCHAR(50) NOT NULL,
        Amount DECIMAL(15, 0) NOT NULL,
        DueDate DATETIME NOT NULL,
        Description NVARCHAR(500),
        OrderId NVARCHAR(100) NOT NULL UNIQUE,
        Status INT NOT NULL DEFAULT 0, -- 0: Pending, 1: Processing, 2: Completed, 3: Failed, 4: Expired, 5: Cancelled
        CreatedAt DATETIME DEFAULT GETDATE(),
        PaidAt DATETIME NULL,
        QrCodeUrl NVARCHAR(500),
        PaymentLink NVARCHAR(500),
        BankCode NVARCHAR(20),
        BankName NVARCHAR(100),
        TransactionId NVARCHAR(100),
        UpdatedAt DATETIME DEFAULT GETDATE()
    );
    
    -- Tạo index cho tối ưu hiệu suất
    CREATE INDEX idx_Payments_ContractId ON Payments(ContractId);
    CREATE INDEX idx_Payments_OrderId ON Payments(OrderId);
    CREATE INDEX idx_Payments_Status ON Payments(Status);
    CREATE INDEX idx_Payments_DueDate ON Payments(DueDate);
    
    PRINT 'Bảng Payments đã được tạo thành công!';
END
ELSE
BEGIN
    PRINT 'Bảng Payments đã tồn tại.';
END
GO

-- Tạo bảng VietQRConfig để lưu cấu hình VietQR
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VietQRConfig]') AND type in (N'U'))
BEGIN
    CREATE TABLE VietQRConfig (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ConfigKey NVARCHAR(100) NOT NULL UNIQUE,
        ConfigValue NVARCHAR(500) NOT NULL,
        Description NVARCHAR(500),
        IsActive BIT DEFAULT 1,
        CreatedAt DATETIME DEFAULT GETDATE(),
        UpdatedAt DATETIME DEFAULT GETDATE()
    );
    
    -- Thêm các cấu hình mặc định
    INSERT INTO VietQRConfig (ConfigKey, ConfigValue, Description) VALUES
    ('VietQR_ApiKey', '', 'API Key của VietQR'),
    ('VietQR_AccountNo', '', 'Số tài khoản ngân hàng'),
    ('VietQR_AccountName', '', 'Tên chủ tài khoản'),
    ('VietQR_AcqId', '', 'Mã ngân hàng (AcqId)'),
    ('VietQR_BankCode', '', 'Mã ngân hàng'),
    ('VietQR_BankName', '', 'Tên ngân hàng'),
    ('VietQR_BaseUrl', 'https://api.vietqr.io/v2', 'URL API VietQR');
    
    PRINT 'Bảng VietQRConfig đã được tạo thành công!';
END
ELSE
BEGIN
    PRINT 'Bảng VietQRConfig đã tồn tại.';
END
GO

-- Tạo stored procedure để lấy cấu hình VietQR
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetVietQRConfig]') AND type in (N'P'))
    DROP PROCEDURE [dbo].[sp_GetVietQRConfig];
GO

CREATE PROCEDURE sp_GetVietQRConfig
AS
BEGIN
    SELECT ConfigKey, ConfigValue, Description, IsActive
    FROM VietQRConfig
    WHERE IsActive = 1;
END
GO

-- Tạo stored procedure để cập nhật cấu hình VietQR
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdateVietQRConfig]') AND type in (N'P'))
    DROP PROCEDURE [dbo].[sp_UpdateVietQRConfig];
GO

CREATE PROCEDURE sp_UpdateVietQRConfig
    @ConfigKey NVARCHAR(100),
    @ConfigValue NVARCHAR(500)
AS
BEGIN
    UPDATE VietQRConfig 
    SET ConfigValue = @ConfigValue, UpdatedAt = GETDATE()
    WHERE ConfigKey = @ConfigKey;
    
    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO VietQRConfig (ConfigKey, ConfigValue)
        VALUES (@ConfigKey, @ConfigValue);
    END
END
GO

-- Tạo stored procedure để lấy danh sách thanh toán
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_GetPayments]') AND type in (N'P'))
    DROP PROCEDURE [dbo].[sp_GetPayments];
GO

CREATE PROCEDURE sp_GetPayments
    @ContractId NVARCHAR(50) = NULL,
    @Status INT = NULL,
    @FromDate DATETIME = NULL,
    @ToDate DATETIME = NULL
AS
BEGIN
    SELECT Id, ContractId, RoomId, TenantName, Period, Amount, DueDate, 
           Description, OrderId, Status, CreatedAt, PaidAt, QrCodeUrl, PaymentLink,
           BankCode, BankName, TransactionId, UpdatedAt
    FROM Payments
    WHERE (@ContractId IS NULL OR ContractId = @ContractId)
      AND (@Status IS NULL OR Status = @Status)
      AND (@FromDate IS NULL OR CreatedAt >= @FromDate)
      AND (@ToDate IS NULL OR CreatedAt <= @ToDate)
    ORDER BY CreatedAt DESC;
END
GO

-- Tạo stored procedure để cập nhật trạng thái thanh toán
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_UpdatePaymentStatus]') AND type in (N'P'))
    DROP PROCEDURE [dbo].[sp_UpdatePaymentStatus];
GO

CREATE PROCEDURE sp_UpdatePaymentStatus
    @OrderId NVARCHAR(100),
    @Status INT,
    @PaidAt DATETIME = NULL,
    @BankCode NVARCHAR(20) = NULL,
    @BankName NVARCHAR(100) = NULL,
    @TransactionId NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE Payments 
    SET Status = @Status,
        PaidAt = @PaidAt,
        BankCode = @BankCode,
        BankName = @BankName,
        TransactionId = @TransactionId,
        UpdatedAt = GETDATE()
    WHERE OrderId = @OrderId;
END
GO

PRINT 'Tất cả các stored procedures đã được tạo thành công!';
PRINT 'Hệ thống VietQR đã sẵn sàng để sử dụng.';
GO

