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


CREATE TABLE ContactUs (
    firstname varchar(255),
    lastname varchar(255),
    emailaddress varchar(255),
	message varchar(300) ,
	phonenumber int
);

sp_helptext AddContactUsDetails

select * from contactus

