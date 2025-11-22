import { createRootRouteWithContext, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/router-devtools'
import Header from '../components/Header'

interface AuthState {
  // isAuthenticated: boolean
  user: { id: string; username: string; email: string } | null
  login: (username: string, password: string) => Promise<void>
  logout: () => void
}

interface MyRouterContext {
  auth: AuthState
}

export const Route = createRootRouteWithContext<MyRouterContext>()({
  component: RootComponent,
})

function RootComponent() {
  return (
    <>
      <Header />
      <Outlet />
      <TanStackRouterDevtools />
    </>
  )
}