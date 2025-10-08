<template>
  <div class="bg-gray-50 flex items-center justify-center min-h-screen p-4">
    <div class="bg-white p-8 rounded-2xl shadow-sm w-full max-w-md border border-gray-100">
      <h2 class="text-center text-lg font-semibold text-gray-900 mb-1">
        Система управления дефектами
      </h2>
      <p class="text-center text-gray-500 mb-6">
        Войдите в свой аккаунт для продолжения работы
      </p>

      <form @submit.prevent="handleLogin" class="space-y-4">
        <div>
          <label for="email" class="block text-sm font-medium text-gray-700 mb-1">Email</label>
          <div class="relative">
            <input 
              type="email" 
              id="email" 
              v-model="email"
              placeholder="manager@company.com"
              class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
              required
            />
          </div>
        </div>

        <div>
          <label for="password" class="block text-sm font-medium text-gray-700 mb-1">Пароль</label>
          <div class="relative">
            <input 
              :type="showPassword ? 'text' : 'password'" 
              id="password" 
              v-model="password"
              placeholder="Введите пароль"
              class="w-full px-3 py-2 border border-gray-300 rounded-lg shadow-sm focus:ring-2 focus:ring-blue-500 focus:outline-none pr-10"
              required
            />
            <button 
              type="button"
              class="absolute inset-y-0 right-0 pr-3 flex items-center"
              @click="togglePasswordVisibility"
            >
              <svg 
                v-if="showPassword" 
                class="h-5 w-5 text-gray-400" 
                fill="none" 
                viewBox="0 0 24 24" 
                stroke="currentColor"
              >
                <path 
                  stroke-linecap="round" 
                  stroke-linejoin="round" 
                  stroke-width="2" 
                  d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.878 9.878L7.757 7.757M9.878 9.878l-2.12 2.12"
                />
              </svg>
              <svg 
                v-else 
                class="h-5 w-5 text-gray-400" 
                fill="none" 
                viewBox="0 0 24 24" 
                stroke="currentColor"
              >
                <path 
                  stroke-linecap="round" 
                  stroke-linejoin="round" 
                  stroke-width="2" 
                  d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
                />
                <path 
                  stroke-linecap="round" 
                  stroke-linejoin="round" 
                  stroke-width="2" 
                  d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
                />
              </svg>
            </button>
          </div>
        </div>

        <button 
          type="submit"
          :disabled="loading"
          class="w-full bg-blue-600 hover:bg-blue-700 text-white font-medium py-2.5 rounded-lg transition disabled:opacity-70 disabled:cursor-not-allowed flex items-center justify-center"
        >
          <svg 
            v-if="loading" 
            class="animate-spin -ml-1 mr-2 h-4 w-4 text-white" 
            xmlns="http://www.w3.org/2000/svg" 
            fill="none" 
            viewBox="0 0 24 24"
          >
            <circle 
              class="opacity-25" 
              cx="12" 
              cy="12" 
              r="10" 
              stroke="currentColor" 
              stroke-width="4"
            ></circle>
            <path 
              class="opacity-75" 
              fill="currentColor" 
              d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
            ></path>
          </svg>
          {{ loading ? 'Вход...' : 'Войти' }}
        </button>
      </form>

      <!-- Сообщение об ошибке -->
      <div 
        v-if="errorMessage" 
        class="mt-4 p-3 bg-red-50 border border-red-200 rounded-lg flex items-start"
      >
        <svg 
          class="h-5 w-5 text-red-400 mt-0.5 mr-2" 
          fill="none" 
          viewBox="0 0 24 24" 
          stroke="currentColor"
        >
          <path 
            stroke-linecap="round" 
            stroke-linejoin="round" 
            stroke-width="2" 
            d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
          />
        </svg>
        <p class="text-red-700 text-sm">{{ errorMessage }}</p>
      </div>

      <div class="text-center mt-4">
        <a href="#" class="text-sm text-blue-600 hover:underline" @click.prevent="handleForgotPassword">
          Забыли пароль?
        </a>
      </div>

      <div class="text-center mt-2 text-sm text-gray-600">
        Нет аккаунта?
        <a href="#" class="text-blue-600 hover:underline" @click.prevent="handleRegister">Зарегистрироваться</a>
      </div>

    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()

// Реактивные данные
const email = ref('')
const password = ref('')
const showPassword = ref(false)
const loading = ref(false)
const errorMessage = ref('')

// Методы
const togglePasswordVisibility = () => {
  showPassword.value = !showPassword.value
}

const validateForm = () => {
  errorMessage.value = ''
  
  if (!email.value || !password.value) {
    errorMessage.value = 'Пожалуйста, заполните все поля'
    return false
  }
  
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  if (!emailRegex.test(email.value)) {
    errorMessage.value = 'Пожалуйста, введите корректный email'
    return false
  }
  
  return true
}

const handleLogin = async () => {
  if (!validateForm()) return
  
  loading.value = true
  
  try {
    // Имитация API запроса
    await new Promise(resolve => setTimeout(resolve, 1500))
    
    if (email.value === 'manager@company.com' && password.value === 'password') {
      console.log('Вход выполнен успешно!')
      // Редирект на dashboard
      router.push('/dashboard')
    } else {
      errorMessage.value = 'Неверный email или пароль. Попробуйте снова.'
    }
  } catch (error) {
    errorMessage.value = 'Произошла ошибка при входе. Пожалуйста, попробуйте позже.'
    console.error('Login error:', error)
  } finally {
    loading.value = false
  }
}

const handleForgotPassword = () => {
  console.log('Запрос на восстановление пароля')
  // router.push('/forgot-password')
}

const handleRegister = () => {
  console.log('Переход к регистрации')
  // router.push('/register')
}
</script>