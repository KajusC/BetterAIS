import React, { useState, useEffect } from "react";
import { getGradesByStudentId } from "../../scripts/grades"; // Import the function to fetch grades

export default function CalculateGrades() {
    const [studentId, setStudentId] = useState(""); // To input student ID
    const [grades, setGrades] = useState([]); // Grades fetched from the backend
    const [weights, setWeights] = useState({
        assignments: 0,
        exams: 0,
        participation: 0,
    });

    const [weightedGrade, setWeightedGrade] = useState(null);

    // Fetch grades when the student ID is entered
    const fetchGrades = async () => {
        try {
            const data = await getGradesByStudentId(studentId); // Fetch grades for the student
            setGrades(
                data.map((grade) =>
                    grade.value > 10 ? { ...grade, value: 10 } : grade // Cap grades at 10
                )
            );
        } catch (error) {
            console.error("Error fetching grades:", error);
            alert("Failed to fetch grades for the student.");
        }
    };

    const handleWeightChange = (e) => {
        const { name, value } = e.target;
        setWeights({ ...weights, [name]: parseFloat(value) });
    };

    const calculateWeightedGrade = () => {
        const totalWeight = weights.assignments + weights.exams + weights.participation;

        if (totalWeight !== 100) {
            alert("The total weight must equal 100%");
            return;
        }

        if (grades.length === 0) {
            alert("No grades available for the selected student.");
            return;
        }

        const assignmentGrade = grades.find((g) => g.type === "Assignment")?.value || 0;
        const examGrade = grades.find((g) => g.type === "Exam")?.value || 0;
        const participationGrade = grades.find((g) => g.type === "Participation")?.value || 0;

        const result =
            (assignmentGrade * weights.assignments) / 100 +
            (examGrade * weights.exams) / 100 +
            (participationGrade * weights.participation) / 100;

        setWeightedGrade(result.toFixed(2));
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-2xl font-bold mb-4">Calculate Weighted Grades</h1>
            <div className="space-y-4">
                {/* Input Student ID */}
                <div>
                    <label className="block text-sm font-medium">Enter Student ID</label>
                    <input
                        type="text"
                        value={studentId}
                        onChange={(e) => setStudentId(e.target.value)}
                        className="border rounded px-4 py-2 w-full"
                    />
                    <button
                        onClick={fetchGrades}
                        className="bg-blue-500 text-white px-4 py-2 rounded mt-2"
                    >
                        Fetch Grades
                    </button>
                </div>

                {/* Input Weights */}
                <div>
                    <h2 className="font-semibold text-lg">Enter Weight Percentages</h2>
                    <div className="space-y-2">
                        <div>
                            <label className="block text-sm">Assignments (%)</label>
                            <input
                                type="number"
                                name="assignments"
                                value={weights.assignments}
                                onChange={handleWeightChange}
                                className="border rounded px-4 py-2 w-full"
                            />
                        </div>
                        <div>
                            <label className="block text-sm">Exams (%)</label>
                            <input
                                type="number"
                                name="exams"
                                value={weights.exams}
                                onChange={handleWeightChange}
                                className="border rounded px-4 py-2 w-full"
                            />
                        </div>
                        <div>
                            <label className="block text-sm">Participation (%)</label>
                            <input
                                type="number"
                                name="participation"
                                value={weights.participation}
                                onChange={handleWeightChange}
                                className="border rounded px-4 py-2 w-full"
                            />
                        </div>
                    </div>
                </div>

                {/* Calculate Button */}
                <div>
                    <button
                        onClick={calculateWeightedGrade}
                        className="bg-green-500 text-white px-4 py-2 rounded"
                    >
                        Calculate
                    </button>
                </div>

                {/* Display Result */}
                {weightedGrade && (
                    <div className="mt-4">
                        <h2 className="font-semibold text-lg">Weighted Grade: {weightedGrade}</h2>
                    </div>
                )}
            </div>
        </div>
    );
}
