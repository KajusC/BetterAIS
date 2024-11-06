import React from 'react'
import { Link } from 'react-router-dom'
import { FiClipboard } from 'react-icons/fi'

export default function TeacherManager() {
    return (
        <>
          <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
              <FiClipboard className="inline-block text-gray-500 mr-2" />
              Teacher managing
            </h2>
            <ul className="text-gray-600 dark:text-white">
              <li>
                <Link
                  to="/addTeacher"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Add teacher
                </Link>
              </li>
              <li>
                <Link
                  to="/editTeacher"
                  className="text-yellow-500 mt-4 inline-block hover:underline "
                >
                  edit teacher info
                </Link>
              </li>
              <li>
                <Link
                  to="/deleteTeacher"
                  className="text-red-500 mt-4 inline-block hover:underline "
                >
                  Delete teacher
                </Link>
              </li>
              <li>
                <Link
                  to="/displayTeacher"
                  className="text-blue-500 mt-4 inline-block hover:underline "
                >
                  display teacher data
                </Link>
              </li>
              <li>
                <Link
                  to="/displayTeacherFilter"
                  className="text-blue-500 mt-4 inline-block hover:underline "
                >
                  display teachers by filter
                </Link>
              </li>
            </ul>
          </div>
        </>
      );
}
