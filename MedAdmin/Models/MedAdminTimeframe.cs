namespace MedAdmin.Models
{
    public class MedAdminTimeframe
    {
        public string patient_id { get; set; }

        public string? medication_name { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        public List<MedAdminEvent>? MedEventsArr { get; set; }


    }
}