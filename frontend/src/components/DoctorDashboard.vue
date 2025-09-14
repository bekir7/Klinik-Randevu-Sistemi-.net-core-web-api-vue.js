<template>
  <div>
    <!-- Header -->
    <div class="bg-primary text-white py-4">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-md-6">
            <h2 class="mb-0">
              <i class="fas fa-user-md me-2"></i>Doktor Paneli
            </h2>
            <p class="mb-0">Hoş geldiniz, Dr. {{ doctorName }}</p>
          </div>
          <div class="col-md-6 text-md-end">
            <button class="btn btn-outline-light" @click="logout">
              <i class="fas fa-sign-out-alt me-2"></i>Çıkış Yap
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm">
      <div class="container">
        <div class="navbar-nav">
          <a class="nav-link" :class="{ active: activeTab === 'dashboard' }" @click="activeTab = 'dashboard'">
            <i class="fas fa-tachometer-alt me-1"></i>Dashboard
          </a>
          <a class="nav-link" :class="{ active: activeTab === 'appointments' }" @click="activeTab = 'appointments'">
            <i class="fas fa-calendar-check me-1"></i>Randevular
          </a>
          <a class="nav-link" :class="{ active: activeTab === 'patients' }" @click="activeTab = 'patients'">
            <i class="fas fa-user-injured me-1"></i>Hastalar
          </a>
          <a class="nav-link" :class="{ active: activeTab === 'schedule' }" @click="activeTab = 'schedule'">
            <i class="fas fa-calendar-alt me-1"></i>Program
          </a>
        </div>
      </div>
    </nav>

    <!-- Main Content -->
    <div class="container mt-4">
      <!-- Dashboard Tab -->
      <div v-if="activeTab === 'dashboard'">
        <div class="row mb-4">
          <div class="col-12">
            <h3>Dashboard</h3>
            <p class="text-muted">Bugünkü randevularınız ve istatistikler</p>
          </div>
        </div>

        <!-- Stats Cards -->
        <div class="row g-4 mb-4">
          <div class="col-lg-3 col-md-6">
            <div class="card bg-primary text-white">
              <div class="card-body">
                <div class="d-flex align-items-center">
                  <div class="flex-grow-1">
                    <h6 class="card-title">Bugünkü Randevular</h6>
                    <h3 class="mb-0">{{ todayAppointments }}</h3>
                  </div>
                  <i class="fas fa-calendar-day fa-2x opacity-75"></i>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-md-6">
            <div class="card bg-success text-white">
              <div class="card-body">
                <div class="d-flex align-items-center">
                  <div class="flex-grow-1">
                    <h6 class="card-title">Tamamlanan</h6>
                    <h3 class="mb-0">{{ completedAppointments }}</h3>
                  </div>
                  <i class="fas fa-check-circle fa-2x opacity-75"></i>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-md-6">
            <div class="card bg-warning text-white">
              <div class="card-body">
                <div class="d-flex align-items-center">
                  <div class="flex-grow-1">
                    <h6 class="card-title">Bekleyen</h6>
                    <h3 class="mb-0">{{ pendingAppointments }}</h3>
                  </div>
                  <i class="fas fa-clock fa-2x opacity-75"></i>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-3 col-md-6">
            <div class="card bg-info text-white">
              <div class="card-body">
                <div class="d-flex align-items-center">
                  <div class="flex-grow-1">
                    <h6 class="card-title">Toplam Hasta</h6>
                    <h3 class="mb-0">{{ totalPatients }}</h3>
                  </div>
                  <i class="fas fa-users fa-2x opacity-75"></i>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- Today's Appointments -->
        <div class="row">
          <div class="col-12">
            <div class="card">
              <div class="card-header">
                <h5 class="mb-0">
                  <i class="fas fa-calendar-day me-2"></i>Bugünkü Randevular
                </h5>
              </div>
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table table-hover">
                    <thead>
                      <tr>
                        <th>Saat</th>
                        <th>Hasta</th>
                        <th>Telefon</th>
                        <th>Notlar</th>
                        <th>Durum</th>
                        <th>İşlemler</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr v-for="appointment in todayAppointmentsList" :key="appointment.id">
                        <td>{{ formatTime(appointment.startTime) }}</td>
                        <td>{{ appointment.patientName }}</td>
                        <td>{{ appointment.patientPhone }}</td>
                        <td>{{ appointment.notes || '-' }}</td>
                        <td>
                          <span class="badge" :class="getStatusClass(appointment.status)">
                            {{ getStatusText(appointment.status) }}
                          </span>
                        </td>
                        <td>
                          <button 
                            v-if="appointment.status === 'Scheduled'"
                            class="btn btn-success btn-sm me-1" 
                            @click="completeAppointment(appointment.id)"
                          >
                            <i class="fas fa-check"></i>
                          </button>
                          <button 
                            v-if="appointment.status === 'Scheduled'"
                            class="btn btn-danger btn-sm" 
                            @click="cancelAppointment(appointment.id)"
                          >
                            <i class="fas fa-times"></i>
                          </button>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Appointments Tab -->
      <div v-if="activeTab === 'appointments'">
        <div class="row mb-4">
          <div class="col-12">
            <h3>Randevular</h3>
            <p class="text-muted">Tüm randevularınızı görüntüleyin ve yönetin</p>
          </div>
        </div>

        <!-- Filters -->
        <div class="row mb-4">
          <div class="col-md-3">
            <select class="form-select" v-model="appointmentFilter">
              <option value="">Tüm Durumlar</option>
              <option value="Scheduled">Bekleyen</option>
              <option value="Completed">Tamamlanan</option>
              <option value="Cancelled">İptal Edilen</option>
            </select>
          </div>
          <div class="col-md-3">
            <input type="date" class="form-control" v-model="dateFilter">
          </div>
          <div class="col-md-6">
            <input type="text" class="form-control" v-model="searchFilter" placeholder="Hasta adı ile ara...">
          </div>
        </div>

        <!-- Appointments Table -->
        <div class="card">
          <div class="card-body">
            <div class="table-responsive">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Tarih</th>
                    <th>Saat</th>
                    <th>Hasta</th>
                    <th>Telefon</th>
                    <th>Notlar</th>
                    <th>Durum</th>
                    <th>İşlemler</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="appointment in filteredAppointments" :key="appointment.id">
                    <td>{{ formatDate(appointment.appointmentDate) }}</td>
                    <td>{{ formatTime(appointment.startTime) }}</td>
                    <td>{{ appointment.patientName }}</td>
                    <td>{{ appointment.patientPhone }}</td>
                    <td>{{ appointment.notes || '-' }}</td>
                    <td>
                      <span class="badge" :class="getStatusClass(appointment.status)">
                        {{ getStatusText(appointment.status) }}
                      </span>
                    </td>
                    <td>
                      <button 
                        v-if="appointment.status === 'Scheduled'"
                        class="btn btn-success btn-sm me-1" 
                        @click="completeAppointment(appointment.id)"
                        title="Tamamla"
                      >
                        <i class="fas fa-check"></i>
                      </button>
                      <button 
                        v-if="appointment.status === 'Scheduled'"
                        class="btn btn-danger btn-sm me-1" 
                        @click="cancelAppointment(appointment.id)"
                        title="İptal Et"
                      >
                        <i class="fas fa-times"></i>
                      </button>
                      <button 
                        class="btn btn-info btn-sm" 
                        @click="viewAppointmentDetails(appointment)"
                        title="Detaylar"
                      >
                        <i class="fas fa-eye"></i>
                      </button>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

      <!-- Patients Tab -->
      <div v-if="activeTab === 'patients'">
        <div class="row mb-4">
          <div class="col-12">
            <h3>Hastalar</h3>
            <p class="text-muted">Hastalarınızı görüntüleyin ve yönetin</p>
          </div>
        </div>

        <!-- Patients Table -->
        <div class="card">
          <div class="card-body">
            <div class="table-responsive">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Ad Soyad</th>
                    <th>TC No</th>
                    <th>Telefon</th>
                    <th>E-posta</th>
                    <th>Doğum Tarihi</th>
                    <th>Cinsiyet</th>
                    <th>İşlemler</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="patient in patients" :key="patient.id">
                    <td>{{ patient.firstName }} {{ patient.lastName }}</td>
                    <td>{{ patient.tcNumber }}</td>
                    <td>{{ patient.phoneNumber }}</td>
                    <td>{{ patient.email || '-' }}</td>
                    <td>{{ formatDate(patient.birthDate) }}</td>
                    <td>{{ patient.gender }}</td>
                    <td>
                      <button class="btn btn-primary btn-sm me-1" @click="viewPatientDetails(patient)">
                        <i class="fas fa-eye"></i>
                      </button>
                      <button class="btn btn-success btn-sm" @click="createAppointmentForPatient(patient)">
                        <i class="fas fa-calendar-plus"></i>
                      </button>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>

      <!-- Schedule Tab -->
      <div v-if="activeTab === 'schedule'">
        <div class="row mb-4">
          <div class="col-12">
            <h3>Program</h3>
            <p class="text-muted">Çalışma programınızı yönetin</p>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <h5>Çalışma Saatleri</h5>
            <div class="row">
              <div class="col-md-6">
                <div class="mb-3">
                  <label class="form-label">Başlangıç Saati</label>
                  <input type="time" class="form-control" v-model="schedule.startTime">
                </div>
              </div>
              <div class="col-md-6">
                <div class="mb-3">
                  <label class="form-label">Bitiş Saati</label>
                  <input type="time" class="form-control" v-model="schedule.endTime">
                </div>
              </div>
            </div>
            <div class="mb-3">
              <label class="form-label">Çalışma Günleri</label>
              <div class="row">
                <div class="col-md-2" v-for="day in days" :key="day">
                  <div class="form-check">
                    <input 
                      class="form-check-input" 
                      type="checkbox" 
                      :id="day"
                      :value="day"
                      v-model="schedule.workingDays"
                    >
                    <label class="form-check-label" :for="day">
                      {{ day }}
                    </label>
                  </div>
                </div>
              </div>
            </div>
            <button class="btn btn-primary" @click="saveSchedule">
              <i class="fas fa-save me-2"></i>Programı Kaydet
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { appointmentsApi, patientsApi } from '../services/api'

export default {
  name: 'DoctorDashboard',
  data() {
    return {
      activeTab: 'dashboard',
      doctorName: 'Ahmet Yılmaz',
      todayAppointments: 8,
      completedAppointments: 5,
      pendingAppointments: 3,
      totalPatients: 156,
      appointmentFilter: '',
      dateFilter: '',
      searchFilter: '',
      todayAppointmentsList: [
        {
          id: 1,
          startTime: '09:00',
          patientName: 'Ayşe Demir',
          patientPhone: '0555 123 4567',
          notes: 'Kontrol muayenesi',
          status: 'Scheduled'
        },
        {
          id: 2,
          startTime: '10:00',
          patientName: 'Mehmet Kaya',
          patientPhone: '0555 234 5678',
          notes: '',
          status: 'Scheduled'
        },
        {
          id: 3,
          startTime: '11:00',
          patientName: 'Fatma Özkan',
          patientPhone: '0555 345 6789',
          notes: 'Ağrı şikayeti',
          status: 'Completed'
        }
      ],
      appointments: [],
      patients: [],
      schedule: {
        startTime: '09:00',
        endTime: '17:00',
        workingDays: ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma']
      },
      days: ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi', 'Pazar']
    }
  },
  computed: {
    filteredAppointments() {
      let filtered = this.appointments
      
      if (this.appointmentFilter) {
        filtered = filtered.filter(apt => apt.status === this.appointmentFilter)
      }
      
      if (this.dateFilter) {
        filtered = filtered.filter(apt => apt.appointmentDate === this.dateFilter)
      }
      
      if (this.searchFilter) {
        filtered = filtered.filter(apt => 
          apt.patientName.toLowerCase().includes(this.searchFilter.toLowerCase())
        )
      }
      
      return filtered
    }
  },
  async mounted() {
    // Check if doctor is logged in
    if (!localStorage.getItem('doctorLoggedIn')) {
      this.$router.push('/doktor-giris')
      return
    }
    
    this.doctorName = localStorage.getItem('doctorEmail') || 'Doktor'
    await this.loadData()
  },
  methods: {
    async loadData() {
      try {
        // Load appointments
        const appointmentsResponse = await appointmentsApi.getAll()
        this.appointments = appointmentsResponse.data
        
        // Load patients
        const patientsResponse = await patientsApi.getAll()
        this.patients = patientsResponse.data
      } catch (error) {
        console.error('Veri yüklenirken hata:', error)
      }
    },
    getStatusClass(status) {
      switch (status) {
        case 'Scheduled': return 'bg-warning'
        case 'Completed': return 'bg-success'
        case 'Cancelled': return 'bg-danger'
        default: return 'bg-secondary'
      }
    },
    getStatusText(status) {
      switch (status) {
        case 'Scheduled': return 'Bekleyen'
        case 'Completed': return 'Tamamlanan'
        case 'Cancelled': return 'İptal Edilen'
        default: return status
      }
    },
    formatDate(dateString) {
      return new Date(dateString).toLocaleDateString('tr-TR')
    },
    formatTime(timeString) {
      return timeString.substring(0, 5)
    },
    async completeAppointment(appointmentId) {
      try {
        await appointmentsApi.updateStatus(appointmentId, 'Completed')
        alert('Randevu tamamlandı!')
        await this.loadData()
      } catch (error) {
        alert('Randevu tamamlanırken hata oluştu!')
      }
    },
    async cancelAppointment(appointmentId) {
      if (confirm('Randevuyu iptal etmek istediğinizden emin misiniz?')) {
        try {
          await appointmentsApi.updateStatus(appointmentId, 'Cancelled')
          alert('Randevu iptal edildi!')
          await this.loadData()
        } catch (error) {
          alert('Randevu iptal edilirken hata oluştu!')
        }
      }
    },
    viewAppointmentDetails(appointment) {
      alert(`Randevu Detayları:\nHasta: ${appointment.patientName}\nTarih: ${this.formatDate(appointment.appointmentDate)}\nSaat: ${this.formatTime(appointment.startTime)}\nNotlar: ${appointment.notes || 'Yok'}`)
    },
    viewPatientDetails(patient) {
      alert(`Hasta Detayları:\nAd Soyad: ${patient.firstName} ${patient.lastName}\nTC No: ${patient.tcNumber}\nTelefon: ${patient.phoneNumber}\nE-posta: ${patient.email || 'Yok'}`)
    },
    createAppointmentForPatient(patient) {
      alert(`${patient.firstName} ${patient.lastName} için yeni randevu oluşturma özelliği yakında eklenecek!`)
    },
    saveSchedule() {
      alert('Program başarıyla kaydedildi!')
    },
    logout() {
      localStorage.removeItem('doctorLoggedIn')
      localStorage.removeItem('doctorEmail')
      this.$router.push('/doktor-giris')
    }
  }
}
</script>

<style scoped>
.nav-link {
  cursor: pointer;
  padding: 0.75rem 1rem;
  border-radius: 0.375rem;
  transition: all 0.3s ease;
}

.nav-link:hover {
  background-color: #f8f9fa;
}

.nav-link.active {
  background-color: #0d6efd;
  color: white !important;
}

.card {
  border: none;
  border-radius: 15px;
  box-shadow: 0 5px 15px rgba(0,0,0,0.08);
}

.btn {
  border-radius: 25px;
  padding: 8px 16px;
  font-weight: 500;
}

.table th {
  border-top: none;
  font-weight: 600;
  color: #495057;
}

.badge {
  font-size: 0.75rem;
  padding: 0.5em 0.75em;
}

.opacity-75 {
  opacity: 0.75;
}
</style>
