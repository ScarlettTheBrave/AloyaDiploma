import https from 'https';
import {SetUser} from "../api/userOp.js"
export const handleSignUp = async (email, password) => {
    const formData = new FormData();
    formData.append('email', email);
    formData.append('password', password);

    try {
        const response = await fetch('http://localhost:5047/api/User/login', {
            method: 'POST',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false })
        });
        const data = await response.json();
        SetUser(data);
            return response;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};