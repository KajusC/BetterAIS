import React, { useState, useEffect } from 'react';
import { getLecturesByModule, deleteLecture } from '../../scripts/lectureAPI';
import { getAllModules } from '../../scripts/lectureAPI';
import ToastNotification from '../../components/ToastNotification';

export default function DeleteLecture() {
    const [modules, setModules] = useState([]);
    const [selectedModule, setSelectedModule] = useState('');
    const [lectures, setLectures] = useState([]);
    const [selectedLecture, setSelectedLecture] = useState('');
    const [showToast, setShowToast] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [toastType, setToastType] = useState('success');
    const [showConfirmation, setShowConfirmation] = useState(false);

    useEffect(() => {
        // Fetch all modules
        getAllModules()
            .then(setModules)
            .catch(() => handleToast('Klaida gaunant modulius.', 'danger'));
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

    const handleToast = (message, type) => {
        setToastMessage(message);
        setToastType(type);
        setShowToast(true);
    };

    const handleDelete = () => {
        // Show confirmation modal
        setShowConfirmation(true);
    };

    const confirmDelete = () => {
        // Perform the delete operation
        setShowConfirmation(false);
        deleteLecture(selectedLecture)
            .then(() => {
                handleToast('Paskaita sėkmingai ištrinta!', 'success');
                setLectures(lectures.filter((lecture) => lecture.id !== selectedLecture));
                setSelectedLecture('');
            })
            .catch(() => handleToast('Klaida ištrinant paskaitą.', 'danger'));
    };

    const cancelDelete = () => {
        setShowConfirmation(false);
    };

    return (
        <div className="max-w-md mx-auto mt-10 p-6 dark:bg-gray-800 rounded-lg shadow-md">
            <ToastNotification
                show={showToast}
                message={toastMessage}
                type={toastType}
                onClose={() => setShowToast(false)}
            />
            <h1 className="text-2xl font-bold mb-6 dark:text-white">Ištrinti Paskaitą</h1>

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
                                {lecture.pavadinimas} ({lecture.trukme} min)
                            </option>
                        ))}
                    </select>
                </div>
            )}

            {/* Delete Button */}
            {selectedLecture && (
                <div className="mt-4">
                    <button
                        onClick={handleDelete}
                        className="w-full bg-red-500 text-white py-2 px-4 rounded-lg hover:bg-red-600"
                    >
                        Ištrinti Paskaitą
                    </button>
                </div>
            )}

            {/* Confirmation Modal */}
            {showConfirmation && (
                <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-6 rounded-lg shadow-lg w-96">
                        <h2 className="text-xl font-bold mb-4">Ar tikrai norite ištrinti paskaitą?</h2>
                        <p className="text-gray-700 mb-6">
                            Paskaita bus ištrinta visam laikui. Ar norite tęsti?
                        </p>
                        <div className="flex space-x-4">
                            <button
                                onClick={confirmDelete}
                                className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600"
                            >
                                Taip, ištrinti
                            </button>
                            <button
                                onClick={cancelDelete}
                                className="bg-gray-300 text-black px-4 py-2 rounded-lg hover:bg-gray-400"
                            >
                                Atšaukti
                            </button>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
}
