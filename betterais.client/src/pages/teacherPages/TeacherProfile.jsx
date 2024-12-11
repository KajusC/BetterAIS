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
    try {
      await deleteTeacher(vidko);  // Delete teacher from the backend
      alert('Teacher deleted successfully!');
      navigate('/showAllTeachers');  // Redirect to View Teachers page
    } catch (error) {
      console.error('Error deleting teacher:', error);
      alert('Failed to delete teacher.');
    }
  };

  if (!teacher) return <div>Loading...</div>;

  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Teacher Details</h2>
      <div>
        <p><strong>Vidko:</strong> {teacher.vidko}</p>
        <p><strong>Name:</strong> {teacher.vardas} {teacher.pavarde}</p>
        <p><strong>Email:</strong> {teacher.elPastas}</p>
        <p><strong>Phone:</strong> {teacher.telefonoNr}</p>
        <p><strong>Birth Date:</strong> {teacher.gimimoData}</p>
        <p><strong>Role ID:</strong> {teacher.roleId}</p>
      </div>
      <div className="space-x-4 mt-4">
        <Link to={`/edit-teacher/${teacher.vidko}`}>
          <button className="bg-yellow-500 text-white px-4 py-2 rounded">Edit Teacher Info</button>
        </Link>
        <button className="bg-red-500 text-white px-4 py-2 rounded" onClick={handleDelete}>
          Delete Teacher
        </button>
      </div>
    </div>
  );
};

export default TeacherDetail;
