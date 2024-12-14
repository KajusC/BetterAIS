import React, { useState, useEffect } from "react";
import { getGradesByStudentId } from "../../scripts/grades"; // Importuoja funkcijà paþymiams gauti

export default function CalculateGrades() {
    const [studentId, setStudentId] = useState(""); // Áveskite studento ID
    const [grades, setGrades] = useState([]); // Paþymiai ið duomenø bazës
    const [weights, setWeights] = useState({
        assignments: 0,
        exams: 0,
        participation: 0,
    });

    const [weightedGrade, setWeightedGrade] = useState(null);

    // Gauti paþymius pagal studento ID
    const fetchGrades = async () => {
        try {
            const data = await getGradesByStudentId(studentId); // Gauna paþymius studentui
            setGrades(
                data.map((grade) =>
                    grade.value > 10 ? { ...grade, value: 10 } : grade // Ribojame paþymius iki 10
                )
            );
        } catch (error) {
            console.error("Klaida gaunant paþymius:", error);
            alert("Nepavyko gauti paþymiø ðiam studentui.");
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
            alert("Ðiam studentui nëra jokiø paþymiø.");
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
            <h1 className="text-2xl font-bold mb-4">Svertiniø paþymiø skaièiavimas</h1>
            <div className="space-y-4">
                {/* Áveskite studento ID */}
                <div>
                    <label className="block text-sm font-medium">Áveskite studento ID</label>
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
                        Gauti paþymius
                    </button>
                </div>

                {/* Áveskite svorius */}
                <div>
                    <h2 className="font-semibold text-lg">Áveskite svorio procentus</h2>
                    <div className="space-y-2">
                        <div>
                            <label className="block text-sm">Namø darbai (%)</label>
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

                {/* Skaièiavimo mygtukas */}
                <div>
                    <button
                        onClick={calculateWeightedGrade}
                        className="bg-green-500 text-white px-4 py-2 rounded"
                    >
                        Skaièiuoti
                    </button>
                </div>

                {/* Rezultato rodymas */}
                {weightedGrade && (
                    <div className="mt-4">
                        <h2 className="font-semibold text-lg">
                            Svertinis paþymys: {weightedGrade}
                        </h2>
                    </div>
                )}
            </div>
        </div>
    );
}
