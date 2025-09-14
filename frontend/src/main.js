import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import App from './App.vue'
import Home from './components/Home.vue'
import About from './components/About.vue'
import Services from './components/Services.vue'
import Doctors from './components/Doctors.vue'
import Contact from './components/Contact.vue'
import Appointment from './components/Appointment.vue'
import DoctorLogin from './components/DoctorLogin.vue'
import DoctorDashboard from './components/DoctorDashboard.vue'
import 'bootstrap/dist/css/bootstrap.min.css'

const routes = [
  { path: '/', component: Home },
  { path: '/hakkimizda', component: About },
  { path: '/hizmetlerimiz', component: Services },
  { path: '/doktorlarimiz', component: Doctors },
  { path: '/iletisim', component: Contact },
  { path: '/randevu-al', component: Appointment },
  { path: '/doktor-giris', component: DoctorLogin },
  { path: '/doktor-panel', component: DoctorDashboard }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

const app = createApp(App)
app.use(router)
app.mount('#app')