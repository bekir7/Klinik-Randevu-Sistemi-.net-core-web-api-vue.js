<template>
  <div>
    <!-- Page Header -->
    <section class="py-5 bg-primary text-white">
      <div class="container">
        <div class="row">
          <div class="col-12 text-center">
            <h1 class="display-4 fw-bold mb-3">Randevu Al</h1>
            <p class="lead">Kolay ve hızlı randevu alma sistemi</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Appointment Form -->
    <section class="py-5">
      <div class="container">
        <div class="row justify-content-center">
          <div class="col-lg-8">
            <div class="card shadow">
              <div class="card-header bg-primary text-white">
                <h3 class="mb-0">
                  <i class="fas fa-calendar-plus me-2"></i>Randevu Formu
                </h3>
              </div>
              <div class="card-body p-4">
                <!-- Step Indicator -->
                <div class="row mb-4">
                  <div class="col-12">
                    <div class="d-flex justify-content-between">
                      <div class="step" :class="{ active: currentStep >= 1, completed: currentStep > 1 }">
                        <div class="step-number">1</div>
                        <div class="step-label">Hasta Bilgileri</div>
                      </div>
                      <div class="step" :class="{ active: currentStep >= 2, completed: currentStep > 2 }">
                        <div class="step-number">2</div>
                        <div class="step-label">Doktor Seçimi</div>
                      </div>
                      <div class="step" :class="{ active: currentStep >= 3, completed: currentStep > 3 }">
                        <div class="step-number">3</div>
                        <div class="step-label">Tarih & Saat</div>
                      </div>
                      <div class="step" :class="{ active: currentStep >= 4 }">
                        <div class="step-number">4</div>
                        <div class="step-label">Onay</div>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Step 1: Patient Information -->
                <div v-if="currentStep === 1" class="step-content">
                  <h4 class="mb-4">
                    <i class="fas fa-user-injured text-primary me-2"></i>Hasta Bilgileri
                  </h4>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Ad *</label>
                        <input type="text" class="form-control" v-model="patientForm.firstName" required>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Soyad *</label>
                        <input type="text" class="form-control" v-model="patientForm.lastName" required>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">TC Numarası *</label>
                        <input type="text" class="form-control" v-model="patientForm.tcNumber" maxlength="11" required>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Telefon *</label>
                        <input type="tel" class="form-control" v-model="patientForm.phoneNumber" required>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">E-posta</label>
                        <input type="email" class="form-control" v-model="patientForm.email">
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Doğum Tarihi *</label>
                        <input type="date" class="form-control" v-model="patientForm.birthDate" required>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Cinsiyet *</label>
                        <select class="form-select" v-model="patientForm.gender" required>
                          <option value="">Seçiniz</option>
                          <option value="Erkek">Erkek</option>
                          <option value="Kadın">Kadın</option>
                        </select>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Adres</label>
                        <textarea class="form-control" v-model="patientForm.address" rows="2"></textarea>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Step 2: Doctor Selection -->
                <div v-if="currentStep === 2" class="step-content">
                  <h4 class="mb-4">
                    <i class="fas fa-user-md text-primary me-2"></i>Doktor Seçimi
                  </h4>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Uzmanlık Alanı</label>
                        <select class="form-select" v-model="selectedSpecialty" @change="filterDoctors">
                          <option value="">Tüm Uzmanlıklar</option>
                          <option v-for="specialty in specialties" :key="specialty" :value="specialty">
                            {{ specialty }}
                          </option>
                        </select>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Doktor *</label>
                        <select class="form-select" v-model="selectedDoctor" required>
                          <option value="">Doktor Seçiniz</option>
                          <option v-for="doctor in filteredDoctors" :key="doctor.id" :value="doctor.id">
                            {{ doctor.firstName }} {{ doctor.lastName }} - {{ doctor.specialty }}
                          </option>
                        </select>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Step 3: Date & Time -->
                <div v-if="currentStep === 3" class="step-content">
                  <h4 class="mb-4">
                    <i class="fas fa-calendar-alt text-primary me-2"></i>Tarih ve Saat Seçimi
                  </h4>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Tarih *</label>
                        <input 
                          type="date" 
                          class="form-control" 
                          v-model="selectedDate" 
                          :min="minDate"
                          :max="maxDate"
                          @change="loadAvailableSlots"
                          required
                        >
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="mb-3">
                        <label class="form-label">Saat *</label>
                        <select class="form-select" v-model="selectedTime" required>
                          <option value="">Saat Seçiniz</option>
                          <option v-for="slot in availableSlots" :key="slot.startTime" :value="slot.startTime">
                            {{ formatTime(slot.startTime) }}
                          </option>
                        </select>
                      </div>
                    </div>
                  </div>
                  <div class="mb-3">
                    <label class="form-label">Randevu Notları</label>
                    <textarea 
                      class="form-control" 
                      v-model="appointmentNotes" 
                      rows="3"
                      placeholder="Randevu ile ilgili notlarınızı yazabilirsiniz..."
                    ></textarea>
                  </div>
                </div>

                <!-- Step 4: Confirmation -->
                <div v-if="currentStep === 4" class="step-content">
                  <h4 class="mb-4">
                    <i class="fas fa-check-circle text-primary me-2"></i>Randevu Onayı
                  </h4>
                  <div class="card bg-light">
                    <div class="card-body">
                      <h5 class="card-title text-primary">Randevu Özeti</h5>
                      <div class="row">
                        <div class="col-md-6">
                          <h6>Hasta Bilgileri</h6>
                          <p class="mb-1"><strong>Ad Soyad:</strong> {{ patientForm.firstName }} {{ patientForm.lastName }}</p>
                          <p class="mb-1"><strong>TC No:</strong> {{ patientForm.tcNumber }}</p>
                          <p class="mb-1"><strong>Telefon:</strong> {{ patientForm.phoneNumber }}</p>
                          <p class="mb-1"><strong>E-posta:</strong> {{ patientForm.email || 'Belirtilmemiş' }}</p>
                        </div>
                        <div class="col-md-6">
                          <h6>Randevu Bilgileri</h6>
                          <p class="mb-1"><strong>Doktor:</strong> {{ getSelectedDoctorName() }}</p>
                          <p class="mb-1"><strong>Tarih:</strong> {{ formatDate(selectedDate) }}</p>
                          <p class="mb-1"><strong>Saat:</strong> {{ formatTime(selectedTime) }}</p>
                          <p class="mb-1"><strong>Notlar:</strong> {{ appointmentNotes || 'Yok' }}</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- Navigation Buttons -->
                <div class="d-flex justify-content-between mt-4">
                  <button 
                    v-if="currentStep > 1" 
                    class="btn btn-outline-secondary" 
                    @click="previousStep"
                  >
                    <i class="fas fa-arrow-left me-2"></i>Geri
                  </button>
                  <div v-else></div>
                  
                  <button 
                    v-if="currentStep < 4" 
                    class="btn btn-primary" 
                    @click="nextStep"
                    :disabled="!canProceed"
                  >
                    İleri<i class="fas fa-arrow-right ms-2"></i>
                  </button>
                  
                  <button 
                    v-if="currentStep === 4" 
                    class="btn btn-success btn-lg" 
                    @click="createAppointment"
                    :disabled="loading"
                  >
                    <i class="fas fa-calendar-check me-2"></i>
                    {{ loading ? 'Randevu Oluşturuluyor...' : 'Randevu Oluştur' }}
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Success Modal -->
    <div class="modal fade" :class="{ show: showSuccessModal }" :style="{ display: showSuccessModal ? 'block' : 'none' }" tabindex="-1">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header bg-success text-white">
            <h5 class="modal-title">
              <i class="fas fa-check-circle me-2"></i>Randevu Başarıyla Oluşturuldu!
            </h5>
          </div>
          <div class="modal-body text-center">
            <i class="fas fa-calendar-check fa-4x text-success mb-3"></i>
            <h4>Randevunuz Onaylandı</h4>
            <p class="text-muted">
              <strong>{{ patientForm.firstName }} {{ patientForm.lastName }}</strong> için<br>
              <strong>{{ getSelectedDoctorName() }}</strong> ile<br>
              <strong>{{ formatDate(selectedDate) }}</strong> tarihinde<br>
              <strong>{{ formatTime(selectedTime) }}</strong> saatinde randevunuz oluşturulmuştur.
            </p>
            <p class="text-muted">
              Randevu günü gelmeden önce size telefon ile hatırlatma yapılacaktır.
            </p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-success" @click="resetFormAndClose">
              Yeni Randevu Oluştur
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="showSuccessModal" class="modal-backdrop fade show"></div>
  </div>
</template>

<script>
import { patientsApi, doctorsApi, appointmentsApi } from '../services/api'

export default {
  name: 'Appointment',
  data() {
    return {
      currentStep: 1,
      loading: false,
      showSuccessModal: false,
      doctors: [],
      filteredDoctors: [],
      specialties: [],
      selectedSpecialty: '',
      selectedDoctor: '',
      selectedDate: '',
      selectedTime: '',
      availableSlots: [],
      appointmentNotes: '',
      patientForm: {
        firstName: '',
        lastName: '',
        tcNumber: '',
        phoneNumber: '',
        email: '',
        birthDate: '',
        gender: '',
        address: ''
      }
    }
  },
  computed: {
    minDate() {
      const tomorrow = new Date()
      tomorrow.setDate(tomorrow.getDate() + 1)
      return tomorrow.toISOString().split('T')[0]
    },
    maxDate() {
      const maxDate = new Date()
      maxDate.setDate(maxDate.getDate() + 30)
      return maxDate.toISOString().split('T')[0]
    },
    canProceed() {
      switch (this.currentStep) {
        case 1:
          return this.patientForm.firstName && 
                 this.patientForm.lastName && 
                 this.patientForm.tcNumber && 
                 this.patientForm.phoneNumber && 
                 this.patientForm.birthDate && 
                 this.patientForm.gender
        case 2:
          return this.selectedDoctor
        case 3:
          return this.selectedDate && this.selectedTime
        default:
          return false
      }
    }
  },
  async mounted() {
    await this.loadDoctors()
  },
  methods: {
    async loadDoctors() {
      try {
        const response = await doctorsApi.getActive()
        this.doctors = response.data
        this.filteredDoctors = response.data
        this.specialties = [...new Set(this.doctors.map(doctor => doctor.specialty))]
      } catch (error) {
        console.error('Doktorlar yüklenirken hata:', error)
        alert('Doktorlar yüklenirken hata oluştu!')
      }
    },
    filterDoctors() {
      if (!this.selectedSpecialty) {
        this.filteredDoctors = this.doctors
      } else {
        this.filteredDoctors = this.doctors.filter(doctor => 
          doctor.specialty === this.selectedSpecialty
        )
      }
      this.selectedDoctor = ''
    },
    async loadAvailableSlots() {
      if (this.selectedDoctor && this.selectedDate) {
        try {
          const response = await appointmentsApi.getAvailableSlots(
            this.selectedDoctor, 
            this.selectedDate
          )
          this.availableSlots = response.data.filter(slot => slot.isAvailable)
          this.selectedTime = ''
        } catch (error) {
          console.error('Müsait saatler yüklenirken hata:', error)
          alert('Müsait saatler yüklenirken hata oluştu!')
        }
      }
    },
    getSelectedDoctorName() {
      const doctor = this.doctors.find(d => d.id == this.selectedDoctor)
      return doctor ? `${doctor.firstName} ${doctor.lastName}` : ''
    },
    nextStep() {
      if (this.canProceed) {
        this.currentStep++
      }
    },
    previousStep() {
      this.currentStep--
    },
    async createAppointment() {
      this.loading = true
      try {
        // Check if patient exists
        let patientId
        try {
          const existingPatient = await patientsApi.getByTcNumber(this.patientForm.tcNumber)
          patientId = existingPatient.data.id
        } catch (error) {
          console.log('Hasta bulunamadı, yeni hasta oluşturuluyor:', error.response?.data)
          // Create new patient
          try {
            // Boş alanları null gönder
            const patientData = {
              ...this.patientForm,
              email: this.patientForm.email || null,
              address: this.patientForm.address || null
            }
            console.log('Gönderilen hasta verisi:', patientData)
            const newPatient = await patientsApi.create(patientData)
            patientId = newPatient.data.id
            console.log('Yeni hasta oluşturuldu:', newPatient.data)
          } catch (createError) {
            console.error('Hasta oluşturulurken hata:', createError.response?.data)
            console.error('Validation errors:', createError.response?.data?.errors)
            throw createError
          }
        }

        // Create appointment
        const appointmentData = {
          patientId: patientId,
          doctorId: parseInt(this.selectedDoctor),
          appointmentDate: this.selectedDate,
          startTime: this.selectedTime, // HH:mm formatında
          notes: this.appointmentNotes
        }

        await appointmentsApi.create(appointmentData)
        this.showSuccessModal = true

      } catch (error) {
        console.error('Randevu oluşturulurken hata:', error)
        console.error('Error response:', error.response?.data)
        console.error('Error status:', error.response?.status)
        alert(`Randevu oluşturulurken hata oluştu: ${error.response?.data?.message || error.message}`)
      } finally {
        this.loading = false
      }
    },
    resetFormAndClose() {
      this.showSuccessModal = false
      this.currentStep = 1
      this.patientForm = {
        firstName: '',
        lastName: '',
        tcNumber: '',
        phoneNumber: '',
        email: '',
        birthDate: '',
        gender: '',
        address: ''
      }
      this.selectedSpecialty = ''
      this.selectedDoctor = ''
      this.selectedDate = ''
      this.selectedTime = ''
      this.availableSlots = []
      this.appointmentNotes = ''
      this.filteredDoctors = this.doctors
    },
    formatDate(dateString) {
      return new Date(dateString).toLocaleDateString('tr-TR')
    },
    formatTime(timeString) {
      return timeString.substring(0, 5)
    }
  }
}
</script>

<style scoped>
.step {
  text-align: center;
  flex: 1;
  position: relative;
}

.step:not(:last-child)::after {
  content: '';
  position: absolute;
  top: 20px;
  left: 50%;
  width: 100%;
  height: 2px;
  background: #dee2e6;
  z-index: 1;
}

.step.completed:not(:last-child)::after {
  background: #0d6efd;
}

.step-number {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  background: #dee2e6;
  color: #6c757d;
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 0 auto 8px;
  font-weight: bold;
  position: relative;
  z-index: 2;
}

.step.active .step-number {
  background: #0d6efd;
  color: white;
}

.step.completed .step-number {
  background: #198754;
  color: white;
}

.step-label {
  font-size: 0.875rem;
  color: #6c757d;
}

.step.active .step-label {
  color: #0d6efd;
  font-weight: 600;
}

.step.completed .step-label {
  color: #198754;
  font-weight: 600;
}

.step-content {
  min-height: 400px;
}

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
</style>
