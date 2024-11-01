import { useEffect, useState } from "react";

const Header = () => {
    const [user, setUser] = useState();
    const url = 'http://localhost:5000/api/Auth/1';

    useEffect(() => {
        const fetchUser = async () => {
            const response = await fetch(url, {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem("authToken")}`,
                    'Content-Type': 'application/json'
                }
            });
            const data = await response.json();
            setUser(data);
        };
        fetchUser();
    }, []);

    return (
        <div className="student-header">
            <div className="student-info">
                <h3>{user?.username} {user?.username}</h3>
                <p>{user?.role}</p>
            </div>
        </div>
    );
};



export default Header;