CREATE PROCEDURE [dbo].[UpdatePassword]
@EmailId  varchar(50) , 
@Password varchar(50)
AS
BEGIN
    UPDATE AspNetUsers SET [PasswordHash] = @Password where Email = @EmailId
END
GO