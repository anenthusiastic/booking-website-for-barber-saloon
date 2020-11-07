using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using entity;

namespace ui.Models
{
    public class CategoryModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(40,MinimumLength = 5,ErrorMessage="Kategori ismi 5 ila 40 karakter arasında olmalıdır.")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public string CreateUrl (){
            string[] dizi = this.Name.ToLower().Trim().Split(' ');
            dizi[0]=StringReplace(dizi[0]);
            string url = dizi[0];
            for (int i = 1; i < dizi.Length; i++)
            {
                dizi[i]=StringReplace(dizi[i]);
                url=url+"-"+(dizi[i].TrimStart());
            }
            return url;
        }

        public string StringReplace(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }
    }
}