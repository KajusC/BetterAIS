import React, { useEffect } from "react"
import { deleteStudent as deleteStudentAPI, getAllStudents } from "../../scripts/studentAPI"
import { STUDENT_FINANCING, STUDENT_STATUS } from "../../constants/constants"
import { getKeyByValue } from "../../scripts/getKeyByvalue"

export default function DeleteStudent() {
  const [students, setStudents] = React.useState([])

  useEffect(() => {
    getAllStudents().then((response) => {
      setStudents(response)
    })
  }, [])

  const handleDeleteStudent = (vidko) => {
    if (confirm("Ar tikrai norite ištrinti studentą?")) {
        deleteStudentAPI(vidko).then(() => {
            getAllStudents().then((response) => {
                setStudents(response)
            })
        })
    }
}

  return (
    <div>
      <table className="min-w-full dark:bg-gray-800 dark:text-white border transition-colors duration-300">
        <thead>
          <tr>
            <th className="p-2 border">Vidko</th>
            <th className="p-2 border">Vardas</th>
            <th className="p-2 border">Pavarde</th>
            <th className="p-2 border">el. paštas</th>
            <th className="p-2 border">statusas</th>
            <th className="p-2 border">finansavimo tipas</th>
            <th className="p-2 border">Veiksmai</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student, index) => (
            <tr key={index}>
              <td className="border px-4 py-2">{student.vidko}</td>
              <td className="border px-4 py-2">{student.vardas}</td>
              <td className="border px-4 py-2">{student.pavarde}</td>
              <td className="border px-4 py-2">{student.elPastas}</td>
              <td className="border px-4 py-2">{getKeyByValue(STUDENT_STATUS, student.statusas)}</td>
              <td className="border px-4 py-2">{getKeyByValue(STUDENT_FINANCING, student.finansavimas)}</td>
              <td className="border px-4 py-2">
                <button className="bg-red-500 text-white px-4 py-2 rounded" onClick={() => handleDeleteStudent(student.vidko)}>Trinti</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}