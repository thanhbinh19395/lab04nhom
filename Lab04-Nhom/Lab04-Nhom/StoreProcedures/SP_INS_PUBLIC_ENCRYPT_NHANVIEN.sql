CREATE PROC [dbo].[SP_INS_PUBLIC_ENCRYPT_NHANVIEN] 
@MaNV varchar(20),
@HoTen nvarchar(100),
@Email varchar(50),
@Luong varchar(100),
@TenDN nvarchar(100),
@MatKhau varchar(250),
@PubKey varchar(20)
AS BEGIN

DECLARE @MK varbinary(250)
SELECT @MK =  CONVERT(varbinary(250), @MatKhau)
DECLARE @L varbinary(250)
SELECT @L =  CONVERT(varbinary(250), @Luong)

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
           ,@L
           ,@TenDN
           ,@MK
		   ,@PubKey)
END
GO