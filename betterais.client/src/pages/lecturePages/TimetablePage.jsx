import React, { useState } from 'react';
import Timetable from '../../components/Timetable';

const TimetablePage = () => {
    // Pavyzdiniai tvarkaraščio duomenys
    const schedule = [
        {
            time: '08:00 - 09:00',
            monday: { name: 'Matematika 101', details: 'Dėstytojas: Jonas Petraitis, Kabinetas: 101' },
            tuesday: { name: 'Fizika 201', details: 'Dėstytojas: Ieva Kazlauskaitė, Kabinetas: 202' },
            wednesday: { name: 'Chemija 301', details: 'Dėstytojas: Petras Jonaitis, Kabinetas: 303' },
            thursday: { name: 'Biologija 101', details: 'Dėstytojas: Ona Petraitienė, Kabinetas: 104' },
            friday: { name: 'Istorija 201', details: 'Dėstytojas: Tomas Jonauskas, Kabinetas: 105' },
        },
        {
            time: '09:00 - 10:00',
            monday: { name: 'Anglų kalba 101', details: 'Dėstytojas: Laura Kazlauskienė, Kabinetas: 106' },
            tuesday: { name: 'Matematika 101', details: 'Dėstytojas: Jonas Petraitis, Kabinetas: 101' },
            wednesday: { name: 'Fizika 201', details: 'Dėstytojas: Ieva Kazlauskaitė, Kabinetas: 202' },
            thursday: { name: 'Chemija 301', details: 'Dėstytojas: Petras Jonaitis, Kabinetas: 303' },
            friday: { name: 'Biologija 101', details: 'Dėstytojas: Ona Petraitienė, Kabinetas: 104' },
        },
        // Pridėkite daugiau laikotarpių pagal poreikį
    ];

    const [selectedLecture, setSelectedLecture] = useState(null);

    const handleLectureClick = (lecture) => {
        setSelectedLecture(lecture);
    };

    const closePopup = () => {
        setSelectedLecture(null);
    };

    return (
        <div className="p-6">
            <h1 className="text-3xl mb-4 dark:text-white">Tvarkaraštis</h1>

            <table className="min-w-full border-collapse border border-gray-300">
                <thead>
                    <tr>
                        <th className="border border-gray-300 px-4 py-2">Laikas</th>
                        <th className="border border-gray-300 px-4 py-2">Pirmadienis</th>
                        <th className="border border-gray-300 px-4 py-2">Antradienis</th>
                        <th className="border border-gray-300 px-4 py-2">Trečiadienis</th>
                        <th className="border border-gray-300 px-4 py-2">Ketvirtadienis</th>
                        <th className="border border-gray-300 px-4 py-2">Penktadienis</th>
                    </tr>
                </thead>
                <tbody>
                    {schedule.map((slot, index) => (
                        <tr key={index}>
                            <td className="border border-gray-300 px-4 py-2">{slot.time}</td>
                            {['monday', 'tuesday', 'wednesday', 'thursday', 'friday'].map((day) => (
                                <td key={day} className="border border-gray-300 px-4 py-2">
                                    {slot[day] ? (
                                        <button
                                            onClick={() => handleLectureClick(slot[day])}
                                            className="text-blue-500 underline hover:text-blue-700"
                                        >
                                            {slot[day].name}
                                        </button>
                                    ) : (
                                        '-'
                                    )}
                                </td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Popup Modal */}
            {selectedLecture && (
                <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-6 rounded shadow-lg w-96">
                        <h2 className="text-xl font-bold mb-4">{selectedLecture.name}</h2>
                        <p className="text-gray-700">{selectedLecture.details}</p>
                        <button
                            onClick={closePopup}
                            className="mt-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                        >
                            Uždaryti
                        </button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default TimetablePage;
