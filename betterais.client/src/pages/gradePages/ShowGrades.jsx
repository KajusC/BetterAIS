import React, { useState, useEffect } from "react";
import { getGradesByStudentId } from "../../scripts/grades";

export default function ShowGrades({ studentId }) {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        // Fetch grades for a specific student
        const fetchGrades = async () => {
            try {
                const data = await getGradesByStudentId(studentId); // Fetch grades by studentId
                setGrades(data);
            } catch (error) {
                console.error("Error fetching grades:", error);
                setError("Failed to fetch grades.");
            } finally {
                setLoading(false);
            }
        };

        if (studentId) {
            fetchGrades();
        } else {
            setError("Student ID is required.");
            setLoading(false);
        }
    }, [studentId]);

    if (loading) {
        return <div>Loading grades...</div>;
    }

    if (error) {
        return <div className="text-red-500">{error}</div>;
    }

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Grades for Student {studentId}</h2>
            {grades.length === 0 ? (
                <p>No grades found for this student.</p>
            ) : (
                <table className="table-auto w-full border-collapse border border-gray-300">
                    <thead>
                        <tr>
                            <th className="border border-gray-300 px-4 py-2">ID</th>
                            <th className="border border-gray-300 px-4 py-2">Grade</th>
                            <th className="border border-gray-300 px-4 py-2">Date</th>
                            <th className="border border-gray-300 px-4 py-2">Summary ID</th>
                        </tr>
                    </thead>
                    <tbody>
                        {grades.map((grade) => (
                            <tr key={grade.idPazymys}>
                                <td className="border border-gray-300 px-4 py-2">{grade.idPazymys}</td>
                                <td className="border border-gray-300 px-4 py-2">{grade.ivertinimas}</td>
                                <td className="border border-gray-300 px-4 py-2">{new Date(grade.data).toLocaleDateString()}</td>
                                <td className="border border-gray-300 px-4 py-2">{grade.fkIdSuvestine}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}
