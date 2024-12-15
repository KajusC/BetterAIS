import React, { useState } from 'react';
import { deleteTeacher } from '../../scripts/teachers.js';
import { useNavigate } from 'react-router-dom';

export default function DeleteTeacher() {
  const [vidko, setVidko] = useState('');
  const navigate = useNavigate();

  const handleDelete = async () => {
    const confirmDelete = window.confirm(`Ar tikrai norite trini dėstytoją, kurio VIDKO: ${vidko}?`);
    if (!confirmDelete) {
      navigate('/administrator');
      return;
    }
    try {
      await deleteTeacher(vidko);
      alert('Dėstytojas ištrintas.');
      navigate('/');
    } catch (error) {
      console.error(error);
      alert('Nepavyko ištrinti dėstytojo.');
      navigate('/administrator');
    }
  };

  return (
    <div>
      <label>
        VIDKO:
        <input type="text" value={vidko} onChange={(e) => setVidko(e.target.value)} />
      </label>
      <button className="bg-blue-500 text-white px-4 py-2 rounded" onClick={handleDelete}>Trinti dėstytoją</button>
    </div>
  );
}
