import { useState } from 'react';
import { useHistory } from 'react-router-dom';

export const useAuth = () => {
  const [user, setUser] = useState(null);
  const history = useHistory();

  const login = (credentials) => {
    // Implement authentication logic here
    // For example, send credentials to API and receive a token
    setUser({ name: credentials.username });
    history.push('/dashboard');
  };

  const logout = () => {
    setUser(null);
    history.push('/login');
  };

  return { user, login, logout };
};
