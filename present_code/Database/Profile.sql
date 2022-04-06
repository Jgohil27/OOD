CREATE PROCEDURE [dbo].[FetchProfile]
@EmailId  varchar(50)
AS
BEGIN
    select FirstName, LastName , Email , PhoneNumber from AspNetUsers where Email = @EmailId
END
GO

select * from AspNetUsers