import './App.css';
import './styles/student.css';
import './styles/sidebar.css';
import './styles/header.css';
import './styles/profile.css';
import './styles/tiles.css'
import { BrowserRouter as Router } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';

function App() {

  return (
    <Router>
      <AppRoutes />
    </Router>
  )
}

export default App;