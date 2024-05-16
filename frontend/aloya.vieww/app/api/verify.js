import https from 'https';
export const Verify = async (phone) => {
    const formData = new FormData();
    formData.append('phone', phone);

    try {
        const response = await fetch('http://localhost:5047/api/User/verify', {
            method: 'PUT',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
            return response;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};