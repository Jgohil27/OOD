CREATE PROCEDURE [dbo].[FetchProfile]
@EmailId  varchar(50) , 
@FirstName varchar(50) Output , @LastName varchar(50) Output
AS
BEGIN
   
    select FirstName, LastName from AspNetUsers where Email = @EmailId
END
GO

select * from AspNetUsers


CREATE PROCEDURE [dbo].[UpdatePassword]
@EmailId  varchar(50) , 
@Password varchar(50)
AS
BEGIN
    UPDATE AspNetUsers SET [PasswordHash] = @Password where Email = @EmailId
END
GO

sp_helptext [UpdatePassword] ; 
sp_helptext [FetchProfile] ;