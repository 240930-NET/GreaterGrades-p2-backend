import './App.css';
import './styles/student.css';
import './styles/sidebar.css';
import './styles/header.css';
import './styles/profile.css';
import './styles/tiles.css'
import AppRoutes from './routes/AppRoutes';
import { useContext, useEffect } from 'react';
import { UserContext } from './functions/UserContext';
import { checkExpired } from './functions/LocalStorage';

function App() {

  const { authToken } = useContext(UserContext);

  return (
    <div>
      <AppRoutes />
    </div>
  )
}

export default App;