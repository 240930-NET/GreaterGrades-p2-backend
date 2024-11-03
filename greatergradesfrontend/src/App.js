import './App.css';
import './styles/student.css';
import { BrowserRouter as Router } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';
import { useLogin, useGetUserById } from './greatergradesapi/Auth';

function App() {
  useLogin('admin', 'admin');
  useGetUserById(2);

  return (
    <Router>
      <AppRoutes />
    </Router>
  )
}

export default App;