import React, { createContext, useContext } from 'react'
import { useMutation, useQueryClient } from '@tanstack/react-query'

interface User {
  id: string
  email: string
}

export interface AuthState {
  isAuthenticated: boolean
  user: User | null
  login: (email: string, password: string) => Promise<void>
  logout: () => void
}

const AuthContext = createContext<AuthState | undefined>(undefined)

// API functions
async function loginUser(email: string, password: string): Promise<{
  user: User
  token: string
  refreshToken: string
}> {
  const response = await fetch('http://localhost:5082/login', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ email, password }),
  })

  if (!response.ok) {
    throw new Error('Authentication failed')
  }

  return response.json()
}

async function refreshAccessToken(): Promise<boolean> {
  const refreshToken = localStorage.getItem('refresh-token')
  if (!refreshToken) return false

  try {
    const response = await fetch('/api/refresh', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ refreshToken }),
    })

    if (!response.ok) {
      localStorage.removeItem('auth-token')
      localStorage.removeItem('refresh-token')
      return false
    }

    const data = await response.json()
    localStorage.setItem('auth-token', data.token)

    if (data.refreshToken) {
      localStorage.setItem('refresh-token', data.refreshToken)
    }

    return true
  } catch (error) {
    console.error('Token refresh failed:', error)
    return false
  }
}

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const queryClient = useQueryClient()

  const loginMutation = useMutation({
    mutationFn: ({ email, password }: { email: string; password: string }) =>
      loginUser(email, password),
    onSuccess: (data) => {
      localStorage.setItem('auth-token', data.token)
      localStorage.setItem('refresh-token', data.refreshToken)
      queryClient.setQueryData(['currentUser'], data.user)
    },
  })

  const login = async (email: string, password: string) => {
    await loginMutation.mutateAsync({ email, password })
  }

  const logout = () => {
    localStorage.removeItem('auth-token')
    localStorage.removeItem('refresh-token')
    queryClient.setQueryData(['currentUser'], null)
    queryClient.clear()
  }

  const token = localStorage.getItem('auth-token')
  const user = queryClient.getQueryData<User>(['currentUser'])

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated: !!token && !!user,
        user: user ?? null,
        login,
        logout
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}

export function useAuth() {
  const context = useContext(AuthContext)
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider')
  }
  return context
}

export { refreshAccessToken }