﻿CREATE PROC [dbo].[SP_SEL_PUBLIC_ENCRYPT_NHANVIEN]
AS
BEGIN
	SELECT [MaNV],
			[HoTen],
			[Email],
			CONVERT(VARCHAR(MAX),LUONG) AS [LUONG] 
			FROM NHANVIEN
END
GO