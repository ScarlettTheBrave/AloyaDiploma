import https from 'https';
export const addModule = async (photo, name, description, color) => {
    const formData = new FormData();
    formData.append('name',name);
    formData.append('description', description);
    formData.append('colour', color);
    formData.append('photo', toByte(photo));

    try {
        const result = await fetch('http://localhost:5047/api/Teacher', {
            method: 'POST',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
        return result;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};
