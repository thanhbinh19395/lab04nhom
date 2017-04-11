CREATE DATABASE QLSVNhom
GO

USE [QLSVNhom]
GO
/****** Object:  Table [dbo].[BangDiem]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BangDiem](
	[MaSV] [varchar](20) NOT NULL,
	[MaHP] [varchar](20) NOT NULL,
	[DiemThi] [varbinary](512) NULL,
 CONSTRAINT [PK_BangDiem] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HocPhan]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HocPhan](
	[MaHP] [varchar](20) NOT NULL,
	[TenHP] [nvarchar](100) NULL,
	[SoTC] [int] NULL,
 CONSTRAINT [PK_HocPhan] PRIMARY KEY CLUSTERED 
(
	[MaHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [varchar](20) NOT NULL,
	[TenLop] [nvarchar](100) NOT NULL,
	[MaNV] [varchar](20) NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](20) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Luong] [varbinary](512) NULL,
	[TenDN] [nvarchar](100) NOT NULL,
	[MatKhau] [varbinary](150) NOT NULL,
	[PubKey] [varchar](20) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [varchar](20) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[MaLop] [varchar](20) NULL,
	[TenDN] [nvarchar](100) NOT NULL,
	[MatKhau] [varbinary](250) NOT NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_HocPhan] FOREIGN KEY([MaHP])
REFERENCES [dbo].[HocPhan] ([MaHP])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_HocPhan]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BangDiem_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BangDiem_SinhVien]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_NhanVien]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM_GetDecryptedList]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_BANGDIEM_GetDecryptedList]
@PubKey varchar(20),
@PrivateKey nvarchar(250)
as
begin
SELECT [MaSV]
      ,[MaHP]
      ,CONVERT(int, CONVERT(varchar(10), DecryptByAsymKey(AsymKey_ID(@PubKey),[DiemThi], @PrivateKey))) as DiemThi
  FROM [dbo].[BangDiem]
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM_GetDecryptedListByMaSV]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_BANGDIEM_GetDecryptedListByMaSV]
@PubKey varchar(20),
@PrivateKey nvarchar(250),
@MaSV varchar(20)
as
begin
  SELECT [MaSV]
      ,[MaHP]
      ,CONVERT(int, CONVERT(varchar(10), DecryptByAsymKey(AsymKey_ID(@PubKey),[DiemThi], @PrivateKey))) as DiemThi
  FROM [dbo].[BangDiem]
  WHERE MaSV = @MaSV
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM_Insert]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_BANGDIEM_Insert]
@MaSV varchar(20),
@MaHP varchar(20),
@DiemThi int,
@PubKey varchar(20)
as
begin
	INSERT INTO [dbo].[BangDiem]
           ([MaSV]
           ,[MaHP]
           ,[DiemThi])
     VALUES
           (@MaSV
           ,@MaHP
           ,EncryptByAsymKey(AsymKey_ID(@PubKey), CONVERT(varchar(10), @DiemThi)))
	
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BANGDIEM_Update]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_BANGDIEM_Update]
@MaSV varchar(20),
@MaHP varchar(20),
@DiemThi int,
@PubKey varchar(20)
as
begin
	UPDATE [dbo].[BangDiem]
	SET [DiemThi] = EncryptByAsymKey(AsymKey_ID(@PubKey), CONVERT(varchar(10), @DiemThi))
	WHERE MaSV = @MaSV AND MaHP = @MaHP
	
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_PUBLIC_NHANVIEN]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_INS_PUBLIC_NHANVIEN]
	@MaNV varchar(20),
	@HoTen nvarchar(100),
	@Email varchar(50),
	@Luong bigint,
	@TenDN nvarchar(100),
	@MatKhau varchar(250)
as
begin
	declare @createAsymSql nvarchar(100), @createAsymParam nvarchar(100)
	set @createAsymSql = N'CREATE ASYMMETRIC KEY '+ @MaNV  +' WITH ALGORITHM = RSA_512 ENCRYPTION BY PASSWORD = '''+@MatKhau+''''

	exec sp_executesql @createAsymSql
	
	INSERT INTO [dbo].[NhanVien]
           ([MaNV]
           ,[HoTen]
           ,[Email]
           ,[Luong]
           ,[TenDN]
           ,[MatKhau]
		   ,[PubKey])
     VALUES
           (@MaNV
           ,@HoTen
           ,@Email
           ,EncryptByAsymKey(AsymKey_ID(@MaNV), CONVERT(varchar(50), @Luong))
           ,@TenDN
           ,HASHBYTES ('SHA1',@MATKHAU)
		   ,@MaNV)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_INS_SINHVIEN]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_INS_SINHVIEN] 
	@MASV nvarchar(20),
	@HOTEN nvarchar(100),
	@NGAYSINH DATETIME,
	@DIACHI nvarchar(200),
	@MALOP varchar(20),
	@TENDN nvarchar(100),
	@MATKHAU varchar(250)
AS BEGIN
	INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, DiaChi, MaLop, TenDN, MatKhau) VALUES(@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN, HASHBYTES ('SHA1',@MATKHAU))
end
GO
/****** Object:  StoredProcedure [dbo].[SP_SEL_PUBLIC_NHANVIEN]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_SEL_PUBLIC_NHANVIEN]
	@TenDN nvarchar(100),
	@MatKhau varchar(250)
as
begin
 
SELECT [MaNV]
      ,[HoTen]
      ,[Email]
      ,CONVERT(varchar(50), DecryptByAsymKey(AsymKey_ID(PubKey),Luong, CONVERT(nvarchar(250),@MatKhau))) as Luong
  FROM [dbo].[NhanVien]
  WHERE TenDN = @TenDN AND MatKhau = HASHBYTES('SHA1',@MatKhau)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UPD_SINHVIEN]    Script Date: 4/3/2017 8:52:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_UPD_SINHVIEN]
@MASV nvarchar(20),
	@HOTEN nvarchar(100),
	@NGAYSINH DATETIME,
	@DIACHI nvarchar(200),
	@MALOP varchar(20),
	@TENDN nvarchar(100)
	--@MATKHAU varchar(250)
as
begin

UPDATE [dbo].[SinhVien]
   SET [MaSV] = @MASV
      ,[HoTen] = @HOTEN
      ,[NgaySinh] = @NGAYSINH
      ,[DiaChi] = @DIACHI
      ,[MaLop] = @MALOP
      ,[TenDN] = @TENDN
 WHERE MaSV = @MASV
end
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', 'NGUYEN VAN A', 'nva@yahoo.com',3000000, 'NVA', '123456'
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV02', 'NGUYEN VAN B', 'nvb@yahoo.com',2000000, 'NVB', '1234567'
