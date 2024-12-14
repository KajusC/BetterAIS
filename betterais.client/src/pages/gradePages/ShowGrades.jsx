import React, { useState, useEffect } from "react";
import { getAllGrades } from "../../scripts/grades";

export default function ShowGrades() {
  const [grades, setGrades] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Fetch grades when the component mounts
    const fetchGrades = async () => {
      try {
        const data = await getAllGrades(); // Fetch grades from API
        setGrades(data);
        setLoading(false);
      } catch (error) {
        console.error("Error fetching grades:", error);
        setLoading(false);
      }
    };

    fetchGrades();
  }, []);

  if (loading) {
    return <div>Loading grades...</div>;
  }

  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Grades</h2>
      {grades.length === 0 ? (
        <p>No grades found.</p>
      ) : (
        <table className="table-auto w-full border-collapse border border-gray-300">
          <thead>
            <tr>
              <th className="border border-gray-300 px-4 py-2">ID</th>
              <th className="border border-gray-300 px-4 py-2">Grade</th>
              <th className="border border-gray-300 px-4 py-2">Date</th>
              <th className="border border-gray-300 px-4 py-2">Suvestine ID</th>
            </tr>
          </thead>
          <tbody>
            {grades.map((grade) => (
              <tr key={grade.idPazymys}>
                <td className="border border-gray-300 px-4 py-2">{grade.idPazymys}</td>
                <td className="border border-gray-300 px-4 py-2">{grade.ivertinimas}</td>
                <td className="border border-gray-300 px-4 py-2">{grade.data}</td>
                <td className="border border-gray-300 px-4 py-2">{grade.idSuvestine}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
