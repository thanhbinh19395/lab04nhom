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