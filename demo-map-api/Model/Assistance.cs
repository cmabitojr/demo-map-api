using System.ComponentModel.DataAnnotations;

namespace demo_map_api.Model
{
    public class Assistance
    {
        [Key]
        public int assistanceID { get; set; }

        public string? assistanceName { get; set; }
    }


}
