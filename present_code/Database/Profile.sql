CREATE PROCEDURE [dbo].[FetchProfile]
@EmailId  varchar(50) , 
@FirstName varchar(50) Output , @LastName varchar(50) Output ,
@Email varchar(50) Output , @PhoneNumber int Output
AS
BEGIN
   
    select @FirstName=FirstName, @LastName =LastName ,@Email=Email , @PhoneNumber=PhoneNumber  from AspNetUsers where Email = @EmailId
END
GO

EXEC dbo.FetchProfile @EmailId="kalyanking12@gmail.com" , @FirstName Output, @LastName Output , Input 

select * from AspNetUsers

DROP PROCEDURE [FetchProfile]
GO

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