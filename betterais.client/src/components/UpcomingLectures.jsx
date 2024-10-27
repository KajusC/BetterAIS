import React from 'react';
import { Link } from 'react-router-dom';
import { FiCalendar } from 'react-icons/fi';

const UpcomingLectures = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
        <FiCalendar className="inline-block text-blue-500 mr-2 " />
        Upcoming Lectures
      </h2>
      <ul className="text-gray-600 dark:text-white">
        <li>Mathematics 101 - Room 101 - 10:00 AM</li>
        <li>Physics 201 - Room 202 - 2:00 PM</li>
      </ul>
      <Link to="/lectures" className="text-blue-500 mt-4 inline-block hover:underline">
        View All Lectures
      </Link>
    </div>
  );
};

export default UpcomingLectures;
