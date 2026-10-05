USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'FitZoneGym')
BEGIN
    CREATE DATABASE FitZoneGym COLLATE Vietnamese_CI_AS;
END
GO

USE FitZoneGym;
GO

IF OBJECT_ID('HoiVien', 'U') IS NOT NULL DROP TABLE HoiVien;
GO

CREATE TABLE HoiVien (
    MaHV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh BIT NOT NULL DEFAULT 1,
    NgaySinh DATE NOT NULL,
    SDT VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    HangThanhVien NVARCHAR(20) NOT NULL DEFAULT N'Basic',
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

-- Dữ liệu mẫu chuẩn tiếng Việt Unicode
INSERT INTO HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, NgayDangKy, TrangThai) VALUES
(N'Võ Văn Nam', 1, '1999-11-07', '07382735879', 'nam.vo@gmail.com', N'Basic', GETDATE(), 1),
(N'Nguyễn Văn Ninh', 1, '1999-11-10', '07382731034', 'ninh.nguyen@gmail.com', N'Premium', GETDATE(), 1),
(N'Nguyễn Bá Dũng', 1, '1999-12-29', '07882773727', 'dung.nguyen@gmail.com', N'Basic', GETDATE(), 1),
(N'Nguyễn Xuân Kim', 1, '1999-11-17', '07375856597', 'kim.nx@gmail.com', N'VIP', GETDATE(), 1),
(N'Nguyễn Thu Hương', 0, '1999-01-22', '07887775931', 'huong.nt@gmail.com', N'Premium', GETDATE(), 1);
GO