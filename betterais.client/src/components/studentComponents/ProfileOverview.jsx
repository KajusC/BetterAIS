import React from 'react';
import { Link } from 'react-router-dom';
import { FiUser } from 'react-icons/fi';

const ProfileOverview = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 dark:text-gray-300 mb-4 ">
        <FiUser className="inline-block text-indigo-500 dark:text-indigo-400 mr-2" />
        Profilis
      </h2>
      <p className="text-gray-600 dark:text-gray-100 mb-2"><strong>Name:</strong> John Doe</p>
      <p className="text-gray-600 dark:text-gray-100 mb-2"><strong>Status:</strong> Active</p>
      <p className="text-gray-600 dark:text-gray-100"><strong>Program:</strong> Computer Science</p>
      <Link to="/StudentProfile" className="text-indigo-500 dark:text-indigo-400 mt-4 inline-block hover:underline">
        Peržiūrėti profiį detaliau
      </Link>
    </div>
  );
};

export default ProfileOverview;
