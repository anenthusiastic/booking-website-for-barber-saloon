using System;
using System.ComponentModel.DataAnnotations;
namespace ui.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public bool emailValidate(){
            var list = new string[]{"ç","ş","ü","ğ","I","Ğ","Ü","Ş","Ç","ı","ö","Ö"};
            foreach (var item in list)
            {
                if(this.Email.Contains(item)){
                    return false;
                }
            }
            return true;
        }
        public bool phoneValidate(){
            return true;
        }
    }
}