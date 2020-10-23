CREATE PROCEDURE [dbo].[cid]
AS
BEGIN
DECLARE @max int, @no nvarchar(50)
SELECT @max=ISNULL (max(cast(RIGHT(cid,8)as int)),0)+1 from tblCustomer
if @max<100000
SELECT 'CUS'+RIGHT('00000'+CAST(@max as nvarchar(50)),8)
else
if @max>=100000
SELECT @no='CUS'+RIGHT('0'+CAST(@max as nvarchar(50)),9)
if @max>=1000000
SELECT @no='CUS'+RIGHT('0'+CAST(@max as nvarchar(50)),10)
PRINT @no
END