CREATE PROC [dbo].[SP_GETBYUSERNAMEANDPASS_PUBLIC_ENCRYPT_NHANVIEN]
	@TENDN nvarchar(100),
	@MATKHAU varchar(250)
AS BEGIN
	SELECT MaNV, HoTen, Email, CONVERT(varchar(250), Luong) as Luong,TenDN, CONVERT(varchar(250), MatKhau) as MatKhau, PubKey
	FROM NhanVien 
	WHERE TenDN = @TENDN AND CONVERT(varchar(250), MatKhau) = @MATKHAU
END