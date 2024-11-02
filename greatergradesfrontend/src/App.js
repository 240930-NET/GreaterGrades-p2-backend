import './App.css';
import './styles/student.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Dashboard from './pages/Dashboard';

function App() {

  const [token, setToken] = useState(localStorage.getItem('authToken') || "");
  const [user, setUser] = useState(JSON.parse(localStorage.getItem('currentUser')) || null);
  const [loading, setLoading] = useState(true);


  useEffect(() => {
      const fetchTokenAndUser = async () => {
        try {
          if (!token){
            const tokenResponse = await fetch('http://localhost:5000/api/Auth/login', {
              method: 'POST',
              headers: {'Content-Type': 'application/json'},
              body: JSON.stringify({
                  username: "admin",
                  password: "admin"
              })
            });
            const tokenData = await tokenResponse.json();
            setToken(tokenData);
            localStorage.setItem('authToken', tokenData?.token)
          }

          const userResponse = await fetch('http://localhost:5000/api/Auth/2', {
            headers: {
              'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
              'Content-Type': 'application/json'
            }
          });
          const userData = await userResponse.json();
          setUser(userData);
          localStorage.setItem('currentUser', JSON.stringify(userData));
          
        } catch {

        } finally {
          setLoading(false);
        }
      };
      fetchTokenAndUser();
  }, [token]);

  if (loading) {
    return <div>loading....</div>
  }
    

  return (
    <Router>
      <Routes>
        {/* <Route path="/" element={<Login />} /> */}
        <Route path="/" element={user ? <Dashboard /> : <div>loading...</div>} />
      </Routes>
    </Router>
  )
}

export default App;
