USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'TriThucBooks')
BEGIN
    CREATE DATABASE TriThucBooks COLLATE Vietnamese_CI_AS;
END
GO

USE TriThucBooks;
GO

IF OBJECT_ID('Sach', 'U') IS NOT NULL DROP TABLE Sach;
IF OBJECT_ID('TheLoaiSach', 'U') IS NOT NULL DROP TABLE TheLoaiSach;
GO

CREATE TABLE TheLoaiSach (
    MaTL INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200) NOT NULL,
    MaTL INT NOT NULL,
    CONSTRAINT FK_Sach_TheLoaiSach FOREIGN KEY (MaTL) REFERENCES TheLoaiSach(MaTL)
);
GO

-- Chèn dữ liệu mẫu chuẩn tiếng Việt Unicode
INSERT INTO TheLoaiSach (TenTheLoai, MoTa, SoLuongSach, NgayTao) VALUES
(N'Tiểu thuyết', N'Thần tiểu thuyết', 1, '2024-05-20 09:57:07'),
(N'Kỹ năng sống', N'Kỹ năng sống nâng sống', 15, '2024-05-20 09:57:03'),
(N'Thiếu nhi', N'Thiếu nhi củ cà', 2, '2024-05-20 10:52:03'),
(N'Sách giáo khoa', N'Sách giáo khoa chất lượng phù hợp học sinh', 2, '2024-05-20 10:33:07'),
(N'Truyện tranh', N'Truyện tranh', 1, '2024-05-20 20:42:04');
GO

-- Chèn dữ liệu mẫu cho bảng Sach để kiểm tra ràng buộc khóa ngoại khi xóa (DbUpdateException)
INSERT INTO Sach (TenSach, MaTL) VALUES
(N'Đắc Nhân Tâm', 2),
(N'Dế Mèn Phiêu Lưu Ký', 3);
GO