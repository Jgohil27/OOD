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