<template>
  <div>
    <!-- Page Header -->
    <section class="py-5 bg-primary text-white">
      <div class="container">
        <div class="row">
          <div class="col-12 text-center">
            <h1 class="display-4 fw-bold mb-3">İletişim</h1>
            <p class="lead">Bizimle iletişime geçin</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Contact Content -->
    <section class="py-5">
      <div class="container">
        <div class="row">
          <div class="col-lg-8">
            <div class="card">
              <div class="card-header bg-primary text-white">
                <h5 class="mb-0">
                  <i class="fas fa-envelope me-2"></i>Bize Mesaj Gönderin
                </h5>
              </div>
              <div class="card-body p-4">
                <form @submit.prevent="submitForm">
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Ad Soyad *</label>
                        <input type="text" class="form-control" v-model="form.name" required>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">E-posta *</label>
                        <input type="email" class="form-control" v-model="form.email" required>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Telefon</label>
                        <input type="tel" class="form-control" v-model="form.phone">
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Konu</label>
                        <select class="form-select" v-model="form.subject">
                          <option value="">Konu Seçiniz</option>
                          <option value="randevu">Randevu</option>
                          <option value="bilgi">Genel Bilgi</option>
                          <option value="şikayet">Şikayet</option>
                          <option value="öneri">Öneri</option>
                          <option value="diğer">Diğer</option>
                        </select>
                      </div>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="form-label">Mesaj *</label>
                    <textarea class="form-control" rows="5" v-model="form.message" required></textarea>
                  </div>
                  <button type="submit" class="btn btn-primary" :disabled="loading">
                    <i class="fas fa-paper-plane me-2"></i>
                    {{ loading ? 'Gönderiliyor...' : 'Mesaj Gönder' }}
                  </button>
                </form>
              </div>
            </div>
          </div>
          <div class="col-lg-4">
            <!-- Contact Info -->
            <div class="card mb-4">
              <div class="card-header bg-primary text-white">
                <h5 class="mb-0">
                  <i class="fas fa-map-marker-alt me-2"></i>İletişim Bilgileri
                </h5>
              </div>
              <div class="card-body">
                <div class="mb-3">
                  <h6 class="text-primary">Adres</h6>
                  <p class="text-muted mb-0">
                    Merkez Mahallesi, Sağlık Caddesi No:1<br>
                    34000 İstanbul, Türkiye
                  </p>
                </div>
                <div class="mb-3">
                  <h6 class="text-primary">Telefon</h6>
                  <p class="text-muted mb-0">
                    <a href="tel:+902125550101" class="text-decoration-none">+90 212 555 01 01</a><br>
                    <a href="tel:+902125550102" class="text-decoration-none">+90 212 555 01 02</a>
                  </p>
                </div>
                <div class="mb-3">
                  <h6 class="text-primary">E-posta</h6>
                  <p class="text-muted mb-0">
                    <a href="mailto:info@merkezklinik.com" class="text-decoration-none">info@merkezklinik.com</a><br>
                    <a href="mailto:randevu@merkezklinik.com" class="text-decoration-none">randevu@merkezklinik.com</a>
                  </p>
                </div>
                <div class="mb-3">
                  <h6 class="text-primary">Çalışma Saatleri</h6>
                  <p class="text-muted mb-0">
                    <strong>Pazartesi - Cuma:</strong> 09:00 - 18:00<br>
                    <strong>Cumartesi:</strong> 09:00 - 14:00<br>
                    <strong>Pazar:</strong> Kapalı<br>
                    <small class="text-warning">
                      <i class="fas fa-exclamation-triangle me-1"></i>
                      Acil durumlar için 7/24 hizmet
                    </small>
                  </p>
                </div>
              </div>
            </div>

            <!-- Quick Actions -->
            <div class="card">
              <div class="card-header bg-success text-white">
                <h5 class="mb-0">
                  <i class="fas fa-bolt me-2"></i>Hızlı İşlemler
                </h5>
              </div>
              <div class="card-body text-center">
                <router-link to="/randevu-al" class="btn btn-primary w-100 mb-2">
                  <i class="fas fa-calendar-plus me-2"></i>Randevu Al
                </router-link>
                <a href="tel:+902125550101" class="btn btn-outline-primary w-100 mb-2">
                  <i class="fas fa-phone me-2"></i>Ara
                </a>
                <a href="https://wa.me/902125550101" class="btn btn-outline-success w-100" target="_blank">
                  <i class="fab fa-whatsapp me-2"></i>WhatsApp
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Map Section -->
    <section class="py-5 bg-light">
      <div class="container">
        <div class="row">
          <div class="col-12">
            <h2 class="text-center mb-4">Konumumuz</h2>
            <div class="card">
              <div class="card-body p-0">
                <div class="map-container" style="height: 400px; background: #f8f9fa; display: flex; align-items: center; justify-content: center;">
                  <div class="text-center text-muted">
                    <i class="fas fa-map-marked-alt fa-3x mb-3"></i>
                    <h5>Harita</h5>
                    <p>Merkez Mahallesi, Sağlık Caddesi No:1<br>34000 İstanbul, Türkiye</p>
                    <a href="https://maps.google.com" target="_blank" class="btn btn-primary">
                      <i class="fas fa-external-link-alt me-2"></i>Google Maps'te Aç
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Emergency Contact -->
    <section class="py-5 bg-danger text-white">
      <div class="container">
        <div class="row text-center">
          <div class="col-12">
            <h2 class="display-6 fw-bold mb-3">
              <i class="fas fa-ambulance me-2"></i>Acil Durum
            </h2>
            <p class="lead mb-4">
              Acil sağlık durumlarında 7/24 hizmet veriyoruz
            </p>
            <div class="row">
              <div class="col-md-4 mb-3">
                <div class="d-flex align-items-center justify-content-center">
                  <i class="fas fa-phone fa-2x me-3"></i>
                  <div>
                    <h5 class="mb-0">Acil Hat</h5>
                    <p class="mb-0">+90 212 555 01 11</p>
                  </div>
                </div>
              </div>
              <div class="col-md-4 mb-3">
                <div class="d-flex align-items-center justify-content-center">
                  <i class="fas fa-ambulance fa-2x me-3"></i>
                  <div>
                    <h5 class="mb-0">Ambulans</h5>
                    <p class="mb-0">+90 212 555 01 12</p>
                  </div>
                </div>
              </div>
              <div class="col-md-4 mb-3">
                <div class="d-flex align-items-center justify-content-center">
                  <i class="fas fa-user-md fa-2x me-3"></i>
                  <div>
                    <h5 class="mb-0">Doktor Nöbet</h5>
                    <p class="mb-0">+90 212 555 01 13</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: 'Contact',
  data() {
    return {
      loading: false,
      form: {
        name: '',
        email: '',
        phone: '',
        subject: '',
        message: ''
      }
    }
  },
  methods: {
    async submitForm() {
      this.loading = true
      try {
        // Simulate form submission
        await new Promise(resolve => setTimeout(resolve, 2000))
        alert('Mesajınız başarıyla gönderildi! En kısa sürede size dönüş yapacağız.')
        this.form = {
          name: '',
          email: '',
          phone: '',
          subject: '',
          message: ''
        }
      } catch (error) {
        alert('Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.')
      } finally {
        this.loading = false
      }
    }
  }
}
</script>

<style scoped>
.card {
  border: none;
  border-radius: 15px;
  box-shadow: 0 5px 15px rgba(0,0,0,0.08);
}

.form-control:focus,
.form-select:focus {
  border-color: #0d6efd;
  box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.25);
}

.btn {
  border-radius: 25px;
  padding: 10px 25px;
  font-weight: 500;
}

.map-container {
  border-radius: 15px;
}
</style>
