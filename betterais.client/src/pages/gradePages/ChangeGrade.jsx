import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getGradeById, updateGrade } from "../../scripts/grades";

export default function KeistiPazymi() {
    const { id } = useParams(); // Gauti pažymio ID iš maršruto parametrų
    const navigate = useNavigate();
    const [gradeData, setGradeData] = useState({
        ivertinimas: "",
        data: "",
        idSuvestine: "",
    });

    useEffect(() => {
        // Gauti pažymio duomenis, kai komponentas užsikrauna
        const fetchGrade = async () => {
            try {
                const data = await getGradeById(id); // Gauti pažymį pagal ID
                setGradeData(data);
            } catch (error) {
                console.error("Klaida gaunant pažymį:", error);
                alert("Nepavyko gauti pažymio.");
            }
        };
        fetchGrade();
    }, [id]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setGradeData({ ...gradeData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await updateGrade(id, gradeData); // Atnaujinti pažymį su naujais duomenimis
            alert("Pažymys sėkmingai atnaujintas!");
            navigate("/rodyti-pazymius"); // Grįžti į pažymių sąrašą
        } catch (error) {
            console.error("Klaida atnaujinant pažymį:", error);
            alert("Nepavyko atnaujinti pažymio.");
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Keisti Pažymį</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block text-sm font-medium">Įvertinimas</label>
                    <input
                        type="number"
                        name="ivertinimas"
                        value={gradeData.ivertinimas}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium">Data</label>
                    <input
                        type="date"
                        name="data"
                        value={gradeData.data}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium">ID Suvestinė</label>
                    <input
                        type="number"
                        name="idSuvestine"
                        value={gradeData.idSuvestine}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        disabled
                    />
                </div>
                <button
                    type="submit"
                    className="bg-blue-500 text-white px-4 py-2 rounded"
                >
                    Atnaujinti Pažymį
                </button>
            </form>
        </div>
    );
}
