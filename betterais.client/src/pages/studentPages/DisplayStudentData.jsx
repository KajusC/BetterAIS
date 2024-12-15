import React, { useEffect, useState } from "react";
import { getAllStudents } from "../../scripts/studentAPI";
import { STUDENT_FINANCING, STUDENT_STATUS, STUDY_LEVEL } from "../../constants/constants";
import { getKeyByValue } from "../../scripts/getKeyByvalue";
import { getAllPrograms } from "../../scripts/programsAPI";
import { Link } from "react-router-dom";

export default function DisplayStudentData() {
	const [students, setStudents] = useState([]);
  const [programs, setPrograms] = useState([]);
	const [filter, setFilter] = useState("");

	useEffect(
		() => {
			if (!filter) {
				getAllStudents().then((response) => {
					setStudents(response);
				});
			} else {
				getAllStudents(filter).then((response) => {
          console.log(response)
					setStudents(response);
				});
			}
		},
		[filter]
	);

  useEffect(() => {
    getAllPrograms().then((response) => {
      setPrograms(response.map((program) => ({ key: program.programosKodas })));
    });
  }, []);
  

	return (

    <div className="flex flex-col items-center justify-center">
      <h1 className="text-3xl font-bold">Studentų sąrašas</h1>
      <div className="flex items-center justify-center">
        <label className="mr-2">Filtruoti pagal programos kodą:</label>
        <select
          className="p-2 border rounded"
          onChange={(e) => setFilter(e.target.value)}
        >
          <option value="">Visi</option>
          {programs.map((program) => (
            <option key={program.key} value={program.key}>
              {program.key}
            </option>
          ))}
        </select>
      </div>
      <div className="flex items-center justify-center">
        <label className="mr-2">Rasta studentų: {students.length}</label>
      </div>
      <div className="flex items-center justify-center">
        <button
          className="p-2 mt-2 bg-blue-500 text-white rounded"
          onClick={() => setFilter("")
          }
        >
          Išvalyti filtrą
        </button>
      </div>
      <table className="min-w-full dark:bg-gray-800 dark:text-white border transition-colors duration-300">
        <thead>
          <tr>
            <th className="p-2 border">Vidko</th>
            <th className="p-2 border">Vardas</th>
            <th className="p-2 border">Pavarde</th>
            <th className="p-2 border">el. paštas</th>
            <th className="p-2 border">statusas</th>
            <th className="p-2 border">finansavimo tipas</th>
            <th className="p-2 border">Eiti į studento puslapį</th>
            <th className="p-2 border">Redaguoti studentą</th>

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
                <Link to={`/StudentProfile/${student.vidko}`}>
                  <button className="p-2 bg-blue-500 text-white rounded">Eiti į studento puslapį</button>
                </Link>
              </td>
              <td className="border px-4 py-2">
                <Link to={`/EditStudent/${student.vidko}`}>
                  <button className="p-2 bg-yellow-500 text-white rounded">Redaguoti studentą</button>
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}
