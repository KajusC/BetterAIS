import React, { useState, useEffect } from "react";
import { getGradesByStudentId } from "../../scripts/grades"; // Importuoja funkciją pažymiams gauti

export default function CalculateGrades() {
    const [studentId, setStudentId] = useState(""); // Įveskite studento ID
    const [grades, setGrades] = useState([]); // Pažymiai iš duomenų bazės
    const [weights, setWeights] = useState({
        assignments: 0,
        exams: 0,
        participation: 0,
    });

    const [weightedGrade, setWeightedGrade] = useState(null);

    // Gauti pažymius pagal studento ID
    const fetchGrades = async () => {
        try {
            const data = await getGradesByStudentId(studentId); // Gauna pažymius studentui
            setGrades(
                data.map((grade) =>
                    grade.value > 10 ? { ...grade, value: 10 } : grade // Ribojame pažymius iki 10
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
            <h1 className="text-2xl font-bold mb-4">Svertinių pažymių skaičiavimas</h1>
            <div className="space-y-4">
                {/* Įveskite studento ID */}
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

                {/* Įveskite svorius */}
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

                {/* Skaičiavimo mygtukas */}
                <div>
                    <button
                        onClick={calculateWeightedGrade}
                        className="bg-green-500 text-white px-4 py-2 rounded"
                    >
                        Skaičiuoti
                    </button>
                </div>

                {/* Rezultato rodymas */}
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
