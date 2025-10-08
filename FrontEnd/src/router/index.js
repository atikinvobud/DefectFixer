import { createRouter, createWebHistory } from 'vue-router'
import LoginPage from '../pages/LoginPage.vue'


const routes = [
  {
    path: '/login',
    name: 'login',
    component: LoginPage,
    meta: { 
      requiresAuth: false,
      preventIfAuthenticated: true // Дополнительный флаг для страницы логина
    }
  },

]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router