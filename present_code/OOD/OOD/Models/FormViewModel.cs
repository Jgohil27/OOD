namespace OOD.Models
{
    public class FormViewModel
    {
		public bool HaveMedicalSymptoms { get; set; }
		public string? MedicalCovidSymptoms { get; set; }
		public DateTime DateNoted { get; set; }
		public double Temperature { get; set; }
		public bool TakeAnyMedicine { get; set; }
		public string? MedicineName { get; set; }
		public bool DoctorVisit { get; set; }
		public string? DoctorProfession { get; set; }
		public bool HadInteraction { get; set; }
		public bool HadInteractioCS { get; set; }
		public string? InteractionCS { get; set; }
		public bool isIPersonPostive { get; set; }
		public DateTime CovidDatetime { get; set; }
		public bool HadOutings { get; set; }
		public string? OutingCS { get; set; }
	}
}
