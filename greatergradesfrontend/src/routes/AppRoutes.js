import Dashboard from "../pages/Dashboard";
import TempLogin from "../pages/TempLogin";
import Course from "../pages/Course"
import { Navigate, Route, Routes } from 'react-router-dom';
import { useContext } from "react";
import { UserContext } from "../functions/UserContext";

const AppRoutes = () => {
    const { authToken } = useContext(UserContext);

    return (
        <Routes>
            <Route path='/' element={!authToken ? <Navigate to='/login' /> : <Navigate to ='/dashboard' />} />
            <Route path='/login' element={<TempLogin />} />
            <Route path='/dashboard' element={!authToken ? <Navigate to='/login' /> : <Dashboard />} />
            <Route path='/course' element={!authToken ? <Navigate to='/login' /> : <Course />} />
        </Routes >
    )
}

export default AppRoutes;