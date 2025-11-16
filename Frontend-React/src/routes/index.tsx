import { createFileRoute } from '@tanstack/react-router'
import { LoginForm } from '../components/LoginForm'
import Index from '../Index'

export const Route = createFileRoute('/')({
  component: HomeComponent,
})

function HomeComponent() {
  const { auth } = Route.useRouteContext()

  if (!auth.isAuthenticated) return <LoginForm />

  return <Index />

}

