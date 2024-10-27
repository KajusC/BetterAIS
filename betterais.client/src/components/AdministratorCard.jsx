import React from 'react';

const AdministratorCard = ({ admin }) => {
  return (
    <div className="dark:bg-gray-800 shadow-md rounded-lg p-4 transition-colors duration-300">
      <h2 className="text-xl font-semibold dark:text-white">{admin.name}</h2>
      <p className="text-gray-600 dark:text-gray-300">Position: {admin.position}</p>
    </div>
  );
};

export default AdministratorCard;
