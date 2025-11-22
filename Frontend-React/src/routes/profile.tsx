import { redirect, createFileRoute } from '@tanstack/react-router'
import UserProfile from '../components/UserProfile'


export const Route = createFileRoute('/profile')({
  beforeLoad: ({ context }) => {
    if (!context.auth.isAuthenticated) {
      throw redirect({ to: '/' })
    }
  },
  component: UserProfile,
})