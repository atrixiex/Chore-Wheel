import { createLazyFileRoute } from '@tanstack/react-router'
import UserProfile from '../UserProfile'

export const Route = createLazyFileRoute('/profile')({
  component: UserProfile,
})
