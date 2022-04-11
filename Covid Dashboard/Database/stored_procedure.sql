/*Save Contact Us Procedure*/
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

/*Save My Form Procedure*/
Create procedure [dbo].AddFormSymptoms
(  
   @HaveMedicalSymptoms bit,  
   @MedicalCovidSymptoms varchar (255),  
   @DateNoted datetime ,
   @Temperature varchar(255) ,
   @TakeAnyMedicine bit,
   @MedicineName varchar(255),
   @DoctorVisit bit,
   @DoctorProfession varchar(255) ,
   @HadInteraction bit,
   @HadInteractioCS bit,
   @InteractionCS varchar(255),
   @isIPersonPostive bit , 
   @CovidDatetime datetime , 
   @HadOutings bit , 
   @OutingCS varchar(255), 
   @Outforfood bit ,  
   @RiskResult varchar(255) ,
   @RiskScore int ,
   @RiskCalculatedDate datetime
)  
as  
begin  
   Insert into Form values( @HaveMedicalSymptoms ,  
   @MedicalCovidSymptoms  ,  
   @DateNoted ,
   @Temperature,
   @TakeAnyMedicine ,
   @MedicineName ,
   @DoctorVisit ,
   @DoctorProfession  ,
   @HadInteraction ,
   @HadInteractioCS ,
   @InteractionCS ,
   @isIPersonPostive  , 
   @CovidDatetime  , 
   @HadOutings  , 
   @OutingCS, 
   @Outforfood  ,  
   @RiskResult ,
   @RiskScore,
   @RiskCalculatedDate ) 
End 

/*Fetch My Profile Procedure*/
CREATE PROCEDURE [dbo].[FetchProfile]
@EmailId  varchar(50) , 
@FirstName varchar(50) Output , @LastName varchar(50) Output ,
@Email varchar(50) Output , @PhoneNumber int Output
AS
BEGIN
   
    select @FirstName=FirstName, @LastName =LastName ,@Email=Email , @PhoneNumber=PhoneNumber  from AspNetUsers where Email = @EmailId
END
GO

/*Save My Profile Procedure*/
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

/*Update Password Procedure*/
CREATE PROCEDURE [dbo].[UpdatePassword]
@EmailId  varchar(50) , 
@Password varchar(50)
AS
BEGIN
    UPDATE AspNetUsers SET [PasswordHash] = @Password where Email = @EmailId
END
GO