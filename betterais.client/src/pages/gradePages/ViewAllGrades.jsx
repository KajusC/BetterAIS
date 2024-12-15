import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { getAllGrades } from "../../scripts/grades";

export default function ViewAllGrades() {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Fetch all grades
        const fetchGrades = async () => {
            try {
                const data = await getAllGrades(); // Fetch grades from API
                setGrades(data);
            } catch (error) {
                console.error("Nepavyko gauti paþymiø:", error);
            } finally {
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
            <h2 className="text-2xl font-bold mb-4">Visi paþymiai</h2>
            {grades.length === 0 ? (
                <p>Paþymiø nerasta.</p>
            ) : (
                <table className="table-auto w-full border-collapse border border-gray-300">
                    <thead>
                        <tr>
                            <th className="border border-gray-300 px-4 py-2">ID</th>
                            <th className="border border-gray-300 px-4 py-2">Paþymys</th>
                            <th className="border border-gray-300 px-4 py-2">Data</th>
                            <th className="border border-gray-300 px-4 py-2">Suvestinës ID</th>
                            <th className="border border-gray-300 px-4 py-2">Veiksmai</th>
                        </tr>
                    </thead>
                    <tbody>
                        {grades.map((grade) => (
                            <tr key={grade.idPazymys}>
                                <td className="border border-gray-300 px-4 py-2">{grade.idPazymys}</td>
                                <td className="border border-gray-300 px-4 py-2">{grade.ivertinimas}</td>
                                <td className="border border-gray-300 px-4 py-2">
                                    {new Date(grade.data).toLocaleDateString("lt-LT")}
                                </td>
                                <td className="border border-gray-300 px-4 py-2">{grade.fkIdSuvestine}</td>
                                <td className="border border-gray-300 px-4 py-2">
                                    <Link
                                        to={`/ChangeGrade/${grade.idPazymys}`}
                                        className="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                                    >
                                        Redaguoti
                                    </Link>

                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}
