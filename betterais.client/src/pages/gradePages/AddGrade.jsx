import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { addGrade } from "../../scripts/grades";

export default function AddGrade() {
    const [formData, setFormData] = useState({
        ivertinimas: "",
        data: "",
        idSuvestine: "",
    });

    const navigate = useNavigate();

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await addGrade(formData); // Call the addGrade function
            alert("Pa�ymys prid�tas s�kmingai!");
            navigate("/show-grades"); // Redirect to the grades list page
        } catch (error) {
            console.error("Klaida pridedant pa�ym�:", error);
            alert("Nepavyko prid�ti pa�ymio.");
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h2 className="text-2xl font-bold mb-4">Prid�ti pa�ym�</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block text-sm font-medium">�vertinimas</label>
                    <input
                        type="number"
                        name="ivertinimas"
                        value={formData.ivertinimas}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        placeholder="�veskite pa�ym�"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium">Data</label>
                    <input
                        type="date"
                        name="data"
                        value={formData.data}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        required
                    />
                </div>
                <div>
                    <label className="block text-sm font-medium">Suvestin�s ID</label>
                    <input
                        type="number"
                        name="idSuvestine"
                        value={formData.idSuvestine}
                        onChange={handleInputChange}
                        className="border rounded px-4 py-2 w-full"
                        placeholder="�veskite suvestin�s ID"
                        required
                    />
                </div>
                <button
                    type="submit"
                    className="bg-blue-500 text-white px-4 py-2 rounded"
                >
                    Prid�ti pa�ym�
                </button>
            </form>
        </div>
    );
}
