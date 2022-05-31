using System.ComponentModel.DataAnnotations;
namespace demo_map_api.Model
{
    public class Applicant
    {
        [Key]
        public string? applicantID { get; set; }

        public string? firstName { get; set; }

        public string? middleName { get; set; }

        public string? lastName { get; set; }

        public string? extensionName { get; set; }

        public DateTime birthday { get; set; }
    }
}
