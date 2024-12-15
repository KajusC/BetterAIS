import React, { useEffect, useState } from 'react';
import { getAllTeachers, getFilteredTeachers, getKvalifikacijaOptions } from '../../scripts/teachers';
import { Link } from 'react-router-dom';

const ViewTeachers = () => {
  const [teachers, setTeachers] = useState([]);
  const [kvalifikacijaOptions, setKvalifikacijaOptions] = useState([]);  // State for kvalifikacija options
  const [selectedKvalifikacija, setSelectedKvalifikacija] = useState('');  // State for the selected kvalifikacija


  useEffect(() => {
    const fetchTeachers = async () => {
      console.log('Selected Kvalifikacija:', selectedKvalifikacija);
      try {
        let data;
        if (selectedKvalifikacija){
          data = await getFilteredTeachers(selectedKvalifikacija);
        }else
        {
          data = await getAllTeachers();
        } 
        setTeachers(data);
      } catch (error) {
        console.error('Error fetching teachers:', error);
        alert('Failed to fetch teachers.');
      }
    };

    fetchTeachers();
  }, [selectedKvalifikacija]);


  useEffect(() => {
    const fetchKvalifikacijaOptions = async () => {
      try {
        const options = await getKvalifikacijaOptions(); 
        setKvalifikacijaOptions(options);
      } catch (error) {
        console.error('Error fetching kvalifikacija options:', error);
        alert('Failed to fetch kvalifikacija options.');
      }
    };

    fetchKvalifikacijaOptions(); 
  }, []);

  const handleKvalifikacijaChange = (event) => {
    setSelectedKvalifikacija(event.target.value);  // Update selected kvalifikacija on change
  };
  


  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-4">Peržiurėti dėstytojus</h2>

      <div className="mb-4">
        <label htmlFor="kvalifikacija" className="mr-2">Filtruoti pagal kvalifikaciją:</label>
        <select
          id="kvalifikacija"
          value={selectedKvalifikacija}
          onChange={handleKvalifikacijaChange}
          className="px-4 py-2 border rounded"
        >
          <option value="">Visi</option> {/* Option for no filter */}
          {kvalifikacijaOptions.map((kvalifikacija, index) => (
            <option key={index} value={kvalifikacija}>{kvalifikacija}</option>
          ))}
        </select>
      </div>


      <table className="table-auto w-full">
        <thead>
          <tr>
            <th className="px-4 py-2">Vidko</th>
            <th className="px-4 py-2">Kvalifikacija</th>
            <th className="px-4 py-2"></th>
          </tr>
        </thead>
        <tbody>
          {teachers.map((teacher) => (
            <tr key={teacher.vidko}>
              <td className="px-4 py-2">{teacher.vidko}</td>
              <td className="px-4 py-2">{teacher.kvalifikacija}</td>
              <td className="px-4 py-2">
                <Link to={`/teacher-profile/${teacher.vidko}`}>
                  <button className="bg-blue-500 text-white px-4 py-2 rounded">Veiksmai</button>
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ViewTeachers;