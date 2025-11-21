

interface StyledInputProps extends React.InputHTMLAttributes<HTMLInputElement> {
  label?: string
  fullWidth?: boolean
}

export default function StyledInput({ label, className = '', ...props }: StyledInputProps) {
  return (
    <div>
      {label && (
        <label className="block text-sm font-medium  mb-1">
          {label}
        </label>
      )}

      <input
        className={`w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-purple-950 ${className}`}
        {...props}
      />


    </div>

  )
}