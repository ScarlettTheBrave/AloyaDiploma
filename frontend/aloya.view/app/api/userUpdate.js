import https from 'https';
import { GetUser, SaveProfile, SetUser } from './userOp';
export const userUpdate = async (avatar, username, lastname, firstname) => {
    const formData = new FormData();
    formData.append('avatar', avatar);
    formData.append('username', username);
    formData.append('firstname', firstname);
    formData.append('lastname', lastname);
    await SaveProfile(avatar,username,firstname,lastname);
    try {
        const result = await fetch('http://localhost:5047/api/User/userUpdate', {
            method: 'PUT',
            body: formData,
            credentials: 'include',
            agent: new https.Agent({ rejectUnauthorized: false }) 
        });
        return result;
    } catch (error) {
        console.error('Ошибка:', error);
    }
};
