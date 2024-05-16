import https from 'https';

export const addLections = async (formData) => {
    
    try {
        const result = await fetch('http://localhost:5047/api/Teacher/AddLection', {
            method: 'POST',
            body: JSON.stringify(formData), // Преобразуйте объект formData в строку JSON
            headers: {
                'Content-Type': 'application/json' // Установите заголовок Content-Type на application/json
            },
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
        return result;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};