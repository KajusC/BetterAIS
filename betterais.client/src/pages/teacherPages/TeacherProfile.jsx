import React, { useEffect, useState } from 'react';
import { useParams, Link, useNavigate } from 'react-router-dom';
import { getTeacherByVidko, deleteTeacher } from '../../scripts/teachers';  // Functions to fetch teacher and delete teacher

const TeacherDetail = () => {
  const { vidko } = useParams();  // Get the vidko parameter from the URL
  const navigate = useNavigate();
  const [teacher, setTeacher] = useState(null);

  useEffect(() => {
    const fetchTeacher = async () => {
      try {
        const data = await getTeacherByVidko(vidko);  // Fetch teacher data by vidko
        setTeacher(data);
      } catch (error) {
        console.error('Error fetching teacher details:', error);
        alert('Failed to fetch teacher details.');
      }
    };

    fetchTeacher();
  }, [vidko]);

  const handleDelete = async () => {
    const confirmDelete = window.confirm(`Ar tikrai norite trini dėstytoją, kurio VIDKO: ${vidko}?`);
    if (!confirmDelete) {
      navigate('/showAllTeachers');
      return;
    }
    try {
      await deleteTeacher(vidko);  // Delete teacher from the backend
      alert('Dėstytojas ištrintas!');
      
      navigate('/administrator');  // Redirect to View Teachers page
    } catch (error) {
      console.error('Error deleting teacher:', error);
      alert('Nepavyko ištrintni dėstytojo.');
    }
  };

  if (!teacher) return <div>Loading...</div>;

  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Dėstytojo informacija</h2>
      <div>
        <p><strong>Vidko:</strong> {teacher.vidko}</p>
        <p><strong>Kvalifikacija:</strong> {teacher.kvalifikacija}</p>
        {/* <p><strong>Vardas:</strong> {teacher.vardas} {teacher.pavarde}</p>
        <p><strong>Email:</strong> {teacher.elPastas}</p>
        <p><strong>Numeris:</strong> {teacher.telefonoNr}</p>

        <p><strong>Gimimo data:</strong> {teacher.gimimoData}</p> */}
      </div>
      <div className="space-x-4 mt-4">
        <Link to={`/edit-teacher/${teacher.vidko}`}>
          <button className="bg-yellow-500 text-white px-4 py-2 rounded">Redaguoti informaciją</button>
        </Link>
        <button className="bg-red-500 text-white px-4 py-2 rounded" onClick={handleDelete}>
          Trinti dėstytoją
        </button>
      </div>
    </div>
  );
};

export default TeacherDetail;
