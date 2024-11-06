import React, {useState, useEffect} from "react";
import { Link } from "react-router-dom";
import { FiHome, FiUser, FiCalendar, FiLogIn } from "react-icons/fi";

export default function Navbar() {

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
    <>
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
            to="/Student"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiHome className="mr-1" /> Student home
          </Link>
          <Link
            to="/administrator"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiHome className="mr-1" /> Administrator home
          </Link>
          <Link
            to="/teacher"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiHome className="mr-1" /> Teacher home
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
          <Link
            to="/Register"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiLogIn className="mr-1" /> Register
          </Link>
          <div className="">
            <button
              onClick={toggleDarkMode}
              className="top-4 right-4 p-2 bg-gray-200 dark:bg-gray-700 rounded-full text-gray-800 dark:text-gray-100 transition"
            >
              {isDarkMode ? "Light Mode" : "Dark Mode"}
            </button>
          </div>
        </nav>
      </header>
    </>
  );
}
