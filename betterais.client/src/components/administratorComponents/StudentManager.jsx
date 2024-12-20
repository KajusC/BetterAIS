﻿import React from "react";
import { FiClipboard } from "react-icons/fi";
import { Link } from "react-router-dom";

export default function StudentManager() {
  return (
    <>
      <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
        <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
          <FiClipboard className="inline-block text-gray-500 mr-2" />
          Studentų redagavimas
        </h2>
        <ul className="text-gray-600 dark:text-white">
          <li>
            <Link
              to="/addStudent"
              className="text-green-500 mt-4 inline-block hover:underline "
            >
              Pridėti studentą
            </Link>
          </li>
          <li>
            <Link
              to="/deleteStudent"
              className="text-red-500 mt-4 inline-block hover:underline "
            >
              Ištrinti studentą
            </Link>
          </li>
          <li>
            <Link
              to="/displayStudentData"
              className="text-blue-500 mt-4 inline-block hover:underline "
            >
              Rodyti studentų duomenis
            </Link>
          </li>
        </ul>
      </div>
    </>
  );
}
