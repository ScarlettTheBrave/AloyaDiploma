import https from 'https';

export const Register = async (username, email, password) => {
    try {
        const formData = new FormData();
        formData.append('username', username);
        formData.append('email', email);
        formData.append('password', password);

        const response = await fetch('http://localhost:5047/api/User/register', {
            method: 'POST',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false })
        });

        return response.status;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};