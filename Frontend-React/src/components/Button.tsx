import type { ComponentProps } from 'react'
import { tv, type VariantProps } from 'tailwind-variants'

export default function Button({ color, size, className, ...props }: ButtonVariants) {
  return (
    <button
      className={buttonStyles({ color, size, className })}
      {...props}
    >
      {props.children}
    </button>
  )
}


const buttonStyles = tv({
  base: 'w-full rounded-md transition-colors text-white',
  variants: {
    color: {
      primary: 'bg-teal-600 hover:bg-teal-800',
      secondary: 'bg-purple-800 hover:bg-purple-950',
      danger: 'bg-red-800 hover:bg-red-950'
    },
    size: {
      sm: 'text-sm py-2 px-4',
      md: 'text-xl py-2 px-4',
      lg: 'px-4 py-3 text-3xl'
    }
  },
  defaultVariants: {
    size: 'md',
    color: 'primary'
  }
})

type ButtonVariants = VariantProps<typeof buttonStyles> & ComponentProps<'button'>