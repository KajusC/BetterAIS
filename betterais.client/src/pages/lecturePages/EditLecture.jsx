import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { getLectureById, getLecturesByModule, updateLecture } from '../../scripts/lectureAPI';
import { getAllModules } from '../../scripts/lectureAPI';
import { getAllTeachers } from '../../scripts/teachers';
import { getAllFaculties } from '../../scripts/lectureAPI';
import { LECTURE_TYPES } from '../../constants/constants';
import ToastNotification from '../../components/ToastNotification';

export default function EditLecture() {
    const navigate = useNavigate();

    const [modules, setModules] = useState([]);
    const [selectedModule, setSelectedModule] = useState('');
    const [lectures, setLectures] = useState([]);
    const [selectedLecture, setSelectedLecture] = useState('');
    const [formData, setFormData] = useState({
        fkModulis: '',
        paskaitosTipas: '',
        trukme: '',
        privalomas: false,
        fkDestytojas: '',
        fkFakultetas: '',
    });

    const [teachers, setTeachers] = useState([]);
    const [faculties, setFaculties] = useState([]);
    const [showToast, setShowToast] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [toastType, setToastType] = useState('success');
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        // Fetch all modules
        getAllModules()
            .then(setModules)
            .catch(() => handleToast('Klaida gaunant modulius.', 'danger'));

        // Fetch teachers and faculties
        getAllTeachers()
            .then(setTeachers)
            .catch(() => handleToast('Klaida gaunant dėstytojus.', 'danger'));

        getAllFaculties()
            .then(setFaculties)
            .catch(() => handleToast('Klaida gaunant fakultetus.', 'danger'));
    }, []);

    useEffect(() => {
        // Fetch lectures when a module is selected
        if (selectedModule) {
            getLecturesByModule(selectedModule)
                .then(setLectures)
                .catch(() => handleToast('Klaida gaunant paskaitas.', 'danger'));
        } else {
            setLectures([]);
            setSelectedLecture('');
        }
    }, [selectedModule]);

    useEffect(() => {
        // Fetch lecture data when a lecture is selected
        if (selectedLecture) {
            setLoading(true);
            getLectureById(selectedLecture)
                .then((data) => {
                    setFormData({
                        fkModulis: data.fkModulis,
                        paskaitosTipas: data.paskaitosTipas,
                        trukme: data.trukme,
                        privalomas: data.privalomas,
                        fkDestytojas: data.fkDestytojas,
                        fkFakultetas: data.fkFakultetas,
                    });
                })
                .catch(() => handleToast('Klaida gaunant paskaitos informaciją.', 'danger'))
                .finally(() => setLoading(false));
        } else {
            setFormData({
                fkModulis: '',
                paskaitosTipas: '',
                trukme: '',
                privalomas: false,
                fkDestytojas: '',
                fkFakultetas: '',
            });
        }
    }, [selectedLecture]);

    const handleToast = (message, type) => {
        setToastMessage(message);
        setToastType(type);
        setShowToast(true);
    };

    const handleInputChange = (e) => {
        const { name, value, type, checked } = e.target;
        setFormData({
            ...formData,
            [name]: type === 'checkbox' ? checked : value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        updateLecture(selectedLecture, formData)
            .then(() => {
                handleToast('Paskaita sėkmingai atnaujinta!', 'success');
                navigate('/view-lectures'); // Navigate back to the lectures list
            })
            .catch(() => handleToast('Klaida atnaujinant paskaitą.', 'danger'));
    };

    // Generate duration options (15 to 360 minutes in 15-minute steps)
    const generateDurationOptions = () => {
        const durations = [];
        for (let i = 15; i <= 360; i += 15) {
            durations.push(i);
        }
        return durations;
    };

    if (loading) {
        return <div>Kraunama paskaitos informacija...</div>;
    }

    return (
        <div className="max-w-md mx-auto mt-10 p-6 dark:bg-gray-800 rounded-lg shadow-md">
            <ToastNotification
                show={showToast}
                message={toastMessage}
                type={toastType}
                onClose={() => setShowToast(false)}
            />
            <h1 className="text-2xl font-bold mb-6 dark:text-white">Redaguoti Paskaitą</h1>

            {/* Module Selection */}
            <div className="mb-4">
                <label className="block text-gray-700 dark:text-white">Modulis</label>
                <select
                    value={selectedModule}
                    onChange={(e) => setSelectedModule(e.target.value)}
                    className="w-full px-3 py-2 border rounded-lg"
                    required
                >
                    <option value="">Pasirinkite modulį</option>
                    {modules.map((mod) => (
                        <option key={mod.kodas} value={mod.kodas}>
                            {mod.pavadinimas}
                        </option>
                    ))}
                </select>
            </div>

            {/* Lecture Selection */}
            {selectedModule && (
                <div className="mb-4">
                    <label className="block text-gray-700 dark:text-white">Paskaita</label>
                    <select
                        value={selectedLecture}
                        onChange={(e) => setSelectedLecture(e.target.value)}
                        className="w-full px-3 py-2 border rounded-lg"
                        required
                    >
                        <option value="">Pasirinkite paskaitą</option>
                        {lectures.map((lecture) => (
                            <option key={lecture.id} value={lecture.id}>
                                {lecture.pavadinimas}
                            </option>
                        ))}
                    </select>
                </div>
            )}

            {/* Lecture Form */}
            {selectedLecture && (
                <form onSubmit={handleSubmit}>
                    {/* Lecture Type */}
                    <div className="mb-4">
                        <label className="block text-gray-700 dark:text-white">Paskaitos Tipas</label>
                        <select
                            name="paskaitosTipas"
                            value={formData.paskaitosTipas}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border rounded-lg"
                            required
                        >
                            <option value="">Pasirinkite tipą</option>
                            {Object.entries(LECTURE_TYPES).map(([name, value]) => (
                                <option key={value} value={value}>
                                    {name}
                                </option>
                            ))}
                        </select>
                    </div>

                    {/* Duration */}
                    <div className="mb-4">
                        <label className="block text-gray-700 dark:text-white">Trukmė (minutėmis)</label>
                        <select
                            name="trukme"
                            value={formData.trukme}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border rounded-lg"
                            required
                        >
                            <option value="">Pasirinkite trukmę</option>
                            {generateDurationOptions().map((duration) => (
                                <option key={duration} value={duration}>
                                    {duration} min
                                </option>
                            ))}
                        </select>
                    </div>

                    {/* Mandatory */}
                    <div className="mb-4">
                        <label className="inline-flex items-center">
                            <input
                                type="checkbox"
                                name="privalomas"
                                checked={formData.privalomas}
                                onChange={handleInputChange}
                                className="form-checkbox"
                            />
                            <span className="ml-2 text-gray-700 dark:text-white">Privaloma</span>
                        </label>
                    </div>

                    {/* Teacher */}
                    <div className="mb-4">
                        <label className="block text-gray-700 dark:text-white">Dėstytojas</label>
                        <select
                            name="fkDestytojas"
                            value={formData.fkDestytojas}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border rounded-lg"
                            required
                        >
                            <option value="">Pasirinkite dėstytoją</option>
                            {teachers.map((teacher) => (
                                <option key={teacher.vidko} value={teacher.vidko}>
                                    {teacher.vardas} {teacher.pavarde}
                                </option>
                            ))}
                        </select>
                    </div>

                    {/* Faculty */}
                    <div className="mb-4">
                        <label className="block text-gray-700 dark:text-white">Fakultetas</label>
                        <select
                            name="fkFakultetas"
                            value={formData.fkFakultetas}
                            onChange={handleInputChange}
                            className="w-full px-3 py-2 border rounded-lg"
                            required
                        >
                            <option value="">Pasirinkite fakultetą</option>
                            {faculties.map((faculty) => (
                                <option key={faculty.kodas} value={faculty.kodas}>
                                    {faculty.pavadinimas}
                                </option>
                            ))}
                        </select>
                    </div>

                    <button
                        type="submit"
                        className="w-full bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600"
                    >
                        Atnaujinti Paskaitą
                    </button>
                </form>
            )}
        </div>
    );
}
