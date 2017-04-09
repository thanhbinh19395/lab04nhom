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