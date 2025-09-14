# 🏥 Merkez Klinik Randevu Sistemi

Modern ve kullanıcı dostu klinik randevu yönetim sistemi. Hem hasta tarafından randevu alma hem de doktor tarafından randevu yönetimi için tasarlanmıştır.

## ✨ Özellikler

### 🏠 **Hasta Tarafı**

- **Modern Web Sitesi**: Responsive tasarım ile mobil uyumlu
- **Online Randevu Alma**: 4 adımlı kolay randevu formu
- **Doktor Seçimi**: Uzmanlık alanına göre filtreleme
- **Müsait Saat Kontrolü**: Gerçek zamanlı müsait saat gösterimi
- **Randevu Takibi**: Randevu geçmişi ve durumu

### 👨‍⚕️ **Doktor Tarafı**

- **Doktor Paneli**: Kapsamlı yönetim paneli
- **Randevu Yönetimi**: Randevuları görüntüleme, tamamlama, iptal etme
- **Hasta Bilgileri**: Hasta detaylarını görüntüleme
- **Program Yönetimi**: Çalışma saatleri ayarlama
- **İstatistikler**: Günlük ve genel istatistikler

### 🏥 **Klinik Yönetimi**

- **Hasta Kayıt Sistemi**: Otomatik hasta kaydı
- **Doktor Programları**: Esnek çalışma saatleri
- **Randevu Takvimi**: Görsel takvim arayüzü
- **Raporlama**: Detaylı raporlar ve analizler

## 🛠️ Teknoloji Stack

### **Backend**

- **.NET 8.0** - Modern C# framework
- **ASP.NET Core Web API** - RESTful API
- **Entity Framework Core** - ORM ve veritabanı yönetimi
- **SQL Server** - Veritabanı
- **Swagger/OpenAPI** - API dokümantasyonu

### **Frontend**

- **Vue.js 3** - Modern JavaScript framework
- **Vue Router** - Sayfa yönlendirme
- **Axios** - HTTP istekleri
- **Bootstrap 5** - UI framework
- **Font Awesome** - İkonlar
- **Vite** - Build tool

## 🚀 Kurulum

### **Gereksinimler**

- .NET 8.0 SDK
- SQL Server (LocalDB veya SQL Server)
- Node.js 16+
- npm veya yarn

### **Backend Kurulumu**

1. **Projeyi klonlayın**

```bash
git clone <repository-url>
cd RandevuSistemiv2
```

2. **Backend dizinine gidin**

```bash
cd RandevuSistemiv2
```

3. **NuGet paketlerini yükleyin**

```bash
dotnet restore
```

4. **Veritabanı bağlantı stringini ayarlayın**
   `appsettings.json` dosyasında connection string'i düzenleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RandevuSistemiDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

5. **Veritabanını oluşturun**

```bash
dotnet ef database update
```

6. **Backend'i başlatın**

```bash
dotnet run
```

Backend `http://localhost:5208` adresinde çalışacaktır.

### **Frontend Kurulumu**

1. **Frontend dizinine gidin**

```bash
cd frontend
```

2. **Bağımlılıkları yükleyin**

```bash
npm install
```

3. **Frontend'i başlatın**

```bash
npm run dev
```

Frontend `http://localhost:3000` adresinde çalışacaktır.

## 📱 Kullanım

### **Hasta Kullanımı**

1. **Web sitesine gidin**: `http://localhost:3000`
2. **Randevu Al** butonuna tıklayın
3. **4 adımlı formu doldurun**:
   - Hasta bilgileri
   - Doktor seçimi
   - Tarih ve saat seçimi
   - Onay
4. **Randevunuz oluşturulacak**

### **Doktor Kullanımı**

1. **Doktor Girişi** sayfasına gidin: `http://localhost:3000/doktor-giris`
2. **Demo giriş bilgileri**:
   - E-posta: `doktor@merkezklinik.com`
   - Şifre: `123456`
3. **Doktor paneline erişin** ve randevuları yönetin

## 🔧 API Endpoints

### **Hastalar**

- `GET /api/patients` - Tüm hastalar
- `GET /api/patients/{id}` - Hasta detayı
- `GET /api/patients/tc/{tcNumber}` - TC'ye göre hasta
- `POST /api/patients` - Yeni hasta oluştur
- `PUT /api/patients/{id}` - Hasta güncelle
- `DELETE /api/patients/{id}` - Hasta sil

### **Doktorlar**

- `GET /api/doctors` - Tüm doktorlar
- `GET /api/doctors/active` - Aktif doktorlar
- `GET /api/doctors/{id}` - Doktor detayı
- `POST /api/doctors` - Yeni doktor oluştur
- `PUT /api/doctors/{id}` - Doktor güncelle
- `DELETE /api/doctors/{id}` - Doktor sil

### **Randevular**

- `GET /api/appointments` - Tüm randevular
- `GET /api/appointments/{id}` - Randevu detayı
- `GET /api/appointments/available/{doctorId}?date={date}` - Müsait saatler
- `POST /api/appointments` - Yeni randevu oluştur
- `PUT /api/appointments/{id}` - Randevu güncelle
- `PUT /api/appointments/{id}/cancel` - Randevu iptal et
- `PUT /api/appointments/{id}/complete` - Randevu tamamla
- `DELETE /api/appointments/{id}` - Randevu sil

## 📊 Veritabanı Yapısı

### **Tablolar**

- **Patients** - Hasta bilgileri
- **Doctors** - Doktor bilgileri
- **Appointments** - Randevu bilgileri
- **DoctorSchedules** - Doktor çalışma programları
- **Clinics** - Klinik bilgileri

### **İlişkiler**

- Hasta → Randevular (1:N)
- Doktor → Randevular (1:N)
- Doktor → Programlar (1:N)

## 🎨 Tasarım Özellikleri

- **Responsive Design**: Tüm cihazlarda mükemmel görünüm
- **Modern UI**: Bootstrap 5 ile şık tasarım
- **Kullanıcı Dostu**: Sezgisel navigasyon
- **Hızlı**: Optimize edilmiş performans
- **Güvenli**: Güvenli veri işleme

## 🔒 Güvenlik

- **CORS**: Cross-origin istekler için yapılandırılmış
- **Validation**: Kapsamlı veri doğrulama
- **Error Handling**: Güvenli hata yönetimi
- **SQL Injection**: Entity Framework ile korunma

## 📈 Performans

- **Lazy Loading**: Veritabanı optimizasyonu
- **Caching**: Hızlı veri erişimi
- **Async/Await**: Asenkron işlemler
- **Pagination**: Büyük veri setleri için sayfalama

## 🐛 Hata Ayıklama

### **Backend Logları**

```bash
dotnet run --verbosity detailed
```

### **Frontend Console**

Tarayıcıda F12 tuşuna basarak console'u açın.

### **Swagger UI**

API testi için: `http://localhost:5208`

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Push yapın (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## Ekran Görüntüsü

<img width="1920" height="1080" alt="Ekran Görüntüsü (457)" src="https://github.com/user-attachments/assets/1125fdc8-18ce-4898-b080-1761c188caac" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (456)" src="https://github.com/user-attachments/assets/5018bf5a-e572-4602-8140-0801d3b89978" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (463)" src="https://github.com/user-attachments/assets/574e5f05-3cbf-4a2d-b9e2-6240f4227fcd" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (462)" src="https://github.com/user-attachments/assets/86373172-2cbc-4c96-bdd1-4313eeeba3bd" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (461)" src="https://github.com/user-attachments/assets/ea88af8a-9fae-4307-82de-0413221f303c" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (460)" src="https://github.com/user-attachments/assets/f7bd23e6-fc8d-4b75-a379-4afb3abaeeb3" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (459)" src="https://github.com/user-attachments/assets/9bf7ba17-aa3b-4ae3-b11c-37feacdc298d" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (458)" src="https://github.com/user-attachments/assets/fb6d5c96-d635-4f40-8b96-35be9a18f7fa" />
