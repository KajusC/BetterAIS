import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FiClipboard } from "react-icons/fi";
import { getAllGrades } from "../../scripts/grades";

const RecentGrades = () => {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [noRecentGrades, setNoRecentGrades] = useState(false);

    useEffect(() => {
        const fetchGrades = async () => {
            try {
                const data = await getAllGrades();
                if (data.length === 0) {
                    setNoRecentGrades(true);
                } else {
                    setGrades(data.slice(0, 5));
                }
            } catch (err) {
                console.error("Klaida gaunant pažymius:", err);
                setError("Nepavyko gauti pažymių.");
            } finally {
                setLoading(false);
            }
        };

        fetchGrades();
    }, []);

    return (
        <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
                <FiClipboard className="inline-block text-gray-500 mr-2" />
                Naujausi pažymiai
            </h2>
            {loading && <p className="text-gray-600 dark:text-white">Įkeliami naujausi pažymiai...</p>}
            {error && <p className="text-red-500">{error}</p>}
            {noRecentGrades && !loading && !error && (
                <p className="text-gray-600 dark:text-white">Naujausių pažymių nerasta.</p>
            )}
            {!noRecentGrades && !loading && !error && (
                <ul className="text-gray-600 dark:text-white mb-4">
                    {grades.map((grade) => (
                        <li key={grade.idPazymys} className="mb-2">
                            <strong>Pažymys:</strong> {grade.ivertinimas}/10
                            <br />
                            <strong>Data:</strong> {new Date(grade.data).toLocaleDateString()}
                        </li>
                    ))}
                </ul>
            )}
            <Link
                to="/showGrades"
                className="text-blue-500 mt-4 inline-block hover:underline"
            >
                Peržiūrėti visus pažymius
            </Link>
        </div>
    );
};

export default RecentGrades;

