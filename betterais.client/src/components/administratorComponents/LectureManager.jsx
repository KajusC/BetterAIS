import React from 'react'
import { Link } from 'react-router-dom'
import { FiClipboard } from 'react-icons/fi'

export default function LectureManager() {
    return (
        <>
          <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
              <FiClipboard className="inline-block text-gray-500 mr-2" />
              Paskaitų redagavimas
            </h2>
                <ul className="text-gray-600 dark:text-white">
                    <li>
                        <Link
                            to="/addModule"
                            className="text-purple-500 mt-4 inline-block hover:underline "
                        >
                            Sukurti modulį
                        </Link>
                    </li>
              <li>
                <Link
                  to="/addLecture"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Sukurti paskaitą
                </Link>
              </li>
              <li>
                <Link
                  to="/assignLectureToTimetable"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Pridėti paskaitą į tvarkaraštį
                </Link>
              </li>
              <li>
                <Link
                  to="/editLecture"
                  className="text-yellow-500 mt-4 inline-block hover:underline "
                >
                  Redaguoti paskaitą
                </Link>
              </li>
              <li>
                <Link
                  to="/deleteLecture"
                  className="text-red-500 mt-4 inline-block hover:underline "
                >
                  Ištrinti paskaitą
                </Link>
              </li>
            </ul>
          </div>
        </>
      );
}
