import React from "react";
import { FiClipboard } from "react-icons/fi";
import { Link } from "react-router-dom";

export default function GradeManager() {
  return (
    <>
      <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
        <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
          <FiClipboard className="inline-block text-gray-500 mr-2" />
          Grade managing
        </h2>
        <ul className="text-gray-600 dark:text-white">
        <li>
            <Link
              to="/addGrade"
              className="text-green-500 mt-4 inline-block hover:underline "
            >
              Add a grade to student
            </Link>
          </li>
          <li>
            <Link
              to="/calculateWeightedGrade"
              className="text-green-500 mt-4 inline-block hover:underline "
            >
              Calculate weighted grade ????
            </Link>
          </li>
          <li>
            <Link
              to="/deleteGrade"
              className="text-yellow-500 mt-4 inline-block hover:underline "
            >
              Change student grade
            </Link>
          </li>
          <li>
            <Link
              to="/deleteGrade"
              className="text-red-500 mt-4 inline-block hover:underline "
            >
              Delete student grade
            </Link>
          </li>
        </ul>
      </div>
    </>
  );
}
