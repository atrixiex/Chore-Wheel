import { useState } from 'react'
import { useAuth } from '../auth'
import StyledInput from './StyledInput'

export function LoginForm() {
  const { login } = useAuth()
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState('')
  const [isLoading, setIsLoading] = useState(false)

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setIsLoading(true)
    setError('')

    try {
      await login(username, password)
    } catch (err) {
      setError('Invalid username or password')
    } finally {
      setIsLoading(false)
    }
  }

  return (
    <div className="flex">
      <form
        onSubmit={handleSubmit}
        className="max-w-md w-full space-y-4 p-8 border bg-slate-900 rounded-lg shadow-md text-slate-200"
      >
        <h1 className="text-2xl font-bold text-center text-purple-200">Sign In</h1>

        {error && (
          <div className="bg-red-950 border border-red-400 text-slate-200 px-4 py-3 rounded">
            {error}
          </div>
        )}


        <StyledInput
          id="email"
          label='Username'
          type="text"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />

        <StyledInput
          id="password"
          label='Password'
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required />

        <button
          type="submit"
          disabled={isLoading}
          className="w-full bg-teal-600 text-white py-2 px-4 rounded-md hover:bg-teal-800 disabled:opacity-50 disabled:cursor-not-allowed transition-colors"
        >
          {isLoading ? 'Signing in...' : 'Sign In'}
        </button>
      </form>
    </div>
  )
}