using System.ComponentModel.DataAnnotations;
namespace demo_map_api.Model
{
    public class User
    {
        [Key]
        [StringLength(20)]
        public string? username { get; set; } = String.Empty;

        [StringLength(20)]
        public string? password { get; set; } = String.Empty;

        [StringLength(100)]
        public string nameOfUser { get; set; } = String.Empty;
    }
}
