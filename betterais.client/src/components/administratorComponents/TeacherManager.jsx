import React from 'react'
import { Link } from 'react-router-dom'
import { FiClipboard } from 'react-icons/fi'

export default function TeacherManager() {
    return (
        <>
          <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
              <FiClipboard className="inline-block text-gray-500 mr-2" />
              Dėstytojų redagavimas
            </h2>
                <ul className="text-gray-600 dark:text-white">
                    <li>
                        <Link
                            to="/assignTeacher"
                            className="text-purple-500 mt-4 inline-block hover:underline "
                        >
                            Priskirti dėstytoją prie modulio
                        </Link>
                    </li>
              <li>
                <Link
                  to="/add-teacher"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Pridėti dėstytoją
                </Link>
              </li>
              {/* <li>
                <Link
                  to="/edit-teacher"
                  className="text-yellow-500 mt-4 inline-block hover:underline "
                >
                  edit teacher info
                </Link>
              </li> */}
              <li>
                <Link
                  to="/delete-teacher"
                  className="text-red-500 mt-4 inline-block hover:underline "
                >
                  Ištrinti dėstytoją
                </Link>
              </li>
              {/* <li>
                <Link
                  to="/teacher-profile"
                  className="text-blue-500 mt-4 inline-block hover:underline "
                >
                  display teacher data
                </Link>
              </li> */}
                    
              <li>
                <Link
                  to="/showAllTeachers"
                  className="text-blue-500 mt-4 inline-block hover:underline "
                >
                  Rodyti visus dėstytojus
                </Link>
              </li>
            </ul>
          </div>
        </>
      );
}
