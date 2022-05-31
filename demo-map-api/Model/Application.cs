using System.ComponentModel.DataAnnotations;

namespace demo_map_api.Model
{
    public class Application
    {
        [Key]
        public string? ApplicationID { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string? ApplicantID { get; set; }

        public int AssistanceID { get; set; }

        public int Status { get; set; }
    }
}
