CREATE DATABASE DuLieu;
GO

USE DuLieu;
GO

CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(50) PRIMARY KEY,
    TenSinhVien NTEXT NOT NULL,
    DiemTrungBinh NVARCHAR(50) NOT NULL
);
GO

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, DiemTrungBinh) VALUES
('SV001', N'Nguyễn Văn A', 8.5),
('SV002', N'Trần Thị B', 7.0),
('SV003', N'Lê Văn C', 9.0),
('SV004', N'Phạm Thị D', 6.5 ),
('SV005', N'Hoàng Văn E ', 8.0);
GO
