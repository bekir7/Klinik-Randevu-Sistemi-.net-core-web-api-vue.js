<template>
  <div>
    <!-- Hero Section -->
    <section class="hero-section py-5">
      <div class="container">
        <div class="row align-items-center min-vh-50">
          <div class="col-lg-6">
            <h1 class="display-4 fw-bold mb-4">
              Sağlığınız İçin <span class="text-warning">Yanınızdayız</span>
            </h1>
            <p class="lead mb-4">
              Modern tıbbi teknoloji ve deneyimli doktor kadromuzla size en iyi sağlık hizmetini sunuyoruz. 
              Randevu almak için hemen başlayın.
            </p>
            <div class="d-flex gap-3">
              <router-link to="/randevu-al" class="btn btn-warning btn-lg">
                <i class="fas fa-calendar-plus me-2"></i>Randevu Al
              </router-link>
              <router-link to="/hakkimizda" class="btn btn-outline-light btn-lg">
                <i class="fas fa-info-circle me-2"></i>Hakkımızda
              </router-link>
            </div>
          </div>
          <div class="col-lg-6 text-center">
            <img src="https://images.unsplash.com/photo-1576091160399-112ba8d25d1f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" 
                 alt="Modern Klinik" class="img-fluid rounded-3 shadow">
          </div>
        </div>
      </div>
    </section>

    <!-- Features Section -->
    <section class="py-5">
      <div class="container">
        <div class="row text-center mb-5">
          <div class="col-12">
            <h2 class="display-5 fw-bold mb-3">Neden Bizi Seçmelisiniz?</h2>
            <p class="lead text-muted">Sağlığınız için en iyi hizmeti sunuyoruz</p>
          </div>
        </div>
        <div class="row g-4">
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-user-md fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">Uzman Doktorlar</h5>
                <p class="card-text text-muted">
                  Alanında uzman, deneyimli doktor kadromuzla size en iyi tıbbi hizmeti sunuyoruz.
                </p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-microscope fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">Modern Teknoloji</h5>
                <p class="card-text text-muted">
                  En son teknoloji ile donatılmış laboratuvar ve muayene odalarımız.
                </p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-clock fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">7/24 Hizmet</h5>
                <p class="card-text text-muted">
                  Acil durumlar için 7 gün 24 saat hizmet veriyoruz.
                </p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-calendar-check fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">Kolay Randevu</h5>
                <p class="card-text text-muted">
                  Online randevu sistemi ile kolayca randevu alabilirsiniz.
                </p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-shield-alt fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">Güvenli Ortam</h5>
                <p class="card-text text-muted">
                  Hijyenik ve güvenli ortamda sağlık hizmeti alırsınız.
                </p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-md-6">
            <div class="card h-100 text-center p-4">
              <div class="card-body">
                <div class="feature-icon mb-3">
                  <i class="fas fa-heart fa-3x text-primary"></i>
                </div>
                <h5 class="card-title">Hasta Odaklı</h5>
                <p class="card-text text-muted">
                  Hasta memnuniyeti bizim önceliğimizdir.
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Stats Section -->
    <section class="py-5 bg-light">
      <div class="container">
        <div class="row text-center">
          <div class="col-lg-3 col-md-6 mb-4">
            <div class="stat-item">
              <h3 class="display-4 fw-bold text-primary">5000+</h3>
              <p class="text-muted">Mutlu Hasta</p>
            </div>
          </div>
          <div class="col-lg-3 col-md-6 mb-4">
            <div class="stat-item">
              <h3 class="display-4 fw-bold text-primary">15+</h3>
              <p class="text-muted">Uzman Doktor</p>
            </div>
          </div>
          <div class="col-lg-3 col-md-6 mb-4">
            <div class="stat-item">
              <h3 class="display-4 fw-bold text-primary">10+</h3>
              <p class="text-muted">Yıllık Deneyim</p>
            </div>
          </div>
          <div class="col-lg-3 col-md-6 mb-4">
            <div class="stat-item">
              <h3 class="display-4 fw-bold text-primary">24/7</h3>
              <p class="text-muted">Acil Hizmet</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- CTA Section -->
    <section class="py-5 bg-primary text-white">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-lg-8">
            <h2 class="display-6 fw-bold mb-3">Sağlığınız İçin Hemen Randevu Alın</h2>
            <p class="lead mb-0">
              Online randevu sistemi ile kolayca randevu alabilir, sağlığınızı öncelik haline getirebilirsiniz.
            </p>
          </div>
          <div class="col-lg-4 text-lg-end">
            <router-link to="/randevu-al" class="btn btn-warning btn-lg">
              <i class="fas fa-calendar-plus me-2"></i>Randevu Al
            </router-link>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped>
.min-vh-50 {
  min-height: 50vh;
}

.feature-icon {
  height: 80px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.stat-item {
  padding: 2rem 0;
}

.hero-section {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.btn {
  transition: all 0.3s ease;
}

.btn:hover {
  transform: translateY(-2px);
}
</style>
