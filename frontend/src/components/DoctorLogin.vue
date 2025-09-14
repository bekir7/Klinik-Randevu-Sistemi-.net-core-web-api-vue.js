<template>
  <div class="min-vh-100 d-flex align-items-center bg-light">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-6 col-lg-4">
          <div class="card shadow">
            <div class="card-body p-5">
              <div class="text-center mb-4">
                <i class="fas fa-user-md fa-3x text-primary mb-3"></i>
                <h3 class="fw-bold">Doktor Girişi</h3>
                <p class="text-muted">Doktor paneline erişim için giriş yapın</p>
              </div>

              <form @submit.prevent="login">
                <div class="mb-3">
                  <label class="form-label">E-posta</label>
                  <div class="input-group">
                    <span class="input-group-text">
                      <i class="fas fa-envelope"></i>
                    </span>
                    <input 
                      type="email" 
                      class="form-control" 
                      v-model="form.email" 
                      placeholder="ornek@merkezklinik.com"
                      required
                    >
                  </div>
                </div>

                <div class="mb-3">
                  <label class="form-label">Şifre</label>
                  <div class="input-group">
                    <span class="input-group-text">
                      <i class="fas fa-lock"></i>
                    </span>
                    <input 
                      :type="showPassword ? 'text' : 'password'" 
                      class="form-control" 
                      v-model="form.password" 
                      placeholder="Şifrenizi girin"
                      required
                    >
                    <button 
                      type="button" 
                      class="btn btn-outline-secondary" 
                      @click="showPassword = !showPassword"
                    >
                      <i :class="showPassword ? 'fas fa-eye-slash' : 'fas fa-eye'"></i>
                    </button>
                  </div>
                </div>

                <div class="mb-3 form-check">
                  <input type="checkbox" class="form-check-input" v-model="form.remember">
                  <label class="form-check-label">Beni hatırla</label>
                </div>

                <button 
                  type="submit" 
                  class="btn btn-primary w-100 mb-3" 
                  :disabled="loading"
                >
                  <i class="fas fa-sign-in-alt me-2"></i>
                  {{ loading ? 'Giriş yapılıyor...' : 'Giriş Yap' }}
                </button>

                <div class="text-center">
                  <a href="#" class="text-decoration-none">Şifremi unuttum</a>
                </div>
              </form>
            </div>
          </div>

          <!-- Demo Credentials -->
          <div class="card mt-4">
            <div class="card-body">
              <h6 class="card-title text-primary">
                <i class="fas fa-info-circle me-2"></i>Demo Giriş Bilgileri
              </h6>
              <div class="row">
                <div class="col-6">
                  <small class="text-muted">E-posta:</small><br>
                  <code>doktor@merkezklinik.com</code>
                </div>
                <div class="col-6">
                  <small class="text-muted">Şifre:</small><br>
                  <code>123456</code>
                </div>
              </div>
              <button 
                class="btn btn-outline-primary btn-sm mt-2 w-100" 
                @click="fillDemoCredentials"
              >
                Demo Bilgileri Doldur
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'DoctorLogin',
  data() {
    return {
      loading: false,
      showPassword: false,
      form: {
        email: '',
        password: '',
        remember: false
      }
    }
  },
  methods: {
    async login() {
      this.loading = true
      try {
        // Simulate login process
        await new Promise(resolve => setTimeout(resolve, 2000))
        
        // Check credentials (demo)
        if (this.form.email === 'doktor@merkezklinik.com' && this.form.password === '123456') {
          // Store login state
          localStorage.setItem('doctorLoggedIn', 'true')
          localStorage.setItem('doctorEmail', this.form.email)
          
          // Redirect to doctor dashboard
          this.$router.push('/doktor-panel')
        } else {
          alert('E-posta veya şifre hatalı!')
        }
      } catch (error) {
        alert('Giriş yapılırken bir hata oluştu!')
      } finally {
        this.loading = false
      }
    },
    fillDemoCredentials() {
      this.form.email = 'doktor@merkezklinik.com'
      this.form.password = '123456'
    }
  }
}
</script>

<style scoped>
.min-vh-100 {
  min-height: 100vh;
}

.card {
  border: none;
  border-radius: 15px;
  box-shadow: 0 5px 15px rgba(0,0,0,0.08);
}

.form-control:focus {
  border-color: #0d6efd;
  box-shadow: 0 0 0 0.2rem rgba(13, 110, 253, 0.25);
}

.btn {
  border-radius: 25px;
  padding: 12px 25px;
  font-weight: 500;
}

.input-group-text {
  background: #f8f9fa;
  border-right: none;
}

.input-group .form-control {
  border-left: none;
}

.input-group .form-control:focus {
  border-left: none;
  box-shadow: none;
}

code {
  font-size: 0.875rem;
  background: #f8f9fa;
  padding: 2px 6px;
  border-radius: 4px;
}
</style>
