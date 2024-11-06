import React from 'react'
import { Link } from 'react-router-dom'
import { FiClipboard } from 'react-icons/fi'

export default function LectureManager() {
    return (
        <>
          <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
              <FiClipboard className="inline-block text-gray-500 mr-2" />
              Lecture managing
            </h2>
            <ul className="text-gray-600 dark:text-white">
              <li>
                <Link
                  to="/addLecture"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Add lecture
                </Link>
              </li>
              <li>
                <Link
                  to="/addLectureTimetable"
                  className="text-green-500 mt-4 inline-block hover:underline "
                >
                  Add lecture to timetable
                </Link>
              </li>
              <li>
                <Link
                  to="/editLecture"
                  className="text-yellow-500 mt-4 inline-block hover:underline "
                >
                  Edit lectures
                </Link>
              </li>
              <li>
                <Link
                  to="/deleteLecture"
                  className="text-red-500 mt-4 inline-block hover:underline "
                >
                  Delete lecture
                </Link>
              </li>
            </ul>
          </div>
        </>
      );
}
