import React from 'react';

const Lectures = () => {
  // Placeholder data
  const lectures = [
    {
      date: "2024-10-01",
      time: "10:00 - 12:00",
      type: "Mandatory",
      module: "Mathematics 101",
      location: "Room 101",
    },
    {
      date: "2024-10-02",
      time: "14:00 - 16:00",
      type: "Elective",
      module: "Physics 201",
      location: "Room 202",
    },
  ];

  return (
    <div className="p-6 bg-gray-50 min-h-screen">
      <h1 className="text-3xl font-bold mb-4">Lectures</h1>
      <div className="bg-white shadow-md rounded-lg p-6">
        {lectures.map((lecture, index) => (
          <div key={index} className="border-b border-gray-200 py-4">
            <p><strong>Date:</strong> {lecture.date}</p>
            <p><strong>Time:</strong> {lecture.time}</p>
            <p><strong>Type:</strong> {lecture.type}</p>
            <p><strong>Module:</strong> {lecture.module}</p>
            <p><strong>Location:</strong> {lecture.location}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Lectures;
