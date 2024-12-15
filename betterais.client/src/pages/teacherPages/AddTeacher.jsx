import React, { useState } from 'react';
import { addTeacher } from '../../scripts/teachers';
import { useNavigate } from 'react-router-dom';

export default function AddTeacher() {
  const [formData, setFormData] = useState({
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
  const navigate = useNavigate();

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addTeacher(formData);
      
      // Show success message and navigate to a different page (e.g., home or teacher list)
      alert('Dėstytojas pridėtas sėkmingai!');
      navigate('/');
      
    } catch (error) {
      console.error('Nepavyko pridėti dėstytojo:', error);
      alert('Nepavyko pridėti dėstytojo.');
    }
  };

  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Pridėti dėstytoją</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div>
          <label className="block text-sm font-medium">Vidko</label>
          <input
            type="text"
            name="vidko"
            value={formData.vidko}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Slaptažodis</label>
          <input
            type="password"
            name="slaptazodis"
            value={formData.slaptazodis}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Vardas</label>
          <input
            type="text"
            name="vardas"
            value={formData.vardas}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Pavardė</label>
          <input
            type="text"
            name="pavarde"
            value={formData.pavarde}
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
            value={formData.elPastas}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
            required
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Telefono numeris</label>
          <input
            type="text"
            name="telefonoNr"
            value={formData.telefonoNr}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Gimimo data</label>
          <input
            type="date"
            name="gimimoData"
            value={formData.gimimoData}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
          />
        </div>
        <div>
          <label className="block text-sm font-medium">Role ID</label>
          <input
            type="number"
            name="roleId"
            value={formData.roleId}
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
            value={formData.kvalifikacija}
            onChange={handleInputChange}
            className="border rounded px-4 py-2 w-full"
            required
          />
        </div>
        <button
          type="submit"
          className="bg-blue-500 text-white px-4 py-2 rounded"
        >
          Pridėti
        </button>
      </form>
    </div>
  );
}
