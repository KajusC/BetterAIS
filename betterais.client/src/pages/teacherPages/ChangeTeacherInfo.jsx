import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getTeacherByVidko, updateTeacher } from '../../scripts/teachers';  // Functions to fetch and update teacher

const EditTeacher = () => {
  const { vidko } = useParams();
  const navigate = useNavigate();
  const [teacherData, setTeacherData] = useState({
    vidko: '',
    slaptazodis: '',
    vardas: '',
    pavarde: '',
    elPastas: '',
    telefonoNr: '',
    gimimoData: '',
    roleId: '',
    kvalifikacija: '',
  });

  useEffect(() => {
    const fetchTeacherData = async () => {
      try {
        const data = await getTeacherByVidko(vidko);
        setTeacherData(data);
      } catch (error) {
        console.error('Error fetching teacher data:', error);
        alert('Failed to fetch teacher data.');
      }
    };

    fetchTeacherData();
  }, [vidko]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setTeacherData({ ...teacherData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await updateTeacher(vidko, teacherData);  // Update teacher
      alert('Teacher info updated successfully!');
      navigate(`/teacher-profile/${vidko}`);  // Redirect to teacher details page
    } catch (error) {
      console.error('Error updating teacher:', error);
      alert('Failed to update teacher.');
    }
  };

  return (
    <div className="container mx-auto p-6">
    <h2 className="text-2xl font-bold mb-4">Input new Teacher info</h2>
    <form onSubmit={handleSubmit} className="space-y-4">
      <div>
        <label className="block text-sm font-medium">Vidko</label>
        <input
          type="text"
          name="vidko"
          value={teacherData.vidko}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          disabled
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Password</label>
        <input
          type="password"
          name="slaptazodis"
          value={teacherData.slaptazodis}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
      <div>
        <label className="block text-sm font-medium">First Name</label>
        <input
          type="text"
          name="vardas"
          value={teacherData.vardas}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Last Name</label>
        <input
          type="text"
          name="pavarde"
          value={teacherData.pavarde}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Email</label>
        <input
          type="email"
          name="elPastas"
          value={teacherData.elPastas}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Phone Number</label>
        <input
          type="text"
          name="telefonoNr"
          value={teacherData.telefonoNr}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Birth Date</label>
        <input
          type="date"
          name="gimimoData"
          value={teacherData.gimimoData}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Role ID</label>
        <input
          type="number"
          name="roleId"
          value={teacherData.roleId}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
      <div>
        <label className="block text-sm font-medium">Kvalifikacija</label>
        <input
          type="text"
          name="kvalifikacija"
          value={teacherData.kvalifikacija}
          onChange={handleInputChange}
          className="border rounded px-4 py-2 w-full"
          required
        />
      </div>
        <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded">
          Update Teacher Info
        </button>
      </form>
    </div>
  );
};

export default EditTeacher;
