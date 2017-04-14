CREATE PROC [dbo].[SP_SEL_PUBLIC_ENCRYPT_NHANVIEN]
AS BEGIN
	SELECT MaNV, HoTen, Email, CONVERT(varchar(250), Luong) as Luong ,TenDN, CONVERT(varchar(250), MatKhau) as MatKhau, PubKey FROM NhanVien
END
