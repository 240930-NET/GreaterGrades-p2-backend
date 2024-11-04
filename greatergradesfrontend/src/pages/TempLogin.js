import { useContext, useState } from 'react';
import { UserContext } from '../functions/UserContext';
import { loginAPI, getUserAPI } from '../greatergradesapi/Auth';
import { useNavigate } from 'react-router-dom';

const TempLogin = () => {
    const { login } = useContext(UserContext);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        const token = await loginAPI(username, password);
        if (!token) {
            alert('token failed')
            return;
        }
        const user = await getUserAPI(username, token);
        if (!user) {
            alert('login failed')
            return;
        }

        login(token, user);
        navigate('/dashboard')
    };

    return (
        <form onSubmit={handleLogin}>
            <input 
                type="text" 
                placeholder="Username" 
                value={username} 
                onChange={(e) => setUsername(e.target.value)} 
            />
            <input 
                type="password" 
                placeholder="Password" 
                value={password} 
                onChange={(e) => setPassword(e.target.value)} 
            />
            <button type="submit">Login</button>
        </form>
    );
};

export default TempLogin;