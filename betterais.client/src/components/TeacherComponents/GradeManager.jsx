import React from "react";
import { FiClipboard } from "react-icons/fi";
import { Link } from "react-router-dom";

export default function GradeManager() {
    return (
        <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
            <h2 className="text-xl font-semibold text-gray-700 mb-4 dark:text-white">
                <FiClipboard className="inline-block text-gray-500 mr-2" />
                Grade Management
            </h2>
            <ul className="text-gray-600 dark:text-white">
                <li>
                    <Link
                        to="/addGrade"
                        className="text-green-500 mt-4 inline-block hover:underline"
                    >
                        Add a grade to student
                    </Link>
                </li>
                <li>
                    <Link
                        to="/calculateGrades"
                        className="text-blue-500 mt-4 inline-block hover:underline"
                    >
                        Calculate weighted grade
                    </Link>
                </li>
                <li>
                    <Link
                        to="/changeGrade"
                        className="text-yellow-500 mt-4 inline-block hover:underline"
                    >
                        Edit student grade
                    </Link>
                </li>
                <li>
                    <Link
                        to="/deleteGrade"
                        className="text-red-500 mt-4 inline-block hover:underline"
                    >
                        Delete student grade
                    </Link>
                </li>
                <li>
                    <Link
                        to="/showGrades"
                        className="text-blue-500 mt-4 inline-block hover:underline"
                    >
                        View all grades
                    </Link>
                </li>
            </ul>
        </div>
    );
}
