CREATE PROCEDURE [dbo].[FetchProfile]
@EmailId  varchar(50) , 
@FirstName varchar(50) Output , @LastName varchar(50) Output ,
@Email varchar(50) Output , @PhoneNumber int Output
AS
BEGIN
   
    select @FirstName=FirstName, @LastName =LastName ,@Email=Email , @PhoneNumber=PhoneNumber  from AspNetUsers where Email = @EmailId
END
GO