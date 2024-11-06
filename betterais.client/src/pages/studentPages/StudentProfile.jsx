import React from 'react';

const StudentProfile = () => {
  // Placeholder data
  const student = {
    id: "S001",
    name: "Alice Johnson",
    birthDate: "2001-04-12",
    phoneNumber: "+123456789",
    email: "alice.johnson@example.com",
    studyStatus: "Active",
    studyProgram: "Computer Science",
    financialAidType: "Scholarship",
    grades: [
      { module: "Mathematics 101", grade: "A" },
      { module: "Physics 201", grade: "B+" },
      { module: "Chemistry 301", grade: "A-" },
    ],
  };

  return (
    <div className="p-6 bg-gray-50 min-h-screen dark:bg-gray-900 dark:text-white">
      <h1 className="text-3xl font-bold mb-4">Student Profile</h1>
      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6 ">
        <h2 className="text-2xl font-semibold mb-2">Personal Information</h2>
        <p><strong>Name:</strong> {student.name}</p>
        <p><strong>Birth Date:</strong> {student.birthDate}</p>
        <p><strong>Phone Number:</strong> {student.phoneNumber}</p>
        <p><strong>Email:</strong> {student.email}</p>
        <p><strong>Study Status:</strong> {student.studyStatus}</p>
        <p><strong>Financial Aid:</strong> {student.financialAidType}</p>
      </div>
      
      <div className="dark:bg-gray-800 shadow-md rounded-lg p-6 mb-6">
        <h2 className="text-2xl font-semibold mb-2">Academic Information</h2>
        <p><strong>Study Program:</strong> {student.studyProgram}</p>
        <h3 className="text-xl font-semibold mt-4">Recent Grades</h3>
        <ul>
          {student.grades.map((grade, index) => (
            <li key={index} className="border-b border-gray-200 py-2">
              <p><strong>Module:</strong> {grade.module}</p>
              <p><strong>Grade:</strong> {grade.grade}</p>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default StudentProfile;
