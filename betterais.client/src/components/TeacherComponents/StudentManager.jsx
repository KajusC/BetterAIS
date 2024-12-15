import React from "react";
import { FiClipboard } from "react-icons/fi";
import { Link } from "react-router-dom";

export default function StudentManager() {
  return (
    <>
      <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
        <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
          <FiClipboard className="inline-block text-gray-500 mr-2" />
          Studento redagavimas
        </h2>
        <ul className="text-gray-600 dark:text-white">
          <li>
            <Link
              to="/printStudentPDF"
              className="text-blue-500 mt-4 inline-block hover:underline "
            >
              Spausdinti studentą PDF
            </Link>
          </li>
          <li>
            <Link
              to="/getStudentData"
              className="text-blue-500 mt-4 inline-block hover:underline "
            >
              Rasti studentą
            </Link>
          </li>
          <li>
            <Link
              to="/getFilteredStudentData"
              className="text-blue-500 mt-4 inline-block hover:underline "
            >
              Rasti visus studentus
            </Link>
          </li>
        </ul>
      </div>
    </>
  );
}
