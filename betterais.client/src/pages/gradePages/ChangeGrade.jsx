import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getGradeById, updateGrade } from "../../scripts/grades";

export default function ChangeGrade() {
    const { id } = useParams(); // Get grade ID from route parameters
    const navigate = useNavigate();
    const [gradeData, setGradeData] = useState({
        ivertinimas: "",
        data: "",
        idSuvestine: "",
    });
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Fetch grade details when the component loads
        const fetchGrade = async () => {
            console.log("Grade ID received:", id); // Debug log
            try {
                const data = await getGradeById(id); // Fetch grade by ID
                setGradeData(data);
                console.log("Fetched grade data:", data); // Debug log
            } catch (error) {
                console.error("Error fetching grade:", error);
                alert("Nepavyko gauti pažymio informacijos.");
            } finally {
                setLoading(false);
            }
        };
        fetchGrade();
    }, [id]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        const updatedGradeData = { ...gradeData, [name]: value };
        setGradeData(updatedGradeData);
        console.log("Updated grade data:", updatedGradeData); // Debug log
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log("Submitting grade data:", gradeData); // Debug log
        try {
            await updateGrade(id, gradeData); // Update grade with new data
            alert("Pažymys sėkmingai atnaujintas!");
            navigate("/view-grades"); // Navigate back to grades list
        } catch (error) {
            console.error("Error updating grade:", error);
            alert("Nepavyko atnaujinti pažymio.");
        }
    };

    if (loading) {
        return <div>Kraunama pažymio informacija...</div>;
    }

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
                        min="0"
                        max="10"
                        step="0.1"
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
                        className="border rounded px-4 py-2 w-full"
                        disabled
                    />
                </div>
                <button
                    type="submit"
                    className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                >
                    Atnaujinti Pažymį
                </button>
            </form>
        </div>
    );
}
