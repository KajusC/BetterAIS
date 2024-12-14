import React, { useState } from "react";
import { deleteGrade } from "../../scripts/grades";

export default function DeleteGrade() {
    const [id, setId] = useState("");

    const handleDelete = async () => {
        try {
            await deleteGrade(id);
            alert("Grade deleted successfully!");
        } catch (error) {
            console.error(error);
            alert("Failed to delete grade.");
        }
    };

    return (
        <div>
            <label>
                Grade ID:
                <input
                    type="text"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
            </label>
            <button onClick={handleDelete}>Delete Grade</button>
        </div>
    );
}
