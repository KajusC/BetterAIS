import React from 'react';

const Timetable = ({ schedule }) => {
  return (
    <table className="min-w-full dark:bg-gray-800 dark:text-white border transition-colors duration-300">
      <thead>
        <tr>
          <th className="py-2 border">Time</th>
          <th className="py-2 border">Monday</th>
          <th className="py-2 border">Tuesday</th>
          <th className="py-2 border">Wednesday</th>
          <th className="py-2 border">Thursday</th>
          <th className="py-2 border">Friday</th>
        </tr>
      </thead>
      <tbody>
        {schedule.map((slot, index) => (
          <tr key={index}>
            <td className="border px-4 py-2">{slot.time}</td>
            <td className="border px-4 py-2">{slot.monday}</td>
            <td className="border px-4 py-2">{slot.tuesday}</td>
            <td className="border px-4 py-2">{slot.wednesday}</td>
            <td className="border px-4 py-2">{slot.thursday}</td>
            <td className="border px-4 py-2">{slot.friday}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default Timetable;
