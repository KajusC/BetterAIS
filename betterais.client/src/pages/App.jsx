import React, { useState, useEffect } from 'react';
import { Routes, Route, Link } from "react-router-dom";
import MainWindow from "./MainWindow";
import LoginPage from "./LoginPage";
import DashboardPage from "./DashboardPage";
import TimetablePage from "./TimetablePage";
import {
  FiHome,
  FiUser,
  FiCalendar,
  FiLogIn,
  FiCheckCircle,
} from "react-icons/fi";

const App = () => {
  const [isDarkMode, setIsDarkMode] = useState(false);

  useEffect(() => {
    // Load initial dark mode state from local storage
    const darkModePreference = localStorage.getItem("darkMode") === "true";
    setIsDarkMode(darkModePreference);
    if (darkModePreference) {
      document.documentElement.classList.add("dark");
    } else {
      document.documentElement.classList.remove("dark");
    }
  }, []);

  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
    localStorage.setItem("darkMode", !isDarkMode);
    document.documentElement.classList.toggle("dark");
  };

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col dark:bg-gray-900  transition-colors duration-300">
      {/* Navbar */}
      <header
  className={`shadow-md p-4 sticky top-0 z-50 flex justify-between items-center transition-colors duration-300 ${
    isDarkMode ? "bg-gray-800" : "bg-white"
  }`}
>
        <h1 className="text-2xl font-semibold text-gray-700 dark:text-white">
          Academic Info System
        </h1>
        <nav className="flex space-x-6 ">
          <Link
            to="/"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiHome className="mr-1" /> Home
          </Link>
          <Link
            to="/dashboard"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiUser className="mr-1" /> Dashboard
          </Link>
          <Link
            to="/timetable"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiCalendar className="mr-1" /> Timetable
          </Link>
          <Link
            to="/login"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiLogIn className="mr-1" /> Login
          </Link>
          <div className=''>
          <button
            onClick={toggleDarkMode}
            className="top-4 right-4 p-2 bg-gray-200 dark:bg-gray-700 rounded-full text-gray-800 dark:text-gray-100 transition"
          >
            {isDarkMode ? "Light Mode" : "Dark Mode"}
          </button>
        </div>
        </nav>

        
      </header>

      {/* Main Content */}
      <main className="flex-grow p-6">
        <Routes>
          <Route path="/" element={<MainWindow />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/dashboard" element={<DashboardPage />} />
          <Route path="/timetable" element={<TimetablePage />} />
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
