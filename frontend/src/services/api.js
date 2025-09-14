import axios from 'axios'

const API_BASE_URL = 'http://localhost:5208/api'

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json'
  }
})

// Patients API
export const patientsApi = {
  getAll: () => api.get('/patients'),
  getById: (id) => api.get(`/patients/${id}`),
  create: (data) => api.post('/patients', data),
  update: (id, data) => api.put(`/patients/${id}`, data),
  delete: (id) => api.delete(`/patients/${id}`),
  getByTcNumber: (tcNumber) => api.get(`/patients/tc/${tcNumber}`)
}

// Doctors API
export const doctorsApi = {
  getAll: () => api.get('/doctors'),
  getById: (id) => api.get(`/doctors/${id}`),
  create: (data) => api.post('/doctors', data),
  update: (id, data) => api.put(`/doctors/${id}`, data),
  delete: (id) => api.delete(`/doctors/${id}`),
  getActive: () => api.get('/doctors/active')
}

// Appointments API
export const appointmentsApi = {
  getAll: () => api.get('/appointments'),
  getById: (id) => api.get(`/appointments/${id}`),
  create: (data) => api.post('/appointments', data),
  update: (id, data) => api.put(`/appointments/${id}`, data),
  delete: (id) => api.delete(`/appointments/${id}`),
  getByDoctor: (doctorId) => api.get(`/appointments/doctor/${doctorId}`),
  getByPatient: (patientId) => api.get(`/appointments/patient/${patientId}`),
  getAvailableSlots: (doctorId, date) => api.get(`/appointments/available/${doctorId}?date=${date}`),
  updateStatus: (id, status) => api.patch(`/appointments/${id}/status`, { status })
}

export default api