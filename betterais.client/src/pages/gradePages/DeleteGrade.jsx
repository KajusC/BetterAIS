import React, { useState } from "react";
import { deleteGrade } from "../../scripts/grades";

export default function IstrintiPazymi() {
    const [id, setId] = useState("");

    const handleDelete = async () => {
        try {
            await deleteGrade(id);
            alert("Pa�ymys s�kmingai i�trintas!");
        } catch (error) {
            console.error(error);
            alert("Nepavyko i�trinti pa�ymio.");
        }
    };

    return (
        <div>
            <label>
                Pa�ymio ID:
                <input
                    type="text"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
            </label>
            <button onClick={handleDelete}>I�trinti Pa�ym�</button>
        </div>
    );
}
