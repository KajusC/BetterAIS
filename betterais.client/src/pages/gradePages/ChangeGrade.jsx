import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { getGradeById, updateGrade } from "../../scripts/grades";

export default function ChangeGrade() {
    const { id } = useParams(); // Retrieve the grade ID from the route parameters
    const navigate = useNavigate();
    const [gradeData, setGradeData] = useState({
        ivertinimas: "",
        data: "",
        idSuvestine: "",
    });

    useEffect(() => {
        // Fetch the grade data when the component loads
        const fetchGrade = async () => {
            try {
                const data = await getGradeById(id); // Fetch grade by ID
                setGradeData(data);
            } catch (error) {
                console.error("Error fetching grade:", error);
                alert("Failed to fetch grade.");
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
            await updateGrade(id, gradeData); // Update the grade with the new data
            alert("Grade updated successfully!");
            navigate("/show-grades"); // Navigate back to the grades list
        } catch (error) {
            console.error("Error updating grade:", error);
            alert("Failed to update grade.");
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Change Grade</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block text-sm font-medium">Ivertinimas</label>
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
                    <label className="block text-sm font-medium">ID Suvestine</label>
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
                    Update Grade
                </button>
            </form>
        </div>
    );
}
