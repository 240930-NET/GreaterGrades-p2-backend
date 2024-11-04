import './App.css';
import './styles/student.css';
import { BrowserRouter as Router } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';
import { useLogin, useGetUserById } from './greatergradesapi/Auth';
import { checkExpired, setStorageItem } from './functions/functions';
import { useEffect } from 'react';

function App() {
  
  const token = useLogin('admin', 'admin');
  const user = useGetUserById(2);

  useEffect(() => {
    if (token) setStorageItem('authToken', token);

    if (user) setStorageItem('currentUser', user);
  }, [token, user])

  if (checkExpired('authToken') || checkExpired('currentUser')){
    return (
      <div>loading...</div>
    )
  }

  return (
    <Router>
      <AppRoutes />
    </Router>
  )
}

export default App;