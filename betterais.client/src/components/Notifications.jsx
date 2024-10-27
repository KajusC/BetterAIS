import React from 'react';
import { Link } from 'react-router-dom';
import { FiBell } from 'react-icons/fi';

const Notifications = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
        <FiBell className="inline-block text-red-500 mr-2" />
        Notifications
      </h2>
      <ul className="text-gray-600 dark:text-white">
        <li>System maintenance on Oct 25</li>
        <li>New announcement: Workshop on AI</li>
      </ul>
      <Link to="/notifications" className="text-red-500 mt-4 inline-block hover:underline ">
        View All Notifications
      </Link>
    </div>
  );
};

export default Notifications;
