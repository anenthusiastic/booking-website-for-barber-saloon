using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using entity;

namespace ui.Models
{
    public class ProductModel
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 5, ErrorMessage = "Ürün ismi minimum 5 karakter ve maksimum 60 karakter olmalıdır.")]
        [Required(ErrorMessage = "İsim zorunludur.")]
        [Display(Name="İsim")]
        public string Name { get; set; }

        [Display(Name="Ürün Resmi")]
        public string ImageUrl { get; set; }

        [Display(Name="Ürün Açıklaması")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat belirtiniz")]
        [Range(1,1000000,ErrorMessage = "Ürün fiyatı en az 1 lira olmalıdır.")]
        [Display(Name="Fiyat")]
        public double? Price { get; set; }
        public bool IsApproved { get; set; }
        public List<Category> SelectedCategories { get; set; }

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
