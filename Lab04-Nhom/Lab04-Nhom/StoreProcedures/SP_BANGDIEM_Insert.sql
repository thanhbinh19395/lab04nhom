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