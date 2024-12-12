import React from 'react';
import { Link } from 'react-router-dom';
import { FiEdit3 } from 'react-icons/fi';

const PendingTasks = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
        <FiEdit3 className="inline-block text-orange-500 mr-2 " />
        Užduotys
      </h2>
      <ul className="text-gray-600 dark:text-white">
        <li>Essay on Modern History - Due Oct 20</li>
        <li>Physics Lab Report - Due Oct 22</li>
      </ul>
      <Link to="/tasks" className="text-orange-500 mt-4 inline-block hover:underline">
        Peržiūrėti visas užduotis
      </Link>
    </div>
  );
};

export default PendingTasks;
