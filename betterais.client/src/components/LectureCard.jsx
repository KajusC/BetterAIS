import React from 'react';

const LectureCard = ({ lecture }) => {
  return (
    <div className="bg-white shadow-md rounded-lg p-4 transition-colors duration-300">
      <h2 className="text-xl font-semibold">{lecture.title}</h2>
      <p className="text-gray-600">Dėstytojas: {lecture.teacher}</p>
      <p className="text-gray-600">Laikas: {lecture.time}</p>
    </div>
  );
};

export default LectureCard;
