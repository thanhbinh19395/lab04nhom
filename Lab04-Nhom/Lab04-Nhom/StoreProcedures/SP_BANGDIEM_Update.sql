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