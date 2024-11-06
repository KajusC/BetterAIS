import React from 'react';
import Timetable from '../../components/Timetable';

const TimetablePage = () => {
  // Placeholder schedule data
  const schedule = [
    {
      time: '08:00 - 09:00',
      monday: 'Math 101',
      tuesday: 'Physics 201',
      wednesday: 'Chemistry 301',
      thursday: 'Biology 101',
      friday: 'History 201',
    },
    {
      time: '09:00 - 10:00',
      monday: 'English 101',
      tuesday: 'Math 101',
      wednesday: 'Physics 201',
      thursday: 'Chemistry 301',
      friday: 'Biology 101',
    },
    // Add more time slots as needed
  ];

  return (
    <div className="p-6">
      <h1 className="text-3xl mb-4 dark:text-white">Timetable</h1>
      <Timetable schedule={schedule} />
    </div>
  );
};

export default TimetablePage;
