import React, { useState } from "react";
import { getGradesByStudentId } from "../../scripts/grades"; // Import function for fetching grades

export default function CalculateGrades() {
    const [studentId, setStudentId] = useState(""); // Enter student ID
    const [grades, setGrades] = useState([]); // Grades from the database
    const [weights, setWeights] = useState({
        assignments: 0,
        exams: 0,
        participation: 0,
    });

    const [weightedGrade, setWeightedGrade] = useState(null);

    // Fetch grades by student ID
    const fetchGrades = async () => {
        if (!studentId.trim()) {
            alert("Studento ID negali būti tuščias.");
            return;
        }

        try {
            const data = await getGradesByStudentId(studentId); // Fetch grades
            console.log("Fetched grades data:", data);

            if (!Array.isArray(data)) {
                throw new Error("API response is not an array.");
            }

            // Transform the API response to match expected structure
            const transformedGrades = data.map((grade, index) => ({
                id: grade.idPazymys, // Map idPazymys to id
                value: grade.ivertinimas, // Map ivertinimas to value
                type: `Type ${index + 1}`, // Add placeholder type
                date: grade.data, // Optional: Map date if needed
            }));

            console.log("Transformed grades:", transformedGrades);

            setGrades(
                transformedGrades.map((grade) =>
                    grade.value > 10 ? { ...grade, value: 10 } : grade // Limit grades to 10
                )
            );
        } catch (error) {
            console.error("Klaida gaunant pažymius:", error);
            alert("Nepavyko gauti pažymių šiam studentui.");
        }
    };

    const handleWeightChange = (e) => {
        const { name, value } = e.target;
        setWeights({ ...weights, [name]: parseFloat(value) });
    };

    const calculateWeightedGrade = () => {
        const totalWeight = weights.assignments + weights.exams + weights.participation;

        if (totalWeight !== 100) {
            alert("Bendras svoris turi sudaryti 100%.");
            return;
        }

        if (grades.length === 0) {
            alert("Šiam studentui nėra jokių pažymių.");
            return;
        }

        // Use placeholder type logic for demonstration
        const assignmentGrade = grades[0]?.value || 0; // Example: First grade as assignment
        const examGrade = grades[1]?.value || 0; // Example: Second grade as exam
        const participationGrade = grades[2]?.value || 0; // Example: Third grade as participation

        const result =
            (assignmentGrade * weights.assignments) / 100 +
            (examGrade * weights.exams) / 100 +
            (participationGrade * weights.participation) / 100;

        setWeightedGrade(result.toFixed(2));
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-2xl font-bold mb-4">Svertinių pažymių skaičiavimas</h1>
            <div className="space-y-4">
                {/* Enter student ID */}
                <div>
                    <label className="block text-sm font-medium">Įveskite studento ID</label>
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
                        Gauti pažymius
                    </button>
                </div>

                {/* Enter weights */}
                <div>
                    <h2 className="font-semibold text-lg">Įveskite svorio procentus</h2>
                    <div className="space-y-2">
                        <div>
                            <label className="block text-sm">Namų darbai (%)</label>
                            <input
                                type="number"
                                name="assignments"
                                value={weights.assignments}
                                onChange={handleWeightChange}
                                className="border rounded px-4 py-2 w-full"
                            />
                        </div>
                        <div>
                            <label className="block text-sm">Egzaminai (%)</label>
                            <input
                                type="number"
                                name="exams"
                                value={weights.exams}
                                onChange={handleWeightChange}
                                className="border rounded px-4 py-2 w-full"
                            />
                        </div>
                        <div>
                            <label className="block text-sm">Dalyvavimas (%)</label>
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

                {/* Calculate button */}
                <div>
                    <button
                        onClick={calculateWeightedGrade}
                        className="bg-green-500 text-white px-4 py-2 rounded"
                    >
                        Skaičiuoti
                    </button>
                </div>

                {/* Display grades */}
                <div className="mt-4">
                    <h2 className="font-semibold text-lg">Pažymiai:</h2>
                    <ul>
                        {grades.map((grade, index) => (
                            <li key={grade.id}>
                                {`Type ${index + 1}:`} {grade.value}
                            </li>
                        ))}
                    </ul>
                </div>

                {/* Display result */}
                {weightedGrade && (
                    <div className="mt-4">
                        <h2 className="font-semibold text-lg">
                            Svertinis pažymys: {weightedGrade}
                        </h2>
                    </div>
                )}
            </div>
        </div>
    );
}
