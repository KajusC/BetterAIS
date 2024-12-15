import React, { useState } from "react";
import { deleteGrade } from "../../scripts/grades";

export default function IstrintiPazymi() {
    const [id, setId] = useState("");

    const handleDelete = async () => {
        try {
            await deleteGrade(id);
            alert("Pažymys sėkmingai ištrintas!");
        } catch (error) {
            console.error(error);
            alert("Nepavyko ištrinti pažymio.");
        }
    };

    return (
        <div>
            <label>
                Pažymio ID:
                <input
                    type="text"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
            </label>
            <button onClick={handleDelete}>Ištrinti Pažymį</button>
        </div>
    );
}
