using System.ComponentModel.DataAnnotations;
namespace demo_map_api.Model
{
    public class Applicant
    {
        [Key]
        public string? ApplicantID { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? ExtensionName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
