﻿CREATE PROC SP_INS_ENCRYPT_BANGDIEM		
	@MASV VARCHAR(20), 
	@MAHP VARCHAR(20), 
	@DIEMTHI VARCHAR(MAX)
AS
BEGIN
	INSERT INTO BANGDIEM (MASV,MAHP,DIEMTHI) VALUES (
		@MASV,
		@MAHP,
		CONVERT(VARBINARY(MAX), @DIEMTHI)
	)
END