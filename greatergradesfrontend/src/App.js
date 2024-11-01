import './App.css';
import './styles/student.css';
import { useEffect, useState } from 'react';
import Dashboard from './pages/Dashboard';

function App() {

  //// Fetch admin login and set authentication token
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

    ///// Fetch admin by id (2) and set role
    const [user, setUser] = useState();
    useEffect(() => {
        const fetchUser = async () => {
          try{
          const response = await fetch('http://localhost:5000/api/Auth/2', {
            headers: {
              'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
              'Content-Type': 'application/json'
            }
          })
          const data = await response.json();
          setUser(data);
          } catch{
          }
        }
      fetchUser();
    }, []);

    useEffect(() => {
      if (user) {
        localStorage.setItem('currentUser', JSON.stringify(user));
      }
    }, [user]);




  return (
    <Dashboard />
  )
}

export default App;
