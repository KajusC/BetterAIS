import React, { useState } from 'react';
import { deleteTeacher } from '../../scripts/teachers.js';

export default function DeleteTeacher() {
  const [vidko, setVidko] = useState('');

  const handleDelete = async () => {
    try {
      await deleteTeacher(vidko);
      alert('Teacher deleted successfully!');
    } catch (error) {
      console.error(error);
      alert('Failed to delete teacher.');
    }
  };

  return (
    <div>
      <label>
        VIDKO:
        <input type="text" value={vidko} onChange={(e) => setVidko(e.target.value)} />
      </label>
      <button onClick={handleDelete}>Delete Teacher</button>
    </div>
  );
}
