using System.ComponentModel.DataAnnotations;
namespace ui.Models
{
    public class RoleEditModel
    {
        [Required]
        public string RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
         public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}