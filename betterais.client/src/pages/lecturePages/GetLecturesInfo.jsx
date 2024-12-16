import React, { useState, useEffect } from 'react';
import { getLecturesByTeacher } from '../../scripts/lectureAPI';
import { useAuth } from '../../contexts/AuthContext';

const TeacherLectures = () => {
    const { user } = useAuth(); // Retrieve logged-in teacher details
    const [modules, setModules] = useState([]); // Modules assigned to the teacher
    const [selectedModule, setSelectedModule] = useState('');
    const [lectures, setLectures] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        // Fetch modules assigned to the teacher (mock or API call)
        setModules([
            { kodas: 'INF101', pavadinimas: 'Programavimas' },
            { kodas: 'MATH101', pavadinimas: 'Matematika' },
        ]);
    }, []);

    const handleModuleChange = async (e) => {
        setSelectedModule(e.target.value);
        setLoading(true);
        try {
            const data = await getLecturesByTeacher(user.teacherId);
            const filteredLectures = data.filter(
                (lecture) => lecture.fkModulis === e.target.value
            );
            setLectures(filteredLectures);
        } catch (error) {
            console.error('Error fetching lectures:', error);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Mano Paskaitos</h1>
            <div className="mb-4">
                <label className="block mb-2">Pasirinkite modulį:</label>
                <select
                    value={selectedModule}
                    onChange={handleModuleChange}
                    className="border px-4 py-2 rounded"
                >
                    <option value="">Pasirinkite modulį</option>
                    {modules.map((mod) => (
                        <option key={mod.kodas} value={mod.kodas}>
                            {mod.pavadinimas}
                        </option>
                    ))}
                </select>
            </div>

            {loading ? (
                <p>Kraunama...</p>
            ) : lectures.length > 0 ? (
                <table className="w-full border">
                    <thead>
                        <tr>
                            <th className="border px-4 py-2">Pavadinimas</th>
                            <th className="border px-4 py-2">Data</th>
                            <th className="border px-4 py-2">Laikas</th>
                            <th className="border px-4 py-2">Auditorija</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lectures.map((lecture) => (
                            <tr key={lecture.idPaskaita}>
                                <td className="border px-4 py-2">{lecture.pavadinimas}</td>
                                <td className="border px-4 py-2">{lecture.data}</td>
                                <td className="border px-4 py-2">{lecture.laikas}</td>
                                <td className="border px-4 py-2">{lecture.kabinetasNumeris}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            ) : (
                <p>Nėra paskaitų pasirinktam moduliui.</p>
            )}
        </div>
    );
};

export default TeacherLectures;
