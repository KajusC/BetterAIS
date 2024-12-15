import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FiClipboard } from "react-icons/fi";
import { getGradesByStudentId } from "../../scripts/grades"; // Function to fetch grades by student ID

const RecentGrades = ({ studentId }) => {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [noRecentGrades, setNoRecentGrades] = useState(false);

    useEffect(() => {
        const fetchGrades = async () => {
            if (!studentId) {
                setError("Studento ID nerastas.");
                setLoading(false);
                return;
            }

            try {
                const data = await getGradesByStudentId(studentId); // Fetch grades for the specific student
                if (!data || data.length === 0) {
                    setNoRecentGrades(true);
                } else {
                    setGrades(data.slice(0, 5)); // Limit to the 5 most recent grades
                }
            } catch (err) {
                console.error("Error fetching grades:", err);
                setError(
                    "Nepavyko gauti pažymių. Patikrinkite ryšį arba susisiekite su pagalba."
                );
            } finally {
                setLoading(false);
            }
        };

        fetchGrades();
    }, [studentId]); // Dynamically fetch grades when `studentId` changes

    return (
        <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
                <FiClipboard className="inline-block text-gray-500 mr-2" />
                Naujausi pažymiai
            </h2>
            {loading && (
                <p className="text-gray-600 dark:text-white">Įkeliami naujausi pažymiai...</p>
            )}
            {error && (
                <div className="text-red-500">
                    <p>{error}</p>
                    <button
                        onClick={() => window.location.reload()} // Simple reload button for retry
                        className="bg-blue-500 text-white px-3 py-1 rounded mt-2"
                    >
                        Bandykite dar kartą
                    </button>
                </div>
            )}
            {noRecentGrades && !loading && !error && (
                <p className="text-gray-600 dark:text-white">Naujausių pažymių nerasta.</p>
            )}
            {!noRecentGrades && !loading && !error && (
                <ul className="text-gray-600 dark:text-white mb-4">
                    {grades.map((grade) => (
                        <li key={grade.idPazymys} className="mb-2">
                            <strong>Pažymys:</strong> {grade.ivertinimas}/10
                            <br />
                            <strong>Data:</strong>{" "}
                            {new Date(grade.data).toLocaleDateString("lt-LT")}
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





/*import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FiClipboard } from "react-icons/fi";
import { getGradesByStudentId } from "../../scripts/grades"; // Function to fetch grades by student ID

const RecentGrades = () => {
    const [grades, setGrades] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [noRecentGrades, setNoRecentGrades] = useState(false);

    useEffect(() => {
        const fetchGrades = async () => {
            const studentId = "V0025"; // Hardcoded student ID for testing

            try {
                const data = await getGradesByStudentId(studentId); // Fetch grades for the specific student
                if (!data || data.length === 0) {
                    setNoRecentGrades(true);
                } else {
                    setGrades(data.slice(0, 5)); // Limit to the 5 most recent grades
                }
            } catch (err) {
                console.error("Error fetching grades:", err);
                setError(
                    "Unable to fetch grades. Please check your connection or contact support."
                );
            } finally {
                setLoading(false);
            }
        };

        fetchGrades();
    }, []); // Removed dependency on `studentId`

    return (
        <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
                <FiClipboard className="inline-block text-gray-500 mr-2" />
                Naujausi pažymiai
            </h2>
            {loading && (
                <p className="text-gray-600 dark:text-white">Įkeliami naujausi pažymiai...</p>
            )}
            {error && (
                <div className="text-red-500">
                    <p>{error}</p>
                    <button
                        onClick={() => window.location.reload()} // Simple reload button for retry
                        className="bg-blue-500 text-white px-3 py-1 rounded mt-2"
                    >
                        Bandykite dar kartą
                    </button>
                </div>
            )}
            {noRecentGrades && !loading && !error && (
                <p className="text-gray-600 dark:text-white">Naujausių pažymių nerasta.</p>
            )}
            {!noRecentGrades && !loading && !error && (
                <ul className="text-gray-600 dark:text-white mb-4">
                    {grades.map((grade) => (
                        <li key={grade.idPazymys} className="mb-2">
                            <strong>Pažymys:</strong> {grade.ivertinimas}/10
                            <br />
                            <strong>Data:</strong>{" "}
                            {new Date(grade.data).toLocaleDateString("lt-LT")}
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
*/