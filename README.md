# Barber Saloon Booking & Shopping System

Bu proje, bir berber salonu için geliştirilmiş kapsamlı bir randevu ve e-ticaret web uygulamasıdır. Müşterilerin kolayca randevu alabilmesini ve salon tarafından satılan ürünleri inceleyip satın alabilmesini sağlar. **ASP.NET Core MVC** mimarisi kullanılarak geliştirilmiştir.

## 🚀 Proje Hakkında

Barber Saloon Booking System, hem hizmet sağlayıcılar hem de müşteriler için süreçleri dijitalleştirmeyi amaçlar. Proje, modern yazılım geliştirme prensiplerine uygun olarak **N-Katmanlı Mimari (N-Tier Architecture)** yapısında kurgulanmıştır.

### Öne Çıkan Özellikler

* **Randevu Sistemi:** Müşterilerin uygun saat aralıklarını görerek berberden randevu alabilmesi.
* **E-Ticaret Modülü:** Salonda satılan ürünlerin listelenmesi ve incelenmesi.
* **Kullanıcı Dostu Arayüz:** Kolay navigasyon ve anlaşılır tasarım.
* **Veri Yönetimi:** Entity Framework Core ile güçlü veritabanı iletişimi.

## 🛠 Teknolojiler ve Araçlar

Proje geliştirilirken aşağıdaki teknolojiler kullanılmıştır:

* **Framework:** .NET Core 3.1 (ASP.NET Core MVC)
* **ORM:** Entity Framework Core 3.1.17
* **Dil:** C#
* **Önyüz:** HTML5, CSS3, SCSS, JavaScript
* **Veritabanı:** MSSQL (LocalDB veya SQL Server)
* **Paket Yönetimi:** NPM (Frontend bağımlılıkları için)

## 📂 Proje Mimarisi

Proje, sorumlulukların ayrılması ilkesine (SoC) dayalı olarak katmanlı bir yapıda geliştirilmiştir:

* **`ui` (User Interface):** Kullanıcının etkileşime girdiği MVC katmanı. Controller ve View'lar burada bulunur.
* **`business`:** İş kurallarının ve mantığının işlendiği katman.
* **`data`:** Veritabanı erişim kodları, Context yapıları ve repository'lerin bulunduğu katman.
* **`entity`:** Veritabanı tablolarına karşılık gelen model sınıflarının bulunduğu katman.

## ⚙️ Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin.

### Gereksinimler

* [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1)
* [Node.js](https://nodejs.org/) (NPM komutları için)
* SQL Server veya LocalDB

### Adım Adım Kurulum

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [https://github.com/anenthusiastic/booking-website-for-barber-saloon.git](https://github.com/anenthusiastic/booking-website-for-barber-saloon.git)
    cd booking-website-for-barber-saloon
    ```

2.  **Frontend Bağımlılıklarını Yükleyin:**
    Gerekli modüllerin indirilmesi için `ui` dizininde veya kök dizinde (package.json neredeyse) şu komutu çalıştırın:
    ```bash
    npm install
    ```

3.  **Entity Framework Araçlarını Yükleyin (Eğer yüklü değilse):**
    Veritabanı migration işlemleri için gereklidir.
    ```bash
    dotnet tool install --global dotnet-ef
    ```

4.  **Veritabanını Oluşturun:**
    Projenin `appsettings.json` dosyasındaki Connection String'i kendi veritabanı sunucunuza göre düzenleyin ve ardından migration'ları uygulayın:
    ```bash
    dotnet ef database update
    ```

5.  **Projeyi Çalıştırın:**
    ```bash
    dotnet run --project ui
    ```

Tarayıcınızda `https://localhost:5001` (veya terminalde belirtilen port) adresine giderek uygulamayı görebilirsiniz.

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen bir "Pull Request" göndermeden önce mevcut sorunları (issues) kontrol edin veya yeni bir özellik eklemek istiyorsanız bir tartışma başlatın.

1.  Bu repoyu "Fork"layın.
2.  Yeni bir "Branch" oluşturun (`git checkout -b feature/yeni-ozellik`).
3.  Değişikliklerinizi "Commit"leyin (`git commit -m 'Yeni özellik eklendi'`).
4.  Branch'inizi "Push"layın (`git push origin feature/yeni-ozellik`).
5.  Bir "Pull Request" oluşturun.

## 📝 Lisans

Bu proje açık kaynaklıdır. Detaylar için [LICENSE](LICENSE) dosyasına bakabilirsiniz.
