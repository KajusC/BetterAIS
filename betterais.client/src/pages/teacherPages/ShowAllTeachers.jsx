import React, { useEffect, useState } from 'react';
import { getAllTeachers } from '../../scripts/teachers';
import { Link } from 'react-router-dom';

const ViewTeachers = () => {
  const [teachers, setTeachers] = useState([]);

  useEffect(() => {
    const fetchTeachers = async () => {
      try {
        const data = await getAllTeachers();  // Fetch teachers from the backend
        setTeachers(data);
      } catch (error) {
        console.error('Error fetching teachers:', error);
        alert('Failed to fetch teachers.');
      }
    };

    fetchTeachers();
  }, []);

  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">View Teachers</h2>
      <table className="table-auto w-full">
        <thead>
          <tr>
            <th className="px-4 py-2">Vidko</th>
            <th className="px-4 py-2">Name</th>
            <th className="px-4 py-2">Actions</th>
          </tr>
        </thead>
        <tbody>
          {teachers.map((teacher) => (
            <tr key={teacher.vidko}>
              <td className="px-4 py-2">{teacher.vidko}</td>
              <td className="px-4 py-2">{teacher.vardas} {teacher.pavarde}</td>
              <td className="px-4 py-2">
                <Link to={`/teacher-profile/${teacher.vidko}`}>
                  <button className="bg-blue-500 text-white px-4 py-2 rounded">View Details</button>
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ViewTeachers;