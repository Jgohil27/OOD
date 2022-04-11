CREATE PROCEDURE [dbo].AddUpdatedProfile
   @EmailId varchar(50),
   @FirstName varchar (50),  
   @LastName varchar (50),  
   @PhoneNumber int
AS
BEGIN
   Update AspNetUsers SET Email = @EmailId , FirstName = @FirstName , LastName = @LastName , PhoneNumber = @PhoneNumber where Email= @EmailId
END
GO

--DROP procedure AddUpdatedProfile
--GO
sp_helptext AddUpdatedProfile