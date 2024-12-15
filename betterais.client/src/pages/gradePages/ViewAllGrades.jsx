import React, { useState, useEffect } from "react";
import { getAllGrades } from "../../scripts/grades";

export default function ViewAllGrades() {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Fetch all grades
        const fetchGrades = async () => {
            try {
                const data = await getAllGrades(); // Get all grades from API
                setGrades(data);
                setLoading(false);
            } catch (error) {
                console.error("Nepavyko gauti paþymiø:", error);
                setLoading(false);
            }
        };

        fetchGrades();
    }, []);

    if (loading) {
        return <div>Kraunami paþymiai...</div>;
    }

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">All Grades</h2>
            {grades.length === 0 ? (
                <p>No grades found.</p>
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
