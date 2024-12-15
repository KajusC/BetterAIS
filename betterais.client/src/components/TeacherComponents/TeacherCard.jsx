import React from 'react';
import { FiUser } from 'react-icons/fi';
import { Link } from 'react-router-dom';

export default function TeacherCard({ teacher }) {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 dark:text-gray-300 mb-4 ">
        <FiUser className="inline-block text-indigo-500 dark:text-indigo-400 mr-2" />
        Profilis
      </h2>
      <h2 className="text-xl font-semibold dark:text-white">{teacher.name}</h2>
      <p className="text-gray-600 dark:text-gray-300">Fakultetas: {teacher.department}</p>
      <Link to="/TeacherProfile" className="text-indigo-500 dark:text-indigo-400 mt-4 inline-block hover:underline">
        Peržiūrėti profilį detaliau
      </Link>
    </div>
    
  );
};
