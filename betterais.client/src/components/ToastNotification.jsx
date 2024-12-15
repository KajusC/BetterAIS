import React, { useEffect } from 'react'

const ToastNotification = ({ show, message, type, onClose }) => {
  useEffect(() => {
    if (show) {
      const timer = setTimeout(() => {
        onClose()
      }, 3000)
      return () => clearTimeout(timer)
    }
  }, [show, onClose])

  return (
    <div className={`toast-container position-fixed top-0 end-0 p-3 ${show ? 'show' : ''}`} style={{ zIndex: 1050 }}>
      <div className={`toast ${show ? 'show' : ''} ${type === 'success' ? 'bg-success' : 'bg-danger'} text-white`} role="alert">
        <div className="toast-header">
          <strong className="me-auto">{type === 'success' ? 'Sėkmė!' : 'Klaida!'}</strong>
          <button type="button" className="btn-close" aria-label="Close" onClick={onClose}></button>
        </div>
        <div className="toast-body">
          {message}
        </div>
      </div>
    </div>
  )
}

export default ToastNotification