CREATE PROC [dbo].[SP_GETBYMANV_PUBLIC_ENCRYPT_NHANVIEN]
@MaNV nvarchar(20)
AS BEGIN
	SELECT MaNV, HoTen, Email, CONVERT(varchar(250), Luong) as Luong,TenDN, CONVERT(varchar(250), MatKhau) as MatKhau, PubKey 
	FROM NhanVien
	WHERE MaNV = @MaNV
END