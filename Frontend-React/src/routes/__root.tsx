import { createRootRouteWithContext, Outlet } from '@tanstack/react-router'
import { TanStackRouterDevtools } from '@tanstack/router-devtools'
import Header from '../components/Header'
import type { QueryClient } from '@tanstack/react-query';
import type { AuthState } from '../auth';



interface MyRouterContext {
  queryClient: QueryClient,
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