import React from 'react';
import StudentCard from '../components/studentComponents/StudentCard';
import TeacherCard from '../components/TeacherComponents/TeacherCard';
import AdministratorCard from '../components/administratorComponents/AdministratorCard';

const DashboardPage = () => {
  // Placeholder data
  const students = [
    { id: 'S001', name: 'Alice Johnson', major: 'Computer Science' },
    { id: 'S002', name: 'Bob Smith', major: 'Mathematics' },
    // Add more students as needed
  ];

  const teachers = [
    { id: 'T001', name: 'Dr. Emily Brown', department: 'Physics' },
    { id: 'T002', name: 'Prof. John Davis', department: 'History' },
    // Add more teachers as needed
  ];

  const administrators = [
    { id: 'A001', name: 'Dean Charles', position: 'Dean of Science' },
    { id: 'A002', name: 'Rector Williams', position: 'University Rector' },
    // Add more administrators as needed
  ];

  return (
    <div className="p-6 dark:text-white transition-colors duration-300">
      <h1 className="text-3xl mb-4">Dashboard</h1>

      <section>
        <h2 className="text-2xl mb-2 ">Students</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 ">
          {students.map((student) => (
            <StudentCard key={student.id} student={student} />
          ))}
        </div>
      </section>

      <section>
        <h2 className="text-2xl mb-2 mt-6">Teachers</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {teachers.map((teacher) => (
            <TeacherCard key={teacher.id} teacher={teacher} />
          ))}
        </div>
      </section>

      <section>
        <h2 className="text-2xl mb-2 mt-6">Administrators</h2>
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {administrators.map((admin) => (
            <AdministratorCard key={admin.id} admin={admin} />
          ))}
        </div>
      </section>
    </div>
  );
};

export default DashboardPage;
