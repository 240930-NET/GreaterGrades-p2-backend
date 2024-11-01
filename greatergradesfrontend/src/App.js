import './App.css';
import './styles/student.css';
import { useEffect, useState } from 'react';
import Dashboard from './pages/Dashboard';

function App() {

  const [token, setToken] = useState();
    useEffect(() => {
        const fetchToken = async () => {
            const response = await fetch('http://localhost:5000/api/Auth/login', {
                method: 'POST',
                headers: {'Content-Type': 'application/json'},
                body: JSON.stringify({
                    username: "admin",
                    password: "admin"
                })
            });
            const data = await response.json();
            setToken(data);
        }
        fetchToken();
    }, []);
    

    useEffect(() => {
      if (token) {
        localStorage.setItem('authToken', token?.token);
      }
    }, [token]);

  return (
    <Dashboard />
  )
}

export default App;
