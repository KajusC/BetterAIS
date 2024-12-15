import axios from 'axios';

export const useAuth = () => {
  const [user, setUser] = useState(null);
  const history = useHistory();

  const login = async (credentials) => {
    try {
      const response = await axios.post('https://localhost:7049/api/Authenticator', credentials, {
        headers: {
          'Content-Type': 'application/json',
          Accept: '*/*',
        },
      });

      const { token } = response.data; // Assume response contains a JWT token
      localStorage.setItem('authToken', token);

      const decodedUser = jwtDecode(token); // Parse token
      setUser(decodedUser);

      history.push('/dashboard');
    } catch (error) {
      console.error('Login error:', error.response || error.message);
      alert('Invalid credentials');
    }
  };

  const logout = () => {
    localStorage.removeItem('authToken');
    setUser(null);
    history.push('/login');
  };

  return { user, login, logout };
};
