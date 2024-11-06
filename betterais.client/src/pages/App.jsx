import React, { useState, useEffect } from 'react';
import { Routes, Route, Link } from "react-router-dom";
import MainWindow from "./Windows/MainWindow";
import LoginPage from "./LoginPage";
import Register from "./Register";
import DashboardPage from "./DashboardPage";

import AdministratorWindow from './Windows/AdministratorWindow';
import StudentWindow from './Windows/StudentWindow';
import TeacherWindow from './Windows/TeacherWindow';

// Grade Pages
import AddGrade from './gradePages/AddGrade';
import ShowGrades from './gradePages/ShowGrades';
import CalculateGrades from './gradePages/CalculateGrades';
import ChangeGrade from './gradePages/ChangeGrade';
import DeleteGrade from './gradePages/DeleteGrade';

// lecture pages
import AddLecture from './lecturePages/AddLecture';
import AssignLectureToTimetable from './lecturePages/AssignLectureToTimetable';
import DeleteLecture from './lecturePages/DeleteLecture';
import DisplayFilteredTimetables from './lecturePages/DisplayFilteredTimetables';
import ModifyLecture from './lecturePages/ModifyLecture';
import TimetablePage from "./lecturePages/TimetablePage";

// student pages
import AddStudent from './studentPages/AddStudent';
import DeleteStudent from './studentPages/DeleteStudent';
import DisplayAllStudents from './studentPages/DisplayAllStudents';
import DisplayStudentData from './studentPages/DisplayStudentData';
import PrintToPdf from './studentPages/PrintToPdf';
import StudentProfile from "./studentPages/StudentProfile";

// teacher pages
import AddTeacher from './teacherPages/AddTeacher';
import AssignTeacher from './teacherPages/AssignTeacher';
import ChangeTeacherInfo from './teacherPages/ChangeTeacherInfo';
import DeleteTeacher from './teacherPages/DeleteTeacher';
import ShowAllTeachers from './teacherPages/ShowAllTeachers';
import TeacherProfile from './teacherPages/TeacherProfile';


import Navbar from '../components/Navbar';

const App = () => {
  return (
    <div className="min-h-screen bg-gray-50 flex flex-col dark:bg-gray-900  transition-colors duration-300">
      <Navbar />
      {/* Main Content */}
      <main className="flex-grow p-6">
        <Routes>
          <Route path="/" element={<MainWindow />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<Register />} />
          <Route path="/dashboard" element={<DashboardPage />} />
          <Route path="/timetable" element={<TimetablePage />} />

          <Route path="/administrator" element={<AdministratorWindow />} />
          <Route path="/student" element={<StudentWindow />} />
          <Route path="/teacher" element={<TeacherWindow />} />

          <Route path="/addGrade" element={<AddGrade />} />
          <Route path="/showGrades" element={<ShowGrades />} />
          <Route path="/calculateGrades" element={<CalculateGrades />} />
          <Route path="/changeGrade" element={<ChangeGrade />} />
          <Route path="/deleteGrade" element={<DeleteGrade />} />

          <Route path="/addLecture" element={<AddLecture />} />
          <Route path="/assignLectureToTimetable" element={<AssignLectureToTimetable />} />
          <Route path="/deleteLecture" element={<DeleteLecture />} />
          <Route path="/displayFilteredTimetables" element={<DisplayFilteredTimetables />} />
          <Route path="/modifyLecture" element={<ModifyLecture />} />

          <Route path="/addStudent" element={<AddStudent />} />
          <Route path="/deleteStudent" element={<DeleteStudent />} />
          <Route path="/displayAllStudents" element={<DisplayAllStudents />} />
          <Route path="/displayStudentData" element={<DisplayStudentData />} />
          <Route path="/printToPdf" element={<PrintToPdf />} />
          <Route path="/StudentProfile" element={<StudentProfile />} />

          <Route path="/addTeacher" element={<AddTeacher />} />
          <Route path="/assignTeacher" element={<AssignTeacher />} />
          <Route path="/changeTeacherInfo" element={<ChangeTeacherInfo />} />
          <Route path="/deleteTeacher" element={<DeleteTeacher />} />
          <Route path="/showAllTeachers" element={<ShowAllTeachers />} />
          <Route path="/TeacherProfile" element={<TeacherProfile />} />

        </Routes>
      </main>

      {/* Footer */}
      <footer className="bg-gray-800 text-white p-4 text-center">
        <p>
          &copy; {new Date().getFullYear()} Better AIS | Kajus Černiauskas |
          Smiltė Linkauskaitė | Matas Motiejūnas | Ignas Vanagas{" "}
        </p>
      </footer>
    </div>
  );
};

export default App;
