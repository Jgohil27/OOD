using System.ComponentModel.DataAnnotations;

namespace OOD.Models
{
    public class FormViewModel
    {
        public bool HaveMedicalSymptoms { get; set; }
        public string? MedicalCovidSymptoms { get; set; }
        public DateTime? DateNoted { get; set; }
        //[Range(1 , 110)]
        public double? Temperature { get; set; }
        public bool TakeAnyMedicine { get; set; }
        public string? MedicineName { get; set; }
        public bool DoctorVisit { get; set; }
        public string? DoctorProfession { get; set; }
        public bool HadInteraction { get; set; }
        public bool HadInteractioCS { get; set; }
        public string? InteractionCS { get; set; }
        public bool isIPersonPostive { get; set; }
        public DateTime? CovidDatetime { get; set; }
        public bool HadOutings { get; set; }
        public string? OutingCS { get; set; }
        public bool Outforfood { get; set; }
        public string? RiskResult { get; set; }
        public int RiskScore { get; set; }
        public bool HadVaccine { get; set; }
        public string? VaccineName { get; set; }
        public int? VaccineDose  { get; set; }
        public string GetErrorMessage() =>
        "Please make sure Temperature is greater than 1 and Date Noted of Symptoms is equal or less than today ";

    }
}
