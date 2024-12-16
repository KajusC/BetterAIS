﻿import React, { useState, useEffect } from 'react';
import { addLecture, getAllTeachers, getAllFaculties, getAllModules } from '../../scripts/lectureAPI';
import { LECTURE_TYPES } from '../../constants/constants';
import ToastNotification from '../../components/ToastNotification';

export default function AddLecture() {
    const [formData, setFormData] = useState({
        trukme: '',
        privalomas: false,
        paskaitosTipas: '',
        fkModulis: '',
        fkDestytojas: '',
        fkFakultetas: '',
    });

    const [modules, setModules] = useState([]);
    const [teachers, setTeachers] = useState([]);
    const [faculties, setFaculties] = useState([]);
    const [showToast, setShowToast] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [toastType, setToastType] = useState('success');

    useEffect(() => {
        getAllModules()
            .then(setModules)
            .catch(() => handleToast('Klaida gaunant modulius.', 'danger'));

        getAllTeachers()
            .then((data) => {
                console.log("Fetched Teachers:", data); // Inspect response here
                setTeachers(data);
            })
            .catch(() => handleToast('Klaida gaunant dėstytojus.', 'danger'));

        getAllFaculties()
            .then(setFaculties)
            .catch(() => handleToast('Klaida gaunant fakultetus.', 'danger'));
    }, []);

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
        addLecture(formData)
            .then(() => handleToast('Paskaita pridėta sėkmingai!', 'success'))
            .catch(() => handleToast('Klaida pridedant paskaitą.', 'danger'));
    };

    // Generate duration options (15 to 360 minutes in 15-minute steps)
    const generateDurationOptions = () => {
        const durations = [];
        for (let i = 15; i <= 360; i += 15) {
            durations.push(i);
        }
        return durations;
    };

    return (
        <div className="max-w-md mx-auto mt-10 p-6 dark:bg-gray-800 rounded-lg shadow-md">
            <ToastNotification
                show={showToast}
                message={toastMessage}
                type={toastType}
                onClose={() => setShowToast(false)}
            />
            <h1 className="text-2xl font-bold mb-6 dark:text-white">Pridėti paskaitą</h1>
            <form onSubmit={handleSubmit}>
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

                {/* Module */}
                <div className="mb-4">
                    <label className="block text-gray-700 dark:text-white">Modulis</label>
                    <select
                        name="fkModulis"
                        value={formData.fkModulis}
                        onChange={handleInputChange}
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
                    className="w-full bg-green-500 text-white py-2 px-4 rounded-lg hover:bg-green-600"
                >
                    Pridėti paskaitą
                </button>
            </form>
        </div>
    );
}

