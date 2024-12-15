import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { addStudent } from '../../scripts/studentAPI'
import { getAllPrograms } from '../../scripts/programsAPI'
import { STUDENT_FINANCING, STUDENT_STATUS, STUDY_LEVEL } from '../../constants/constants'
import { FiPlus } from 'react-icons/fi'
import 'bootstrap/dist/css/bootstrap.min.css' // Import Bootstrap CSS
import ToastNotification from '../../components/ToastNotification' // Import ToastNotification component

export default function AddStudent() {
  const today = new Date()

  const [formData, setFormData] = useState({
    vardas: "",
    pavarde: "",
    gimimoData: "",
    telefonoNr: "",
    elPastas: "",
    roleId: 3,
    slaptazodis: "",
    vidko: "",
    studijuPradzia: today.toISOString(),
    statusas: 1,
    finansavimas: 1,
    studijos: 1,
    fkProgramosKodas: ""
  })

  const [programCodes, setProgramCodes] = useState([])
  const [showToast, setShowToast] = useState(false)
  const [toastMessage, setToastMessage] = useState('')
  const [toastType, setToastType] = useState('success')

  useEffect(() => {
    getAllPrograms()
      .then((response) => {
        const codes = response.map((program) => program.programosKodas)
        setProgramCodes(codes)
        if (codes.length > 0) {
          setFormData(prev => ({
            ...prev,
            fkProgramosKodas: codes[0]
          }))
        }
      })
      .catch((error) => console.error(error))
  }, [])

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    })
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(formData)
    addStudent(formData)
      .then(() => {
        setToastMessage("Studentas sėkmingai pridėtas!")
        setToastType('success')
        setShowToast(true)
        setFormData({
          vardas: "",
          pavarde: "",
          gimimoData: "",
          telefonoNr: "",
          elPastas: "",
          roleId: 3,
          slaptazodis: "",
          vidko: "",
          studijuPradzia: today.toISOString(),
          statusas: 0,
          finansavimas: 0,
          fkProgramosKodas: ""
        })
      })
      .catch(() => {
        setToastMessage("Klaida! Nepavyko pridėti studento.")
        setToastType('danger')
        setShowToast(true)
      })
  }

  return (
    <div className="max-w-md mx-auto mt-10 p-6 dark:bg-gray-800 rounded-lg shadow-md">
      <ToastNotification 
        show={showToast} 
        message={toastMessage} 
        type={toastType} 
        onClose={() => setShowToast(false)} 
      />
      <h1 className="text-2xl font-bold mb-6 dark:text-white">Pridėti studentą</h1>
      <form onSubmit={handleSubmit}>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">VIDKO</label>
          <input
            type="text"
            name="vidko"
            value={formData.vidko}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Vardas</label>
          <input
            type="text"
            name="vardas"
            value={formData.vardas}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Pavarde</label>
          <input
            type="text"
            name="pavarde"
            value={formData.pavarde}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Gimimo Data</label>
          <input
            type="date"
            name="gimimoData"
            value={formData.gimimoData}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Telefono Nr</label>
          <input
            type="text"
            name="telefonoNr"
            value={formData.telefonoNr}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">El. Paštas</label>
          <input
            type="email"
            name="elPastas"
            value={formData.elPastas}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Slaptažodis</label>
          <input
            type="password"
            name="slaptazodis"
            value={formData.slaptazodis}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Studijų Pradžia</label>
          <input
            type="date"
            name="studijuPradzia"
            value={formData.studijuPradzia}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          />
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Statusas</label>
          <select
            name="statusas"
            value={formData.statusas}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          >
            {Object.entries(STUDENT_STATUS).map(([value, key]) => (
              <option key={key} value={key}>
                {value}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Programos Kodas</label>
          <select
            name="fkProgramosKodas"
            value={formData.fkProgramosKodas}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          >
            {programCodes.map((code) => (
              <option key={code} value={code}>
                {code}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Finansavimas</label>
          <select
            name="finansavimas"
            value={formData.finansavimas}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          >
            {Object.entries(STUDENT_FINANCING).map(([value, key]) => (
              <option key={key} value={key}>
                {value}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 dark:text-white">Studijų Lygis</label>
          <select
            name="studijos"
            value={formData.studijos}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-lg"
          >
            {Object.entries(STUDY_LEVEL).map(([value, key]) => (
              <option key={key} value={key}>
                {value}
              </option>
            ))}
          </select>
        </div>
        <button
          type="submit"
          className="w-full bg-green-500 text-white py-2 px-4 rounded-lg hover:bg-green-600"
        >
          <FiPlus className="inline-block mr-2" />
          Pridėti studentą
        </button>
      </form>
    </div>
  )
}