import React from "react";
import { Routes, Route } from "react-router-dom";
import ProtectedRoute from "../scripts/ProtectedRoute";
import Navbar from "../components/Navbar";

// Import context and pages
import MainWindow from "./Windows/MainWindow";
import LoginPage from "./LoginPage";
import DashboardPage from "./DashboardPage";

// Windows
import AdministratorWindow from "./Windows/AdministratorWindow";
import StudentWindow from "./Windows/StudentWindow";
import TeacherWindow from "./Windows/TeacherWindow";

// Grade Pages
import AddGrade from "./gradePages/AddGrade";
import ShowGrades from "./gradePages/ShowGrades";
import CalculateGrades from "./gradePages/CalculateGrades";
import ChangeGrade from "./gradePages/ChangeGrade";
import DeleteGrade from "./gradePages/DeleteGrade";
import ViewAllGrades from "./gradePages/ViewAllGrades";

// Lecture Pages
import AddLecture from "./lecturePages/AddLecture";
import AssignLectureToTimetable from "./lecturePages/AssignLectureToTimetable";
import DeleteLecture from "./lecturePages/DeleteLecture";
import DisplayFilteredTimetables from "./lecturePages/DisplayFilteredTimetables";
import ModifyLecture from "./lecturePages/ModifyLecture";
import TimetablePage from "./lecturePages/TimetablePage";

// Student Pages
import AddStudent from "./studentPages/AddStudent";
import DeleteStudent from "./studentPages/DeleteStudent";
import DisplayAllStudents from "./studentPages/DisplayAllStudents";
import DisplayStudentData from "./studentPages/DisplayStudentData";
import PrintToPdf from "./studentPages/PrintToPdf";
import StudentProfile from "./studentPages/StudentProfile";
import EditStudent from "./studentPages/EditStudent";

// Teacher Pages
import AddTeacher from "./teacherPages/AddTeacher";
import AssignTeacher from "./teacherPages/AssignTeacher";
import ChangeTeacherInfo from "./teacherPages/ChangeTeacherInfo";
import DeleteTeacher from "./teacherPages/DeleteTeacher";
import ShowAllTeachers from "./teacherPages/ShowAllTeachers";
import TeacherProfile from "./teacherPages/TeacherProfile";

import ErrorPage from "./ErrorPage";

const App = () => {
  return (
    <div className="min-h-screen bg-gray-50 flex flex-col dark:bg-gray-900 transition-colors duration-300">
      <Navbar />
      {/* Main Content */}
      <main className="flex-grow p-6">
        <Routes>
          {/* General Pages */}
          <Route path="/" element={<MainWindow />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/dashboard" element={<DashboardPage />} />

                  {/* Admin Privileges */}
                  <Route
                      path="/administrator"
                      element={
                          <ProtectedRoute minRole="Administratorius">
                              <AdministratorWindow />
                          </ProtectedRoute>
                      }
                  />
                  <Route
                      path="/teacher"
                      element={
                          <ProtectedRoute minRole="Dėstytojas">
                              <TeacherWindow />
                          </ProtectedRoute>
                      }
                  />
                  <Route
                      path="/student"
                      element={
                          <ProtectedRoute minRole="Studentas">
                              <StudentWindow />
                          </ProtectedRoute>
                      }
                  />
                  <Route
                      path="/dashboard"
                      element={
                          <ProtectedRoute>
                              <DashboardPage />
                          </ProtectedRoute>
                      }
                  />


          <Route
            path="/administrator"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AdministratorWindow />
              </ProtectedRoute>
            }
          />
          <Route
            path="/addLecture"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AddLecture />
              </ProtectedRoute>
            }
          />
          <Route
            path="/assignLectureToTimetable"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AssignLectureToTimetable />
              </ProtectedRoute>
            }
          />
          <Route
            path="/deleteLecture"
            element={
              <ProtectedRoute minRole="Administratorius">
                <DeleteLecture />
              </ProtectedRoute>
            }
          />
          <Route
            path="/add-teacher"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AddTeacher />
              </ProtectedRoute>
            }
          />
          <Route
            path="/assignTeacher"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AssignTeacher />
              </ProtectedRoute>
            }
          />
          <Route
            path="/edit-teacher/:vidko"
            element={
              <ProtectedRoute minRole="Administratorius">
                <ChangeTeacherInfo />
              </ProtectedRoute>
            }
          />
          <Route
            path="/delete-teacher"
            element={
              <ProtectedRoute minRole="Administratorius">
                <DeleteTeacher />
              </ProtectedRoute>
            }
          />
          <Route
            path="/showAllTeachers"
            element={
              <ProtectedRoute minRole="Administratorius">
                <ShowAllTeachers />
              </ProtectedRoute>
            }
          />
          <Route
            path="/addStudent"
            element={
              <ProtectedRoute minRole="Administratorius">
                <AddStudent />
              </ProtectedRoute>
            }
          />
          <Route
            path="/deleteStudent"
            element={
              <ProtectedRoute minRole="Administratorius">
                <DeleteStudent />
              </ProtectedRoute>
            }
          />
          <Route
            path="/modifyLecture"
            element={
              <ProtectedRoute minRole="Administratorius">
                <ModifyLecture />
              </ProtectedRoute>
            }
          />

          {/* Teacher Pages */}
          <Route
            path="/teacher-profile/:vidko"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <TeacherProfile />
              </ProtectedRoute>
            }
          />
          <Route
            path="/teacher"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <TeacherWindow />
              </ProtectedRoute>
            }
          />
          <Route
            path="/addGrade"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <AddGrade />
              </ProtectedRoute>
            }
          />
          <Route
            path="/calculateGrades"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <CalculateGrades />
              </ProtectedRoute>
            }
          />
          <Route
            path="/changeGrade"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <ChangeGrade />
              </ProtectedRoute>
            }
          />
          <Route
            path="/deleteGrade"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <DeleteGrade />
              </ProtectedRoute>
            }
          />
          <Route
            path="/displayAllStudents"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <DisplayAllStudents />
              </ProtectedRoute>
            }
          />
          <Route
            path="/displayStudentData"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <DisplayStudentData />
              </ProtectedRoute>
            }
          />
          <Route
            path="/printStudentPDF"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <PrintToPdf />
              </ProtectedRoute>
            }
                  />
                  <Route
                      path="/ChangeGrade/:id"
                      element={
                          <ProtectedRoute minRole="Dėstytojas">
                              <ChangeGrade />
                          </ProtectedRoute>
                      }
                  />

          <Route
            path="/viewAllGrades"
            element={
              <ProtectedRoute minRole="Dėstytojas">
                <ViewAllGrades />
              </ProtectedRoute>
            }
          />

          {/* Student Privileges */}
          <Route
            path="/student"
            element={
              <ProtectedRoute minRole="Studentas">
                <StudentWindow />
              </ProtectedRoute>
            }
          />
          <Route
            path="/StudentProfile/:vidko"
            element={
              <ProtectedRoute minRole="Studentas">
                <StudentProfile />
              </ProtectedRoute>
            }
          />
          <Route
            path="/showGrades/:studentId"
            element={
              <ProtectedRoute minRole="Studentas">
                <ShowGrades />
              </ProtectedRoute>
            }
          />
          <Route
            path="/displayFilteredTimetables"
            element={<DisplayFilteredTimetables />}
          />
          <Route path="/timetable" element={<TimetablePage />} />

          {/* Fallback */}
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
