import React from 'react';
import { Link } from 'react-router-dom';
import { FiClipboard } from 'react-icons/fi';

const RecentGrades = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
        <FiClipboard className="inline-block text-purple-500 mr-2" />
        Recent Grades
      </h2>
      <ul className="text-gray-600 dark:text-white">
        <li>Mathematics 101: A</li>
        <li>Physics 201: B+</li>
        <li>History 301: A-</li>
      </ul>
      <Link to="/viewAllGrades" className="text-purple-500 mt-4 inline-block hover:underline">
        View All Grades
      </Link>
    </div>
  );
};

export default RecentGrades;
