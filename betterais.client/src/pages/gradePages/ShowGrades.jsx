import React, { useState, useEffect } from "react";
import { getAllGrades } from "../../scripts/grades";

export default function RodytiPazymius() {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Gauti pa�ymius, kai komponentas �keltas
        const fetchGrades = async () => {
            try {
                const data = await getAllGrades(); // Gauti pa�ymius i� API
                setGrades(data);
                setLoading(false);
            } catch (error) {
                console.error("Klaida gaunant pa�ymius:", error);
                setLoading(false);
            }
        };

        fetchGrades();
    }, []);

    if (loading) {
        return <div>Kraunama pa�ymiai...</div>;
    }

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Pa�ymiai</h2>
            {grades.length === 0 ? (
                <p>Nerasta pa�ymi�.</p>
            ) : (
                <table className="table-auto w-full border-collapse border border-gray-300">
                    <thead>
                        <tr>
                            <th className="border border-gray-300 px-4 py-2">ID</th>
                            <th className="border border-gray-300 px-4 py-2">�vertinimas</th>
                            <th className="border border-gray-300 px-4 py-2">Data</th>
                            <th className="border border-gray-300 px-4 py-2">Suvestin� ID</th>
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
