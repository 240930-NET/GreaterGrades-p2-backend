import { createContext, useState, useEffect } from "react";
import { checkExpired, getStorageItem, setStorageItem } from "./LocalStorage";
import { useNavigate } from "react-router-dom";

export const UserContext = createContext();

export const UserProvider = ({children}) => {
    const [currentUser, setCurrentUser] = useState(getStorageItem('currentUser'));
    const [authToken, setAuthToken] = useState(getStorageItem('authToken'));
    const navigate = useNavigate();

    const login = (token, user) => {
        setAuthToken(token);
        setCurrentUser(user);
        setStorageItem('authToken', token);
        setStorageItem('currentUser', user);
    };

    const logout = () => {
        setAuthToken(null);
        setCurrentUser(null);
        localStorage.removeItem('authToken');
        localStorage.removeItem('currentUser');
        navigate('/');
    };

    const checkToken = () => {
        if (getStorageItem('authToken') === null) {
            
        } else if(checkExpired('authToken')) {
            logout();
        }
    };

    useEffect(() => {
        const userActivity = () => {
            checkToken();
        }

        window.addEventListener('click', userActivity);

        return () => {
            window.removeEventListener('click', userActivity);
        }
    })

    

    return (
        <UserContext.Provider value={{ currentUser, setCurrentUser, authToken, login, logout }}>
            {children}
        </UserContext.Provider>
    )
}