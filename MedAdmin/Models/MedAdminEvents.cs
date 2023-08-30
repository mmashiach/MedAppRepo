namespace MedAdmin.Models
{
    public class MedAdminEvent
    {

        public string? medication_name { get; set; }

        public string? patient_id { get; set; }
        public string? action { get; set; }

        public DateTime? event_time { get; set; }


    }
}