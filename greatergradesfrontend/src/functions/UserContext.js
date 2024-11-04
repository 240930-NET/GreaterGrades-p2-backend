import { createContext, useState, useEffect } from "react";
import { checkExpired, getStorageItem, setStorageItem } from "./LocalStorage";

export const UserContext = createContext();

export const UserProvider = ({children}) => {
    const [currentUser, setCurrentUser] = useState(getStorageItem('currentUser'));
    const [authToken, setAuthToken] = useState(getStorageItem('authToken'));

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
    };

    useEffect(() => {
        if (checkExpired('authToken')) {
            logout();
        }
    }, [authToken]);

    return (
        <UserContext.Provider value={{ currentUser, authToken, login, logout }}>
            {children}
        </UserContext.Provider>
    )
}