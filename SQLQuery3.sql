USE [canteenDatabase]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CusItemdetails]

SELECT	@return_value as 'Return Value'

GO
