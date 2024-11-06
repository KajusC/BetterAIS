import React from 'react';

const TeacherProfile = () => {
  // Placeholder data
  const teacher = {
    id: "T001",
    name: "Dr. Emily Brown",
    birthDate: "1980-05-20",
    phoneNumber: "+987654321",
    email: "emily.brown@example.com",
    qualifications: "PhD in Physics",
    modules: [
      { code: "PHY101", title: "Physics 101" },
      { code: "PHY201", title: "Physics 201" },
    ],
  };

  return (
    <div className="p-6 bg-gray-50 min-h-screen dark:bg-gray-900 dark:text-white">
      <h1 className="text-3xl font-bold mb-4">Teacher Profile</h1>
      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-2xl font-semibold mb-2">Personal Information</h2>
        <p><strong>Name:</strong> {teacher.name}</p>
        <p><strong>Birth Date:</strong> {teacher.birthDate}</p>
        <p><strong>Phone Number:</strong> {teacher.phoneNumber}</p>
        <p><strong>Email:</strong> {teacher.email}</p>
        <p><strong>Qualifications:</strong> {teacher.qualifications}</p>
      </div>

      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-2xl font-semibold mb-2">Modules Taught</h2>
        <ul>
          {teacher.modules.map((module, index) => (
            <li key={index} className="border-b border-gray-200 py-2">
              <p><strong>Code:</strong> {module.code}</p>
              <p><strong>Title:</strong> {module.title}</p>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default TeacherProfile;
