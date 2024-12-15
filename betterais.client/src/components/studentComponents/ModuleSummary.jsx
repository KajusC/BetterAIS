import React from 'react';
import { Link } from 'react-router-dom';
import { FiLayers } from 'react-icons/fi';

const ModuleSummary = () => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
        <FiLayers className="inline-block text-gray-500 mr-2" />
        Moduliai
      </h2>
      <p className="text-gray-600 dark:text-white">Iš viso: 5</p>
      <Link to="/modules" className="text-green-500 mt-4 inline-block hover:underline">
        Peržiūrėti modulius
      </Link>
    </div>
  );
};

export default ModuleSummary;
