import React, { createContext, useState, useContext, useEffect } from 'react';
import {jwtDecode} from 'jwt-decode';
import axios from 'axios';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  // Login function with API call
  const login = async (credentials) => {
    try {
      const response = await axios.post(
        'https://localhost:7049/api/Authenticator',
        {
          vidko: credentials.username,
          password: credentials.password,
        },
        {
          headers: {
            'Content-Type': 'application/json',
            Accept: '*/*',
          }
        }
      );

      const token = response.data; // Get token from response
      const decodedUser = jwtDecode(token); // Decode token to extract user info
      setUser(decodedUser); // Store user info in state
      localStorage.setItem('authToken', token); // Save token to localStorage
    } catch (error) {
      console.error('Login error:', error.response || error.message);
      throw new Error('Invalid credentials');
    }
  };

  // Logout function
  const logout = () => {
    setUser(null);
    localStorage.removeItem('authToken'); // Remove token from localStorage
  };

  // Load user from token on app load
  useEffect(() => {
    const token = localStorage.getItem('authToken');
    if (token) {
      try {
        const decodedUser = jwtDecode(token);
        setUser(decodedUser); // Set user state if the token is valid
      } catch (error) {
        console.error('Invalid token', error);
        logout(); // Clear invalid token
      }
    }
  }, []);

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook to use AuthContext
export const useAuth = () => useContext(AuthContext);
