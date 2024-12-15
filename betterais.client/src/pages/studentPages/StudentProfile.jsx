import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { getKeyByValue } from '../../scripts/getKeyByvalue'
import { STUDENT_STATUS, STUDENT_FINANCING } from '../../constants/constants'
import { getStudentByVidko, downloadPDF } from '../../scripts/studentAPI'
import ToastNotification from '../../components/ToastNotification'

const StudentProfile = () => {
  const { vidko } = useParams()

  const [studentInfo, setStudentInfo] = useState({})
  const [folder, setFolder] = useState("C:/Users/user/")
  const [showToast, setShowToast] = useState(false)
  const [toastMessage, setToastMessage] = useState('')
  const [toastType, setToastType] = useState('success')

  useEffect(() => {
    getStudentByVidko(vidko)
      .then((data) => {
        setStudentInfo(data)
      })
      .catch((error) => {
        console.error('Error:', error)
      })
  }, [vidko])

  const downloadPdf = async () => {
    try {
      const  status = await downloadPDF(folder, vidko)

      if (status === 200) {
        setToastMessage('Ataskaita atsisiųsta sėkmingai')
        setToastType('success')
        setShowToast(true)
      } else {
        setToastMessage('Klaida atsisiunčiant ataskaitą')
        setToastType('danger')
        setShowToast(true)
      }
    } catch (error) {
      console.error('Error downloading pdf:', error)
      setToastMessage('Klaida atsisiunčiant ataskaitą')
      setToastType('danger')
      setShowToast(true)
    }
  }

  const statusas = getKeyByValue(STUDENT_STATUS, studentInfo.statusas)
  const finansavimas = getKeyByValue(STUDENT_FINANCING, studentInfo.finansavimas)
  const gimimoData = studentInfo.gimimoData ? studentInfo.gimimoData.split('T')[0] : ''

  return (
    <div className="p-6 bg-gray-50 min-h-screen dark:bg-gray-900 dark:text-white">
      <ToastNotification show={showToast} message={toastMessage} type={toastType} onClose={() => setShowToast(false)} />
      <h1 className="text-3xl font-bold mb-4">Studento Profilis (Vidko: {studentInfo.vidko})</h1>
      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-2xl font-semibold mb-2">Asmeninė informacija</h2>
        <p>
          <strong>Vardas Pavardė:</strong> {studentInfo.vardas} {studentInfo.pavarde}
        </p>
        <p>
          <strong>Gimimo Data:</strong> {gimimoData}
        </p>
        <p>
          <strong>Telefono Nr:</strong> {studentInfo.telefonoNr}
        </p>
        <p>
          <strong>El. paštas:</strong> {studentInfo.elPastas}
        </p>
        <p>
          <strong>Studijų statusas:</strong> {statusas}
        </p>
        <p>
          <strong>Finansavimas:</strong> {finansavimas}
        </p>
      </div>

      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-2xl font-semibold mb-2">Academinė Informacija</h2>
        <p>
          <strong>Studijų programa:</strong> {studentInfo.fkProgramosKodas}
        </p>
        <h3 className="text-xl font-semibold mt-4">Pažymiai</h3>
        <ul>
          {/* pažymiai */}
        </ul>
      </div>

      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2>Ataskaitos atsisiuntimo mygtukas</h2>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Ataskaitos įkėlimo vieta</label>
          <input
            type="text"
            className="w-full px-3 py-2 border rounded-lg"
            onChange={(e) => setFolder(e.target.value)}
            value={folder}
          />
        </div>

        <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={downloadPdf}>
          Atsisiųsti ataskaitą
        </button>
      </div>
    </div>
  )
}

export default StudentProfile