import React from 'react';
import { Link } from 'react-router-dom';
import { FiUser } from 'react-icons/fi';
import { STUDENT_STATUS } from '../../constants/constants';
import { getKeyByValue } from '../../scripts/getKeyByvalue';

const ProfileOverview = ({studentInfo}) => {

  const statusmap = getKeyByValue(STUDENT_STATUS, studentInfo.statusas);

  let studentProfile = `/StudentProfile/${studentInfo.vidko}`

  return (
    <div className="dark:bg-gray-800 shadow-lg rounded-lg p-6 transition-colors duration-300">
      <h2 className="text-xl font-semibold text-gray-700 dark:text-gray-300 mb-4 ">
        <FiUser className="inline-block text-indigo-500 dark:text-indigo-400 mr-2" />
        Profilis
      </h2>
      <p className="text-gray-600 dark:text-gray-100 mb-2"><strong>Vardas:</strong> {studentInfo.vardas} {studentInfo.pavarde} </p>
      <p className="text-gray-600 dark:text-gray-100 mb-2"><strong>Statusas:</strong> {statusmap}</p>
      <p className="text-gray-600 dark:text-gray-100"><strong>Programos kodas:</strong> {studentInfo.fkProgramosKodas}</p>
      <Link to={studentProfile} className="text-indigo-500 dark:text-indigo-400 mt-4 inline-block hover:underline">
        Peržiūrėti profiį detaliau
      </Link>
    </div>
  );
};

export default ProfileOverview;
