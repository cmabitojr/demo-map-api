using System.ComponentModel.DataAnnotations;

namespace demo_map_api.Model
{
    public class Application
    {
        [Key]
        public string? applicationID { get; set; }

        public DateTime applicationDate { get; set; }

        public string? applicantID { get; set; }

        public int assistanceID { get; set; }

        public int status { get; set; }
    }
}
