create PROC [dbo].[SP_UPD_ENCRYPTED_SINHVIEN] 
	@MASV nvarchar(20),
	@HOTEN nvarchar(100),
	@NGAYSINH DATETIME,
	@DIACHI nvarchar(200),
	@MALOP varchar(20),
	@TENDN nvarchar(100),
	@MATKHAU varchar(250)
AS BEGIN
	DECLARE @MK varbinary(250)
	SET @MK =  CONVERT(varbinary(250), @MATKHAU)
	UPDATE [dbo].[SinhVien]
	   SET [HoTen] = @HOTEN
		  ,[NgaySinh] = @NGAYSINH
		  ,[DiaChi] = @DIACHI
		  ,[MaLop] = @MALOP
		  ,[TenDN] = @TENDN
		  ,[MatKhau] = @MK
	 WHERE MaSV = @MASV
end
