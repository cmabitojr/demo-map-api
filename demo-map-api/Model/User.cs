using System.ComponentModel.DataAnnotations;
namespace demo_map_api.Model
{
    public class User
    {
        [Key]
        [StringLength(20)]
        public string Username { get; set; } = String.Empty;

        [StringLength(20)]
        public string Password { get; set; } = String.Empty;

        [StringLength(100)]
        public string NameOfUser { get; set; } = String.Empty;
    }
}
