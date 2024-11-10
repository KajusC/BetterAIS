import React, { useState, useEffect } from "react";
import { Routes, Route, Link } from "react-router-dom";
import MainWindow from "./Windows/MainWindow";
import LoginPage from "./LoginPage";
import Register from "./Register";
import DashboardPage from "./DashboardPage";

import AdministratorWindow from "./Windows/AdministratorWindow";
import StudentWindow from "./Windows/StudentWindow";
import TeacherWindow from "./Windows/TeacherWindow";

// Grade Pages
import AddGrade from "./gradePages/AddGrade"; 
import ShowGrades from "./gradePages/ShowGrades";
import CalculateGrades from "./gradePages/CalculateGrades";
import CalculateWeightedGrade from "./gradePages/CalculateWeightedGrade";
import ChangeGrade from "./gradePages/ChangeGrade";
import DeleteGrade from "./gradePages/DeleteGrade";
import ViewAllGrades from "./gradePages/ViewAllGrades";

// lecture pages
import AddLecture from "./lecturePages/AddLecture"; 
import AddLectureToTimetable from "./lecturePages/AddLectureToTimetable";
import EditLecture from "./lecturePages/EditLecture";
import DeleteLecture from "./lecturePages/DeleteLecture";
import DisplayLecture from "./lecturePages/DisplayLecture"; 
import DisplayFilteredTimetables from "./lecturePages/DisplayFilteredTimetables";
import DisplayFilteredLectures from "./lecturePages/DisplayFilteredLectures";
import ModifyLecture from "./lecturePages/ModifyLecture";
import TimetablePage from "./lecturePages/TimetablePage";

// student pages
import AddStudent from "./studentPages/AddStudent"; 
import DeleteStudent from "./studentPages/DeleteStudent";
import GetStudentData from "./studentPages/GetStudentData";
import DisplayAllStudents from "./studentPages/DisplayAllStudents";
import DisplayStudentData from "./studentPages/DisplayStudentData";
import PrintToPdf from "./studentPages/PrintToPdf";
import StudentProfile from "./studentPages/StudentProfile";

// teacher pages
import AddTeacher from "./teacherPages/AddTeacher";
import AssignTeacher from "./teacherPages/AssignTeacher";
import EditTeacherInfo from "./teacherPages/EditTeacherInfo";
import DeleteTeacher from "./teacherPages/DeleteTeacher";
import DisplayAllTeachers from "./teacherPages/DisplayAllTeachers";
import TeacherProfile from "./teacherPages/TeacherProfile";
import TeachersByFilter from "./teacherPages/TeachersByFilter";

import ErrorPage from "./ErrorPage";

import Navbar from "../components/Navbar";

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
                    <Route path="/calculateWeightedGrade" element={<CalculateWeightedGrade />} />
                    <Route path="/changeGrade" element={<ChangeGrade />} />
                    <Route path="/deleteGrade" element={<DeleteGrade />} />
                    <Route path="/viewAllGrades" element={<ViewAllGrades />} />

                    <Route path="/addLecture" element={<AddLecture />} />
                    <Route path="/addLectureToTimetable" element={<AddLectureToTimetable />} />
                    <Route path="/editLecture" element={<EditLecture />} />
                    <Route path="/deleteLecture" element={<DeleteLecture />} />
                    <Route path="/displayLecture" element={<DisplayLecture />} />DisplayFilteredLectures
                    <Route path="/displayFilteredTimetables" element={<DisplayFilteredTimetables />} />
                    <Route path="/displayFilteredLectures" element={<DisplayFilteredLectures />} />
                    <Route path="/modifyLecture" element={<ModifyLecture />} />

                    <Route path="/addStudent" element={<AddStudent />} />
                    <Route path="/deleteStudent" element={<DeleteStudent />} />
                    <Route path="/getStudentData" element={<GetStudentData />} />
                    <Route path="/displayAllStudents" element={<DisplayAllStudents />} />
                    <Route path="/displayStudentData" element={<DisplayStudentData />} />
                    <Route path="/printToPdf" element={<PrintToPdf />} />
                    <Route path="/studentProfile" element={<StudentProfile />} />

                    <Route path="/addTeacher" element={<AddTeacher />} />
                    <Route path="/assignTeacher" element={<AssignTeacher />} />
                    <Route path="/editTeacherInfo" element={<EditTeacherInfo />} />
                    <Route path="/deleteTeacher" element={<DeleteTeacher />} />
                    <Route path="/displayAllTeachers" element={<DisplayAllTeachers />} />
                    <Route path="/teacherProfile" element={<TeacherProfile />} />
                    <Route path="/teachersByFilter" element={<TeachersByFilter />} />

                    <Route path="*" element={<ErrorPage />} />
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
