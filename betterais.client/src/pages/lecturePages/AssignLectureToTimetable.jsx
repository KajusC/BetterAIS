import React, { useState, useEffect } from 'react';
import { getLecturesByModule, getAllModules, assignLectureToTimetable } from '../../scripts/lectureAPI';
import ToastNotification from '../../components/ToastNotification';

export default function AssignLectureToTimetable() {
    const [modules, setModules] = useState([]);
    const [selectedModule, setSelectedModule] = useState('');
    const [lectures, setLectures] = useState([]);
    const [formData, setFormData] = useState({
        selectedLecture: '',
        day: '',
        startTime: '',
    });

    const [showToast, setShowToast] = useState(false);
    const [toastMessage, setToastMessage] = useState('');
    const [toastType, setToastType] = useState('success');

    // Days of the week
    const days = ['Pirmadienis', 'Antradienis', 'Trečiadienis', 'Ketvirtadienis', 'Penktadienis'];

    // Time slots in 15-minute intervals (08:00 to 18:00)
    const generateTimeSlots = () => {
        const timeSlots = [];
        for (let hour = 8; hour <= 18; hour++) {
            for (let minute of ['00', '15', '30', '45']) {
                timeSlots.push(`${hour.toString().padStart(2, '0')}:${minute}`);
            }
        }
        return timeSlots;
    };

    const timeSlots = generateTimeSlots();

    // Fetch modules on load
    useEffect(() => {
        getAllModules()
            .then(setModules)
            .catch(() => handleToast('Klaida gaunant modulius.', 'danger'));
    }, []);

    // Fetch lectures when a module is selected
    useEffect(() => {
        if (selectedModule) {
            getLecturesByModule(selectedModule)
                .then(setLectures)
                .catch(() => handleToast('Klaida gaunant paskaitas.', 'danger'));
        } else {
            setLectures([]);
            setFormData({ ...formData, selectedLecture: '' });
        }
    }, [selectedModule]);

    const handleToast = (message, type) => {
        setToastMessage(message);
        setToastType(type);
        setShowToast(true);
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const payload = {
            module: selectedModule,
            lectureId: formData.selectedLecture,
            day: formData.day,
            startTime: formData.startTime,
        };

        assignLectureToTimetable(payload)
            .then(() => handleToast('Paskaita sėkmingai priskirta tvarkaraščiui!', 'success'))
            .catch(() => handleToast('Klaida priskiriant paskaitą tvarkaraščiui.', 'danger'));
    };

    return (
        <div className="max-w-md mx-auto mt-10 p-6 dark:bg-gray-800 rounded-lg shadow-md">
            <ToastNotification
                show={showToast}
                message={toastMessage}
                type={toastType}
                onClose={() => setShowToast(false)}
            />
            <h1 className="text-2xl font-bold mb-6 dark:text-white">Priskirti paskaitą tvarkaraščiui</h1>
            <form onSubmit={handleSubmit}>
                {/* Select Module */}
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

                {/* Select Lecture */}
                <div className="mb-4">
                    <label className="block text-gray-700 dark:text-white">Paskaita</label>
                    <select
                        name="selectedLecture"
                        value={formData.selectedLecture}
                        onChange={handleInputChange}
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

                {/* Select Day */}
                <div className="mb-4">
                    <label className="block text-gray-700 dark:text-white">Diena</label>
                    <select
                        name="day"
                        value={formData.day}
                        onChange={handleInputChange}
                        className="w-full px-3 py-2 border rounded-lg"
                        required
                    >
                        <option value="">Pasirinkite dieną</option>
                        {days.map((day, index) => (
                            <option key={index} value={day}>
                                {day}
                            </option>
                        ))}
                    </select>
                </div>

                {/* Select Start Time */}
                <div className="mb-4">
                    <label className="block text-gray-700 dark:text-white">Pradžios Laikas</label>
                    <select
                        name="startTime"
                        value={formData.startTime}
                        onChange={handleInputChange}
                        className="w-full px-3 py-2 border rounded-lg"
                        required
                    >
                        <option value="">Pasirinkite pradžios laiką</option>
                        {timeSlots.map((time, index) => (
                            <option key={index} value={time}>
                                {time}
                            </option>
                        ))}
                    </select>
                </div>

                <button
                    type="submit"
                    className="w-full bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600"
                >
                    Priskirti paskaitą
                </button>
            </form>
        </div>
    );
}
