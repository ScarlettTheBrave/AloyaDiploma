export const SetUser = async (data) => { 
    const mappedObject = {
        id: data.id,
        username: data.username,
        firstName: data.firstName,
        lastName: data.lastName,
        email: data.email,
        photo: data.photo,
        admicies: data.admicies.map(admicy => ({
            id: admicy.id,
            userId: admicy.userId,
            role: admicy.role
        }))
    };
    const jsonStr = JSON.stringify(mappedObject);
    localStorage.setItem('User', jsonStr);
}
export const GetUser = async () => {
    const jsonStr = localStorage.getItem('User');
    const mappedObject = JSON.parse(jsonStr);
    return mappedObject;
}
export const SaveProfile = async (avatar,username,firstname,lastname) => {
    let user = GetUser();
    const admicies = user.admicies ? user.admicies.map(admicy => ({
        id: admicy.id,
        userId: admicy.userId,
        role: admicy.role
    })) : [];
    const mappedObject = {
        id: user.id,
        username: username,
        firstName: firstname,
        lastName: lastname,
        email: user.email,
        photo: avatar,
        admicies: admicies
        }
    
    SetUser(mappedObject);
};