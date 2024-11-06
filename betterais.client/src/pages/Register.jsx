import React from "react";

export default function Register() {
  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-gray-900 transition-colors duration-300">
      <form className=" dark:bg-gray-800 p-6 rounded shadow-md w-full max-w-sm transition-colors duration-300">
        <h2 className="text-2xl mb-4 text-gray-800 dark:text-gray-200">
          <i class="fa fa-registered" aria-hidden="true"></i>
        </h2>

        <input
          type="text"
          placeholder="Name"
          className="w-full mb-2 p-2 border border-gray-300 dark:border-gray-700 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />
        <input
          type="text"
          placeholder="Surname"
          className="w-full mb-2 p-2 border border-gray-300 dark:border-gray-700 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />
        <input
          type="text"
          placeholder="Email"
          className="w-full mb-2 p-2 border border-gray-300 dark:border-gray-700 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />

        <input
          type="password"
          placeholder="Password"
          className="w-full mb-4 p-2 border border-gray-300 dark:border-gray-900 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />

        <button className="w-full bg-blue-500 dark:bg-blue-800 hover:bg-blue-600 dark:hover:bg-blue-700 text-white p-2 rounded transition-colors duration-300">
          Register
        </button>

        <p className="text-center mt-4 text-gray-800 dark:text-gray-200">
            Already have an account?{" "}
            <a href="/login" className="text-blue-500">
                Login
            </a>
        </p>

      </form>
    </div>
  );
}
