/*Users Table*/
Create table AspNetUsers 
(Id	nvarchar(100) , 
FirstName	nvarchar(100)  ,
LastName	nvarchar(100) ,
UserName    nvarchar(256) , 
NormalizedUserName  nvarchar(256) , 
Email	nvarchar(256) , 
NormalizedEmail	nvarchar(256) , 
EmailConfirmed	bit , 
PasswordHash	nvarchar(max) , 
SecurityStamp	nvarchar(max) , 
ConcurrencyStamp	nvarchar(MAX) , 
PhoneNumber	nvarchar(MAX) , 
PhoneNumberConfirmed bit , 
TwoFactorEnabled	bit , 
LockoutEnd  datetimeoffset(7) , 
LockoutEnabled	bit , 
AccessFailedCount int );

/*Contact Us Table*/
CREATE TABLE ContactUs (
    firstname varchar(255),
    lastname varchar(255),
    emailaddress varchar(255),
	message varchar(300) ,
	phonenumber int
);

/*Form Table*/
 CREATE TABLE Form (
    HaveMedicalSymptoms BIT,
    MedicalCovidSymptoms varchar(255),
    DateNoted datetime,
	Temperature float ,
	TakeAnyMedicine BIT , 
	MedicineName varchar(255),
	DoctorVisit bit,
	DoctorProfession varchar(255) ,
	HadInteraction bit,
	HadInteractioCS bit,
	InteractionCS varchar(255),
	isIPersonPostive bit , 
	CovidDatetime datetime , 
	HadOutings bit , 
	OutingCS varchar(255) ,
	RiskCalculatedDate datetime,
	HadVaccine bit , 
   	VaccineDose int ,
   	VaccineName varchar(100)
);
