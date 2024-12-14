import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getGradeById, updateGrade } from "../../scripts/grades";

export default function KeistiPazymi() {
    const { id } = useParams(); // Gauti pa�ymio ID i� mar�ruto parametr�
    const navigate = useNavigate();
    const [gradeData, setGradeData] = useState({
        ivertinimas: "",
        data: "",
        idSuvestine: "",
    });

    useEffect(() => {
        // Gauti pa�ymio duomenis, kai komponentas u�sikrauna
        const fetchGrade = async () => {
            try {
                const data = await getGradeById(id); // Gauti pa�ym� pagal ID
                setGradeData(data);
            } catch (error) {
                console.error("Klaida gaunant pa�ym�:", error);
                alert("Nepavyko gauti pa�ymio.");
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
            await updateGrade(id, gradeData); // Atnaujinti pa�ym� su naujais duomenimis
            alert("Pa�ymys s�kmingai atnaujintas!");
            navigate("/rodyti-pazymius"); // Gr��ti � pa�ymi� s�ra��
        } catch (error) {
            console.error("Klaida atnaujinant pa�ym�:", error);
            alert("Nepavyko atnaujinti pa�ymio.");
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Keisti Pa�ym�</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block text-sm font-medium">�vertinimas</label>
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
                    <label className="block text-sm font-medium">ID Suvestin�</label>
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
                    Atnaujinti Pa�ym�
                </button>
            </form>
        </div>
    );
}
