create proc [dbo].[SP_BANGDIEM_GetDecryptedListByMaSV]
@PubKey varchar(20),
@PrivateKey nvarchar(250),
@MaSV varchar(20)
as
begin
  SELECT [MaSV]
      ,[MaHP]
      ,CONVERT(int, CONVERT(varchar(10), DecryptByAsymKey(AsymKey_ID(@PubKey),[DiemThi], @PrivateKey))) as DiemThi
  FROM [dbo].[BangDiem]
  WHERE MaSV = @MaSV
end