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
	RiskCalculatedDate datetime 
);

--select * from form 