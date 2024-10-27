import React from 'react';

const TeacherCard = ({ teacher }) => {
  return (
    <div className="dark:bg-gray-800 shadow-md rounded-lg p-4 transition-colors duration-300">
      <h2 className="text-xl font-semibold dark:text-white">{teacher.name}</h2>
      <p className="text-gray-600 dark:text-gray-300">Department: {teacher.department}</p>
    </div>
  );
};

export default TeacherCard;
