import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FiHome, FiUser, FiCalendar, FiLogIn } from "react-icons/fi";
import { useAuth } from "../contexts/AuthContext";

export default function Navbar() {
  const [isDarkMode, setIsDarkMode] = useState(false);
  const { user, logout } = useAuth(); // Access user and logout function from AuthContext

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

  const renderLinks = () => {
    if (!user) {
      // Links for unauthenticated users
      return (
        <div className="flex flex-col space-x-6 md:flex-row md:space-x-6">
          <Link
            to="/login"
            className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
          >
            <FiLogIn className="mr-1" /> Prisijungti
          </Link>
        </div>
      );
    }

    // Links for authenticated users
    const links = [];
    if (user.role === "Studentas") {
      links.push(
        <Link
          to="/student"
          key="student"
          className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
        >
          <FiUser className="mr-1" /> Studentas
        </Link>
      );
      links.push(
        <Link
          to="/timetable"
          key="timetable"
          className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
        >
          <FiCalendar className="mr-1" /> Tvarkaraščiai
        </Link>
      );
    }

    if (user.role === "Dėstytojas") {
      links.push(
        <Link
          to="/teacher"
          key="teacher"
          className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
        >
          <FiHome className="mr-1" /> Dėstytojas
        </Link>
      );
    }

    if (user.role === "Administratorius") {
      links.push(
        <Link
          to="/administrator"
          key="admin"
          className="flex items-center text-gray-600 hover:text-blue-500 dark:text-white"
        >
          <FiHome className="mr-1" /> Administratorius
        </Link>
      );
    }

    links.push(
      <button
        key="logout"
        onClick={logout}
        className="flex items-center text-gray-600 hover:text-red-500 dark:text-white"
      >
        <FiLogIn className="mr-1" /> Atsijungti
      </button>
    );

    return links;
  };

  return (
    <>
      {/* Navbar */}
      <header
        className={`shadow-md p-4 sticky top-0 z-50 flex items-center transition-colors duration-300 ${
          isDarkMode ? "bg-gray-800" : "bg-white"
        }`}
      >
        <h1 className="text-2xl font-semibold text-gray-700 dark:text-white">
          Akademinė informacinė sistema
        </h1>
        <div className="ml-auto flex items-center space-x-6">{renderLinks()}</div>
        <button
          onClick={toggleDarkMode}
          className="ml-6 p-2 bg-gray-200 dark:bg-gray-700 rounded-full text-gray-800 dark:text-gray-100 transition"
        >
          {isDarkMode ? "Šviesus rėžimas" : "Tamsus rėžimas"}
        </button>
      </header>
    </>
  );
}
