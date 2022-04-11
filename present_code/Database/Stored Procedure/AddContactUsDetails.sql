Create procedure [dbo].AddContactUsDetails
(  
   @FirstName varchar (50),  
   @LastName varchar (50),  
   @EmailAddress varchar (50),
   @Message varchar(300) ,
   @PhoneNumber int

)  
as  
begin  
   Insert into ContactUs values( @FirstName ,@LastName,   @EmailAddress , @Message , @PhoneNumber)  
End 

--sp_helptext AddContactUsDetails
-- DROP AddContactUsDetails

