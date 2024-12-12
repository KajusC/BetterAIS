import React from 'react';
import { FiUser } from 'react-icons/fi';

const AdministratorCard = ({ admin }) => {
  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
    <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
      <FiUser className="inline-block text-gray-500 mr-2" />
      Administratoriaus informacija
    </h2>
      <h2 className="text-xl font-semibold dark:text-white">{admin.name}</h2>
      <p className="text-gray-600 dark:text-gray-300">Pozicija: {admin.position}</p>
    </div>
  );
};

export default AdministratorCard;
