<template>
  <div>
    <!-- Page Header -->
    <section class="py-5 bg-primary text-white">
      <div class="container">
        <div class="row">
          <div class="col-12 text-center">
            <h1 class="display-4 fw-bold mb-3">Doktorlarımız</h1>
            <p class="lead">Uzman ve deneyimli doktor kadromuz</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Doctors Content -->
    <section class="py-5">
      <div class="container">
        <div class="row g-4">
          <div class="col-lg-4 col-md-6" v-for="doctor in doctors" :key="doctor.id">
            <div class="card h-100">
              <img :src="doctor.image" class="card-img-top" :alt="doctor.name" style="height: 300px; object-fit: cover;">
              <div class="card-body text-center">
                <h5 class="card-title">{{ doctor.name }}</h5>
                <p class="text-primary fw-bold">{{ doctor.specialty }}</p>
                <p class="card-text text-muted">{{ doctor.description }}</p>
                <div class="row text-center mb-3">
                  <div class="col-6">
                    <small class="text-muted">Deneyim</small><br>
                    <strong>{{ doctor.experience }}</strong>
                  </div>
                  <div class="col-6">
                    <small class="text-muted">Eğitim</small><br>
                    <strong>{{ doctor.education }}</strong>
                  </div>
                </div>
                <div class="d-flex justify-content-center gap-2">
                  <span class="badge bg-light text-dark">{{ doctor.languages }}</span>
                </div>
              </div>
              <div class="card-footer bg-transparent border-0 text-center">
                <router-link to="/randevu-al" class="btn btn-primary">
                  <i class="fas fa-calendar-plus me-1"></i>Randevu Al
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Specialties Section -->
    <section class="py-5 bg-light">
      <div class="container">
        <div class="row text-center mb-5">
          <div class="col-12">
            <h2 class="display-5 fw-bold mb-3">Uzmanlık Alanlarımız</h2>
            <p class="lead text-muted">Farklı branşlarda uzman doktorlarımız</p>
          </div>
        </div>
        <div class="row g-4">
          <div class="col-lg-3 col-md-6" v-for="specialty in specialties" :key="specialty.name">
            <div class="card text-center h-100">
              <div class="card-body p-4">
                <i :class="specialty.icon" class="fa-3x text-primary mb-3"></i>
                <h5 class="card-title">{{ specialty.name }}</h5>
                <p class="card-text text-muted">{{ specialty.description }}</p>
                <div class="mt-3">
                  <span class="badge bg-primary">{{ specialty.doctorCount }} Doktor</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Why Choose Our Doctors -->
    <section class="py-5">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-lg-6">
            <h2 class="display-5 fw-bold mb-4">Neden Doktorlarımızı Seçmelisiniz?</h2>
            <div class="row">
              <div class="col-12 mb-4">
                <div class="d-flex align-items-start">
                  <i class="fas fa-graduation-cap fa-2x text-primary me-3"></i>
                  <div>
                    <h5>Yüksek Eğitim</h5>
                    <p class="text-muted">Türkiye'nin önde gelen üniversitelerinden mezun, sürekli eğitim alan doktorlar.</p>
                  </div>
                </div>
              </div>
              <div class="col-12 mb-4">
                <div class="d-flex align-items-start">
                  <i class="fas fa-award fa-2x text-primary me-3"></i>
                  <div>
                    <h5>Uzmanlık Sertifikaları</h5>
                    <p class="text-muted">Uluslararası geçerliliği olan uzmanlık sertifikalarına sahip doktorlar.</p>
                  </div>
                </div>
              </div>
              <div class="col-12 mb-4">
                <div class="d-flex align-items-start">
                  <i class="fas fa-users fa-2x text-primary me-3"></i>
                  <div>
                    <h5>Hasta Odaklı Yaklaşım</h5>
                    <p class="text-muted">Her hasta için özel çözümler üreten, hasta memnuniyetini ön planda tutan doktorlar.</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-6">
            <img src="https://images.unsplash.com/photo-1582750433449-648ed127bb54?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80" 
                 alt="Doktor Ekibi" class="img-fluid rounded-3 shadow">
          </div>
        </div>
      </div>
    </section>

    <!-- CTA Section -->
    <section class="py-5 bg-primary text-white">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-lg-8">
            <h2 class="display-6 fw-bold mb-3">Doktorlarımızla Randevu Alın</h2>
            <p class="lead mb-0">
              Uzman doktorlarımızdan randevu almak için online randevu sistemimizi kullanabilirsiniz.
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
  name: 'Doctors',
  data() {
    return {
      doctors: [
        {
          id: 1,
          name: 'Dr. Ahmet Yılmaz',
          specialty: 'Genel Cerrahi Uzmanı',
          description: '15 yıllık deneyim ile genel cerrahi alanında uzman. Laparoskopik cerrahi konusunda özel eğitim almış.',
          experience: '15 Yıl',
          education: 'İstanbul Üniversitesi',
          languages: 'Türkçe, İngilizce',
          image: 'https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        },
        {
          id: 2,
          name: 'Dr. Ayşe Demir',
          specialty: 'Kardiyoloji Uzmanı',
          description: 'Kalp ve damar hastalıkları konusunda uzman. Ekokardiografi ve kalp kateterizasyonu konularında deneyimli.',
          experience: '12 Yıl',
          education: 'Hacettepe Üniversitesi',
          languages: 'Türkçe, İngilizce, Almanca',
          image: 'https://images.unsplash.com/photo-1559839734-2b71ea197ec2?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        },
        {
          id: 3,
          name: 'Dr. Mehmet Kaya',
          specialty: 'Dahiliye Uzmanı',
          description: 'İç hastalıkları alanında deneyimli doktor. Diyabet, hipertansiyon ve böbrek hastalıkları konularında uzman.',
          experience: '18 Yıl',
          education: 'Ankara Üniversitesi',
          languages: 'Türkçe, İngilizce',
          image: 'https://images.unsplash.com/photo-1582750433449-648ed127bb54?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        },
        {
          id: 4,
          name: 'Dr. Fatma Özkan',
          specialty: 'Nöroloji Uzmanı',
          description: 'Sinir sistemi hastalıkları konusunda uzman. Epilepsi, migren ve demans hastalıkları konularında deneyimli.',
          experience: '10 Yıl',
          education: 'Ege Üniversitesi',
          languages: 'Türkçe, İngilizce, Fransızca',
          image: 'https://images.unsplash.com/photo-1594824373631-7b5b0e9b5b0e?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        },
        {
          id: 5,
          name: 'Dr. Ali Çelik',
          specialty: 'Ortopedi Uzmanı',
          description: 'Kemik ve eklem hastalıkları konusunda uzman. Artroskopik cerrahi ve protez cerrahisi konularında deneyimli.',
          experience: '14 Yıl',
          education: 'Marmara Üniversitesi',
          languages: 'Türkçe, İngilizce',
          image: 'https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        },
        {
          id: 6,
          name: 'Dr. Zeynep Arslan',
          specialty: 'Kadın Hastalıkları Uzmanı',
          description: 'Kadın sağlığı ve doğum konularında uzman. Jinekolojik onkoloji ve infertilite konularında deneyimli.',
          experience: '16 Yıl',
          education: 'Cerrahpaşa Tıp Fakültesi',
          languages: 'Türkçe, İngilizce, Arapça',
          image: 'https://images.unsplash.com/photo-1559839734-2b71ea197ec2?ixlib=rb-4.0.3&auto=format&fit=crop&w=400&q=80'
        }
      ],
      specialties: [
        {
          name: 'Genel Cerrahi',
          description: 'Laparoskopik ve açık cerrahi müdahaleler',
          icon: 'fas fa-cut',
          doctorCount: 2
        },
        {
          name: 'Kardiyoloji',
          description: 'Kalp ve damar hastalıkları tedavisi',
          icon: 'fas fa-heartbeat',
          doctorCount: 1
        },
        {
          name: 'Dahiliye',
          description: 'İç hastalıkları ve sistemik hastalıklar',
          icon: 'fas fa-stethoscope',
          doctorCount: 1
        },
        {
          name: 'Nöroloji',
          description: 'Sinir sistemi hastalıkları tedavisi',
          icon: 'fas fa-brain',
          doctorCount: 1
        }
      ]
    }
  }
}
</script>

<style scoped>
.card {
  transition: transform 0.3s ease;
}

.card:hover {
  transform: translateY(-5px);
}

.card-img-top {
  border-radius: 15px 15px 0 0;
}

.badge {
  font-size: 0.8rem;
}
</style>