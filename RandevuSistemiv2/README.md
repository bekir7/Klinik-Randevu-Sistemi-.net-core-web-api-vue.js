# Randevu Sistemi API

Klinik için geliştirilmiş randevu sistemi backend API'si.

## Özellikler

- **Hasta Yönetimi**: Hasta kayıt, güncelleme, silme ve listeleme
- **Doktor Yönetimi**: Doktor kayıt, güncelleme, silme ve listeleme
- **Randevu Yönetimi**: Randevu oluşturma, güncelleme, iptal etme ve tamamlama
- **Zaman Dilimi Kontrolü**: Doktor müsaitlik durumu ve çakışma kontrolü
- **Swagger UI**: API dokümantasyonu ve test arayüzü

## Teknolojiler

- .NET 8.0
- Entity Framework Core
- SQL Server LocalDB
- Swagger/OpenAPI
- CORS desteği

## Kurulum

1. Projeyi klonlayın
2. `dotnet restore` komutu ile paketleri yükleyin
3. `dotnet build` komutu ile projeyi derleyin
4. `dotnet run` komutu ile projeyi çalıştırın

## API Endpoints

### Hastalar (Patients)

- `GET /api/patients` - Tüm hastaları listele
- `GET /api/patients/{id}` - ID'ye göre hasta getir
- `GET /api/patients/tc/{tcNumber}` - TC numarasına göre hasta getir
- `POST /api/patients` - Yeni hasta oluştur
- `PUT /api/patients/{id}` - Hasta bilgilerini güncelle
- `DELETE /api/patients/{id}` - Hastayı sil

### Doktorlar (Doctors)

- `GET /api/doctors` - Tüm doktorları listele
- `GET /api/doctors/active` - Aktif doktorları listele
- `GET /api/doctors/{id}` - ID'ye göre doktor getir
- `GET /api/doctors/tc/{tcNumber}` - TC numarasına göre doktor getir
- `GET /api/doctors/specialty/{specialty}` - Uzmanlık alanına göre doktorları getir
- `POST /api/doctors` - Yeni doktor oluştur
- `PUT /api/doctors/{id}` - Doktor bilgilerini güncelle
- `DELETE /api/doctors/{id}` - Doktoru sil

### Randevular (Appointments)

- `GET /api/appointments` - Tüm randevuları listele
- `GET /api/appointments/{id}` - ID'ye göre randevu getir
- `GET /api/appointments/patient/{patientId}` - Hasta ID'sine göre randevuları getir
- `GET /api/appointments/doctor/{doctorId}` - Doktor ID'sine göre randevuları getir
- `GET /api/appointments/date/{date}` - Tarihe göre randevuları getir
- `GET /api/appointments/daterange?startDate={date}&endDate={date}` - Tarih aralığına göre randevuları getir
- `GET /api/appointments/available/{doctorId}?date={date}` - Doktor için müsait zaman dilimlerini getir
- `POST /api/appointments` - Yeni randevu oluştur
- `PUT /api/appointments/{id}` - Randevu bilgilerini güncelle
- `PUT /api/appointments/{id}/cancel` - Randevuyu iptal et
- `PUT /api/appointments/{id}/complete` - Randevuyu tamamla
- `DELETE /api/appointments/{id}` - Randevuyu sil

## Veritabanı

Proje SQL Server LocalDB kullanır. İlk çalıştırmada veritabanı otomatik olarak oluşturulur ve örnek veriler eklenir.

### Örnek Veriler

- **Klinik**: Merkez Klinik
- **Doktorlar**:
  - Dr. Ahmet Yılmaz (Genel Cerrahi)
  - Dr. Ayşe Demir (Kardiyoloji)
- **Doktor Programları**: Haftalık çalışma saatleri tanımlanmış

## Swagger UI

Proje çalıştığında Swagger UI otomatik olarak açılır: `https://localhost:7000` veya `http://localhost:5000`

## CORS

API tüm origin'lere açıktır (development için). Production'da güvenlik için kısıtlanmalıdır.

## Örnek Kullanım

### Yeni Hasta Oluşturma

```json
POST /api/patients
{
  "firstName": "Mehmet",
  "lastName": "Kaya",
  "tcNumber": "12345678903",
  "phoneNumber": "0532-555-0103",
  "email": "mehmet.kaya@email.com",
  "birthDate": "1990-05-15",
  "gender": "Erkek",
  "address": "İstanbul, Türkiye"
}
```

### Yeni Randevu Oluşturma

```json
POST /api/appointments
{
  "patientId": 1,
  "doctorId": 1,
  "appointmentDate": "2024-01-15",
  "startTime": "10:00:00",
  "notes": "Kontrol muayenesi"
}
```

## Geliştirme Notları

- Tüm tarih/saat işlemleri UTC olarak saklanır
- TC numarası benzersizlik kontrolü yapılır
- Randevu çakışma kontrolü otomatik yapılır
- Doktor programına göre müsait zaman dilimleri hesaplanır
- Soft delete yerine hard delete kullanılır (randevu geçmişi korunur)

