using System;
using System.Linq;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed(){
            var context = new BarberContext();
            if(context.Database.GetPendingMigrations().Count() ==0){
                if(context.Categories.Count()==0){
                    context.Categories.AddRange(Categories);  
                    context.AddRange(ProductsCategories);            
                }
                if(context.Products.Count()==0){
                    context.Products.AddRange(Products); 
                }
                if(context.Services.Count()==0 ){
                    context.Services.AddRange(Services);
                }
            }
            context.SaveChanges();
        }
        private static Category[] Categories={
            new Category(){name = "Şampuanlar", url="sampuanlar"},
            new Category(){name = "Saç Spreyleri",url = "sac-spreyleri"},
            new Category(){name = "Saç Kremleri",url = "sac-kremleri"},
            new Category(){name = "Saç Şekillendiriciler",url = "sac-sekillendiriciler"},
            new Category(){name = "Saç Boyaları",url = "sac-boyalari"},
            new Category(){name = "Saç Fırçaları ve Aksesuarları",url = "sac-aksesuarlari"},
            new Category(){name = "Saç Dökülmesine Karşı Ürünler",url = "sac-dokulmesine-karsi"}
        };

         private static Product[] Products={
            new Product(){name = "Head & Shoulders Clinical Strength Şampuan 400 ml",url="head&shoulders-clinical-strenght-sampuan",description="Head&Shoulders Şampuan" ,price=89.5,imageUrl="head&shoulders.jpg"},
            new Product(){name = "Kerastase Densifique Homme",url="kerastase-densifique-homme",description="Kerastase Densifique Homme Erkeklere Özel Yoğunlaştırıcı Şampuan Yeni Şeffaf Kıvamlı Formül 250 ml",price=149.9,imageUrl="kerastase.jpg"},
            new Product(){name = "Pantene Bambu ve Proteinli Krem",url ="pantene-proteinli-krem",description="Pantene Uzun ve Güçlü Yeniden Yapılandırıcı Durulanmayan Krem, Bambu ve Proteinli, 270ml",price=18.5,imageUrl="pantene.jpg"},
            new Product(){name = "Morfose Saç Spreyı",url="morfose-sac-spreyi",description="Morfose Ultra Sert Saç Spreyı 400 Ml",price=17.09,imageUrl="morfose.jpg"},
            new Product(){name = "Igora Saç Boyası",url="igora-royal-sac-boyasi",description="Igora Royal 0-22 Turuncu Azaltıcı Saç Boyası",price=36.10,imageUrl="igora.jpg"}
        };

        private static ProductCategory[] ProductsCategories={
            new ProductCategory(){Product = Products[0],Category = Categories[0]},
            new ProductCategory(){Product = Products[0],Category = Categories[6]},
            new ProductCategory(){Product = Products[1],Category = Categories[0]},
            new ProductCategory(){Product = Products[2],Category = Categories[2]},
            new ProductCategory(){Product = Products[2],Category = Categories[6]},
            new ProductCategory(){Product = Products[3],Category = Categories[1]},
            new ProductCategory(){Product = Products[3],Category = Categories[3]},
            new ProductCategory(){Product = Products[4],Category = Categories[4]},
            new ProductCategory(){Product = Products[4],Category = Categories[5]}
        };


         private static Service[] Services={
            new Service(){name = "Saç Kesimi",price=20,description="Saçlarınıza yeni bir soluk getirin!",time=30,imageUrl="~/img/service/1.png"},
            new Service(){name = "Sakal Kesimi",price=15,description="Sakallarınıza en iyi biz bakarız!",time=15,imageUrl="~/img/service/2.png"},
            new Service(){name = "Saç + Sakal Kesimi",price=30,description="Saçlarını ve sakallarınza değer veriyorsanız bizi seçin!",time=45,imageUrl="~/img/service/3.png"},
            new Service(){name = "Saç + Sakal + Yıkama",price=40,description="Saçlarını ve sakallarınıza değer veriyorsanız bizi seçin!",time=55,imageUrl="~/img/service/3.png"},
            new Service(){name = "Fön",price=10,description="Saçlarınıza yeni bir soluk getirin!",time=10,imageUrl="~/img/service/4.png"},
            new Service(){name = "Saç Şekillendirme",price=20,description="Saçlarınıza yeni bir soluk getirin!",time=15,imageUrl="~/img/service/5.png"},
            new Service(){name = "Ara Makas",price=20,description="Saçlarınıza yeni bir soluk getirin!",time=15,imageUrl="~/img/service/6.png"}
        };

    }
}