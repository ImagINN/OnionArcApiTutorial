# OnionArcApiTutorial

Onion Architecture prensipleriyle katmanlı bir .NET Web API örneği.  
Amaç; domain odaklı, gevşek bağlı (loosely coupled), test edilebilir ve genişletilebilir bir API iskeleti oluşturmaktır.

---

## 📑 İçindekiler

- [Amaçlar](#amaçlar)
- [Mimari Genel Bakış](#mimari-genel-bakış)
- [Teknolojiler](#teknolojiler)
- [Önkoşullar](#önkoşullar)
- [Kurulum](#kurulum)
- [Çalıştırma](#çalıştırma)
- [Veritabanı (EF Core) – Migration & Seed](#veritabanı-ef-core--migration--seed)
- [Yapı ve Katmanlar](#yapı-ve-katmanlar)
- [Konfigürasyon](#konfigürasyon)
- [Logging & Hata Yönetimi](#logging--hata-yönetimi)
- [Swagger / OpenAPI](#swagger--openapi)
- [Test Stratejisi](#test-stratejisi)
- [Roadmap](#roadmap)
- [Lisans](#lisans)

---

## 🎯 Amaçlar

- Domain’i merkeze alan, UI/infra bağımlılıklarından soyutlanmış bir mimari kurmak  
- SOLID prensiplerine uygun, bağımlılık tersine çevirmeyi (DIP) benimseyen bir yapı  
- Birim testlenebilir service/domain katmanı  
- Genişlemeye ve yer değiştirmeye uygun altyapı (örn. farklı DB/Cache sağlayıcılarına geçiş)  
- Geliştiriciler için okunabilir, standart bir klasörleme ve isimlendirme  

---

## 🏛 Mimari Genel Bakış

Onion Architecture, bağımlılıkların **dıştan içe** akmasını engeller; **iç katmanlar dış katmanlardan habersizdir**.  
Bağımlılıklar **Core → Infrastructure → Presentation** yönünde **değil**, arayüzler üzerinden **Presentation/Infrastructure → Core** yönünde çözülür.

- **Core (Domain Katmanı)**  
  - Entities, Value Objects, Domain Servisleri, Arayüzler (IRepository vb.)
- **Infrastructure (Altyapı Katmanı)**  
  - EF Core DbContext, Repository implementasyonları, dış servis adaptörleri
- **Presentation (WebApi Katmanı)**  
  - Controller/Endpoint, DTO’lar, Mapping, Middleware, Swagger

---

## 🛠 Teknolojiler

- **.NET 7 / .NET 8**  
- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **Swagger / Swashbuckle**  
- (Opsiyonel) **FluentValidation**, **AutoMapper/Mapster**, **Serilog**

---

## 📋 Önkoşullar

- .NET SDK (7 veya 8)  
- Bir veritabanı sunucusu (SQL Server, PostgreSQL vb.)  
- (Opsiyonel) Docker  
- İnternet bağlantısı (NuGet paketleri için)

---

## ⚙️ Kurulum

```bash
# 1) Repoyu klonla
git clone https://github.com/ImagINN/OnionArcApiTutorial.git
cd OnionArcApiTutorial

# 2) Paketleri geri yükle ve projeyi derle
dotnet restore
dotnet build

# 3) appsettings.json dosyasını düzenle (connection string vb.)
dotnet run --project Presentation/OnionArc.WebApi/OnionArc.WebApi.csproj

# Migration oluştur
dotnet ef migrations add InitialCreate \
  --project Infrastructure/Infrastructure.csproj \
  --startup-project Presentation/OnionArc.WebApi/OnionArc.WebApi.csproj

# Veritabanını güncelle
dotnet ef database update \
  --project Infrastructure/Infrastructure.csproj \
  --startup-project Presentation/OnionArc.WebApi/OnionArc.WebApi.csproj

OnionArcApiTutorial/
├─ Core/
│  ├─ Domain/          # Entities, Value Objects
│  ├─ Abstractions/    # IRepository, IService interface’leri
│  └─ ...
│
├─ Infrastructure/
│  ├─ Persistence/     # DbContext, Migrations
│  ├─ Repositories/    # Repository implementasyonları
│  └─ ...
│
└─ Presentation/
   └─ OnionArc.WebApi/
      ├─ Controllers/  # REST endpoint’leri
      ├─ Dtos/         # Request/Response modelleri
      ├─ Mapping/      # AutoMapper/Mapster profilleri
      ├─ Middlewares/  # Exception Handling, Logging
      └─ Program.cs

