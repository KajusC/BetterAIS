import React, { useState } from "react";
import { deleteGrade } from "../../scripts/grades";

export default function IstrintiPazymi() {
    const [id, setId] = useState("");

    const handleDelete = async () => {
        try {
            await deleteGrade(id);
            alert("Paþymys sëkmingai iðtrintas!");
        } catch (error) {
            console.error(error);
            alert("Nepavyko iðtrinti paþymio.");
        }
    };

    return (
        <div>
            <label>
                Paþymio ID:
                <input
                    type="text"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
            </label>
            <button onClick={handleDelete}>Iðtrinti Paþymá</button>
        </div>
    );
}
