import Dashboard from "../pages/Dashboard";
import TempLogin from "../pages/TempLogin";
import { Navigate, Route, Routes } from 'react-router-dom';
import { useContext } from "react";
import { UserContext } from "../functions/UserContext";

const AppRoutes = () => {
    const { authToken } = useContext(UserContext);

    return (
        <Routes>
            {!authToken ? (
                <Route path='/' element={<Navigate to='/login' replace />} />
            ) : (
                <Route path='/dashboard' element={<Dashboard />} />
            )}
            <Route path='/login' element={<TempLogin />} />
            <Route path='/dashboard' element={<Dashboard />} />
        </Routes >
    )
}

export default AppRoutes;