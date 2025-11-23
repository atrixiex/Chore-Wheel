import { useEffect, useRef } from "react"
import Button from "./Button"
import { createPortal } from "react-dom"

interface modalProps {
  isOpen: boolean,
  onClose: () => void,
  children: React.ReactNode,
  title?: string
}

export default function Modal({ isOpen, onClose, children, title }: modalProps) {

  const modalRef = useRef<HTMLDivElement>(null)

  if (!isOpen) return null

  return createPortal(
    <div
      className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/50 backdrop-blur-sm"
      onClick={onClose}
    >
      <div
        ref={modalRef}
        className="bg-white rounded-lg shadow-xl max-w-md w-full max-h-[90vh] overflow-y-auto"
        onClick={(e) => e.stopPropagation()}
      >
        {title && (
          <div className="flex items-center justify-between p-4 border-b">
            <h2 className="text-xl font-semibold">{title}</h2>
            <button
              onClick={onClose}
              className="text-gray-500 hover:text-gray-700"
            >
              ✕
            </button>
          </div>
        )}
        <div className="p-4">
          {children}
        </div>
      </div>
    </div>,
    document.body
  )
}
