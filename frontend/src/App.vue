<template>
  <div id="app">
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm fixed-top">
      <div class="container">
        <router-link to="/" class="navbar-brand d-flex align-items-center">
          <i class="fas fa-heartbeat text-primary me-2"></i>
          <span class="fw-bold">Merkez Klinik</span>
        </router-link>
        
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
          <span class="navbar-toggler-icon"></span>
        </button>
        
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav me-auto">
            <li class="nav-item">
              <router-link to="/" class="nav-link" :class="{ active: $route.path === '/' }">Ana Sayfa</router-link>
            </li>
            <li class="nav-item">
              <router-link to="/hakkimizda" class="nav-link" :class="{ active: $route.path === '/hakkimizda' }">Hakkımızda</router-link>
            </li>
            <li class="nav-item">
              <router-link to="/hizmetlerimiz" class="nav-link" :class="{ active: $route.path === '/hizmetlerimiz' }">Hizmetlerimiz</router-link>
            </li>
            <li class="nav-item">
              <router-link to="/doktorlarimiz" class="nav-link" :class="{ active: $route.path === '/doktorlarimiz' }">Doktorlarımız</router-link>
            </li>
            <li class="nav-item">
              <router-link to="/iletisim" class="nav-link" :class="{ active: $route.path === '/iletisim' }">İletişim</router-link>
            </li>
          </ul>
          <div class="d-flex gap-2">
            <router-link to="/randevu-al" class="btn btn-primary">
              <i class="fas fa-calendar-plus me-1"></i>Randevu Al
            </router-link>
            <router-link to="/doktor-giris" class="btn btn-outline-primary">
              <i class="fas fa-user-md me-1"></i>Doktor Girişi
            </router-link>
          </div>
        </div>
      </div>
    </nav>

    <!-- Main Content -->
    <main style="margin-top: 80px;">
      <router-view></router-view>
    </main>

    <!-- Footer -->
    <footer class="bg-dark text-light py-5 mt-5">
      <div class="container">
        <div class="row">
          <div class="col-lg-4 mb-4">
            <h5 class="text-primary mb-3">
              <i class="fas fa-heartbeat me-2"></i>Merkez Klinik
            </h5>
            <p class="text-muted">
              Sağlığınız bizim önceliğimiz. Modern tıbbi teknoloji ve deneyimli doktor kadromuzla 
              size en iyi sağlık hizmetini sunuyoruz.
            </p>
            <div class="d-flex gap-3">
              <a href="#" class="text-primary"><i class="fab fa-facebook fa-lg"></i></a>
              <a href="#" class="text-primary"><i class="fab fa-twitter fa-lg"></i></a>
              <a href="#" class="text-primary"><i class="fab fa-instagram fa-lg"></i></a>
              <a href="#" class="text-primary"><i class="fab fa-linkedin fa-lg"></i></a>
            </div>
          </div>
          <div class="col-lg-2 col-md-6 mb-4">
            <h6 class="text-primary mb-3">Hızlı Linkler</h6>
            <ul class="list-unstyled">
              <li><router-link to="/" class="text-muted text-decoration-none">Ana Sayfa</router-link></li>
              <li><router-link to="/hakkimizda" class="text-muted text-decoration-none">Hakkımızda</router-link></li>
              <li><router-link to="/hizmetlerimiz" class="text-muted text-decoration-none">Hizmetlerimiz</router-link></li>
              <li><router-link to="/doktorlarimiz" class="text-muted text-decoration-none">Doktorlarımız</router-link></li>
            </ul>
          </div>
          <div class="col-lg-3 col-md-6 mb-4">
            <h6 class="text-primary mb-3">İletişim Bilgileri</h6>
            <ul class="list-unstyled text-muted">
              <li class="mb-2">
                <i class="fas fa-map-marker-alt me-2"></i>
                Merkez Mahallesi, Sağlık Caddesi No:1
              </li>
              <li class="mb-2">
                <i class="fas fa-phone me-2"></i>
                +90 212 555 0101
              </li>
              <li class="mb-2">
                <i class="fas fa-envelope me-2"></i>
                info@merkezklinik.com
              </li>
            </ul>
          </div>
          <div class="col-lg-3 col-md-6 mb-4">
            <h6 class="text-primary mb-3">Çalışma Saatleri</h6>
            <ul class="list-unstyled text-muted">
              <li class="mb-1">Pazartesi - Cuma: 09:00 - 18:00</li>
              <li class="mb-1">Cumartesi: 09:00 - 14:00</li>
              <li class="mb-1">Pazar: Kapalı</li>
              <li class="mb-1 mt-3">
                <small class="text-warning">
                  <i class="fas fa-exclamation-triangle me-1"></i>
                  Acil durumlar için 7/24 hizmet
                </small>
              </li>
            </ul>
          </div>
        </div>
        <hr class="my-4">
        <div class="row align-items-center">
          <div class="col-md-6">
            <p class="text-muted mb-0">&copy; 2024 Merkez Klinik. Tüm hakları saklıdır.</p>
          </div>
          <div class="col-md-6 text-md-end">
            <small class="text-muted">Güvenli ve modern sağlık hizmetleri</small>
          </div>
        </div>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
.navbar-brand {
  font-size: 1.5rem;
}

.nav-link.active {
  color: #0d6efd !important;
  font-weight: 600;
}

.nav-link:hover {
  color: #0d6efd !important;
}

.btn {
  border-radius: 25px;
  padding: 8px 20px;
  font-weight: 500;
}

footer a:hover {
  color: #0d6efd !important;
}

.hero-section {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
}

.card {
  border: none;
  border-radius: 15px;
  box-shadow: 0 5px 15px rgba(0,0,0,0.08);
  transition: transform 0.3s ease;
}

.card:hover {
  transform: translateY(-5px);
}

.text-primary {
  color: #0d6efd !important;
}

.bg-primary {
  background-color: #0d6efd !important;
}
</style>