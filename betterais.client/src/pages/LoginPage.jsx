import React, { useState } from 'react';
import { useAuth } from '../contexts/AuthContext';
import { useNavigate } from 'react-router-dom';

const LoginPage = () => {
  const [credentials, setCredentials] = useState({ username: '', password: '' });
  const [error, setError] = useState(null);
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCredentials((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await login(credentials); // Call login function
      navigate('/dashboard'); // Redirect on successful login
    } catch (err) {
      setError('Login failed. Please check your credentials.');
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100 dark:bg-gray-900 transition-colors duration-300">
      <form
        onSubmit={handleSubmit}
        className="dark:bg-gray-800 p-6 rounded shadow-md w-full max-w-sm transition-colors duration-300"
      >
        <h2 className="text-2xl mb-4 text-gray-800 dark:text-gray-200">Prisijungti</h2>

        {error && <p className="text-red-500 mb-4">{error}</p>}

        <input
          type="text"
          name="username"
          placeholder="Vartotojo vardas"
          value={credentials.username}
          onChange={handleChange}
          className="w-full mb-2 p-2 border border-gray-300 dark:border-gray-700 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />

        <input
          type="password"
          name="password"
          placeholder="Slaptazodis"
          value={credentials.password}
          onChange={handleChange}
          className="w-full mb-4 p-2 border border-gray-300 dark:border-gray-900 rounded dark:bg-gray-700 dark:text-gray-200 transition-colors duration-300"
        />

        <button
          type="submit"
          className="w-full bg-blue-500 dark:bg-blue-800 hover:bg-blue-600 dark:hover:bg-blue-700 text-white p-2 rounded transition-colors duration-300"
        >
          Prisijungti
        </button>

        <p className="text-center mt-4 text-gray-800 dark:text-gray-200">
          Neturite paskyros?{" "}
          <a href="/register" className="text-blue-500">
            Registruotis
          </a>
        </p>
      </form>
    </div>
  );
};

export default LoginPage;
