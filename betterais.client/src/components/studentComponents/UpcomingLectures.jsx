import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { FiCalendar } from 'react-icons/fi';
import { getUpcomingLectures } from '../../scripts/lectureAPI';

const UpcomingLectures = () => {
    const [lectures, setLectures] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);

    useEffect(() => {
        // Fetch upcoming lectures on component load
        getUpcomingLectures()
            .then((data) => {
                setLectures(data);
            })
            .catch((error) => {
                console.error('Error:', error);
                setError(true);
            })
            .finally(() => setLoading(false));
    }, []);

    if (loading) {
        return (
            <div className="p-6 text-center text-gray-700 dark:text-white">
                Kraunama...
            </div>
        );
    }

    return (
        <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
                <FiCalendar className="inline-block text-blue-500 mr-2" />
                Ateinančios paskaitos
            </h2>

            {/* Display lectures or fallback message */}
            {lectures.length > 0 ? (
                <ul className="text-gray-600 dark:text-white">
                    {lectures.map((lecture) => (
                        <li key={lecture.id} className="mb-2">
                            {lecture.pavadinimas} - Auditorija {lecture.kabinetasNumeris} - {lecture.laikas}
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-gray-500 dark:text-gray-400 text-center">
                    Nėra ateinančių paskaitų
                </p>
            )}

            {/* View all lectures button */}
            <div className="text-center mt-4">
                <Link
                    to="/timetable"
                    className="text-blue-500 inline-block hover:underline text-sm"
                >
                    Peržiūrėti visas paskaitas
                </Link>
            </div>
        </div>
    );
};

export default UpcomingLectures;
