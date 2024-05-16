import https from 'http'

export const ChangePassword = async (password, confirm) => {
    
    const formData = new FormData();
    formData.append('password', password);
    formData.append('confirm', confirm);


    try {
        const response = await fetch('http://localhost:5047/api/User/PasswordChange', {
            method: 'PUT',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
            return response;
    } catch (error) {
        console.error('Ошибка:', error);
    }
}