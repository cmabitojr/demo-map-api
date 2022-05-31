using System.ComponentModel.DataAnnotations;

namespace demo_map_api.Model
{
    public class Assistance
    {
        [Key]
        public int AssistanceID { get; set; }

        public string? AssistanceName { get; set; }
    }
}
