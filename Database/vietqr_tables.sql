-- Script tạo bảng Payments và PaymentQrHistory cho VietQR Generator
-- Chạy script này trên SQL Server để tạo các bảng cần thiết

USE [qltn]
GO

-- Tạo bảng Payments nếu chưa có
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Payments' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[Payments](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [RoomId] [nvarchar](20) NOT NULL,
        [Month] [char](7) NOT NULL, -- Format: yyyy-MM
        [Amount] [int] NOT NULL,
        [Note] [nvarchar](200) NULL,
        [CreatedAt] [datetime2](7) NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] [datetime2](7) NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    -- Tạo index để tối ưu truy vấn
    CREATE INDEX [IX_Payments_RoomId_Month] ON [dbo].[Payments] ([RoomId], [Month])
    
    PRINT 'Đã tạo bảng Payments'
END
ELSE
BEGIN
    PRINT 'Bảng Payments đã tồn tại'
END
GO

-- Tạo bảng PaymentQrHistory
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PaymentQrHistory' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[PaymentQrHistory](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [RoomId] [nvarchar](20) NOT NULL,
        [Month] [char](7) NOT NULL,
        [Amount] [int] NOT NULL,
        [BankId] [nvarchar](10) NOT NULL,
        [AccountNo] [nvarchar](20) NOT NULL,
        [AccountName] [nvarchar](100) NOT NULL,
        [Template] [nvarchar](20) NOT NULL,
        [Message] [nvarchar](200) NULL,
        [QrUrl] [nvarchar](500) NOT NULL,
        [SavedPath] [nvarchar](500) NULL,
        [CreatedAt] [datetime2](7) NOT NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_PaymentQrHistory] PRIMARY KEY CLUSTERED ([Id] ASC)
    )
    
    -- Tạo index để tối ưu truy vấn
    CREATE INDEX [IX_PaymentQrHistory_RoomId_Month] ON [dbo].[PaymentQrHistory] ([RoomId], [Month])
    CREATE INDEX [IX_PaymentQrHistory_CreatedAt] ON [dbo].[PaymentQrHistory] ([CreatedAt])
    
    PRINT 'Đã tạo bảng PaymentQrHistory'
END
ELSE
BEGIN
    PRINT 'Bảng PaymentQrHistory đã tồn tại'
END
GO

-- Thêm dữ liệu mẫu vào bảng Payments (tùy chọn)
IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[Payments])
BEGIN
    INSERT INTO [dbo].[Payments] ([RoomId], [Month], [Amount], [Note])
    VALUES 
        ('P001', '2024-01', 2500000, N'Tiền thuê phòng tháng 1'),
        ('P001', '2024-02', 2500000, N'Tiền thuê phòng tháng 2'),
        ('P001', '2024-03', 2500000, N'Tiền thuê phòng tháng 3'),
        ('P002', '2024-01', 3000000, N'Tiền thuê phòng tháng 1'),
        ('P002', '2024-02', 3000000, N'Tiền thuê phòng tháng 2'),
        ('P002', '2024-03', 3000000, N'Tiền thuê phòng tháng 3'),
        ('P003', '2024-01', 2000000, N'Tiền thuê phòng tháng 1'),
        ('P003', '2024-02', 2000000, N'Tiền thuê phòng tháng 2'),
        ('P003', '2024-03', 2000000, N'Tiền thuê phòng tháng 3'),
        ('P004', '2024-01', 3500000, N'Tiền thuê phòng tháng 1'),
        ('P004', '2024-02', 3500000, N'Tiền thuê phòng tháng 2'),
        ('P004', '2024-03', 3500000, N'Tiền thuê phòng tháng 3')
    
    PRINT 'Đã thêm dữ liệu mẫu vào bảng Payments'
END
ELSE
BEGIN
    PRINT 'Bảng Payments đã có dữ liệu'
END
GO

PRINT 'Hoàn thành tạo database cho VietQR Generator'

