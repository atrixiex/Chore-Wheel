import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { RouterProvider, createRouter } from '@tanstack/react-router'
import { routeTree } from './routeTree.gen'
import { AuthProvider, useAuth } from './auth'

export const router = createRouter({
  routeTree,
  context: {
    auth: undefined!,
  },
})

declare module '@tanstack/react-router' {
  interface Register {
    router: typeof router
  }
}

function InnerApp() {
  // const auth = useAuth()
  return <RouterProvider router={router} />
}

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    {/* <AuthProvider> */}
    <InnerApp />
    {/* </AuthProvider> */}
  </StrictMode >
)