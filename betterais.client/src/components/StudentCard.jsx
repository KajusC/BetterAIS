import React from 'react';

const StudentCard = ({ student }) => {
  return (
    <div className="dark:bg-gray-800 shadow-md rounded-lg p-4 transition-colors duration-300">
      <h2 className="text-xl font-semibold dark:text-white">{student.name}</h2>
      <p className="text-gray-600 dark:text-gray-300">ID: {student.id}</p>
      <p className="text-gray-600 dark:text-gray-300">Major: {student.major}</p>
    </div>
  );
};

export default StudentCard;
