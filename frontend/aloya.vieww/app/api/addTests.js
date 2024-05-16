import https from 'https';

export const addTester = async (formData) => {
    
    try {
        const result = await fetch('http://localhost:5047/api/Teacher/AddTest', {
            method: 'POST',
            body: JSON.stringify(formData), 
            headers: {
                'Content-Type': 'application/json' 
            },
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
        return result;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};