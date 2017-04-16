CREATE proc [dbo].[SP_UPD_SINHVIEN]
@MASV nvarchar(20),
	@HOTEN nvarchar(100),
	@NGAYSINH DATETIME,
	@DIACHI nvarchar(200),
	@MALOP varchar(20),
	@TENDN nvarchar(100)
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