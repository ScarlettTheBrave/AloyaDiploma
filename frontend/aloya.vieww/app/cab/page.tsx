"use client";
import React, { useEffect, useState } from 'react';
import { toBase64, toByte} from '../api/photo.js';

import { GetUser } from '../api/userOp.js';
import { userUpdate } from '../api/userUpdate.js';

export default function CabPage() {
    const [user, setUser] = useState({
        id: '',
        username: '',
        firstName: '',
        lastName: '',
        email: '',
        photo: '',
        admicies: []
    });
    const [photoBase64, setPhotoBase64] = useState('');
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [bytes,setBytes] = useState('');
    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files && event.target.files[0]) {
            const reader = new FileReader();
            reader.onload = (e) => {
                if (e.target && typeof e.target.result === 'string') {
                    setPhotoBase64(e.target.result);
                }
            };
            reader.readAsDataURL(event.target.files[0]);
        }
    };

    
    useEffect(() => {
        const fetchUser = async () => {
            try {
                const userData = await GetUser();

                setEmail(userData.email || '');
                setUsername(userData.username || '');
                setFirstName(userData.firstName || '');
                setLastName(userData.lastName || '');
                let byteString = userData.photo;
                let base64string = toBase64(stringToByteArray(byteString));
                setPhotoBase64(base64string || "none.jpg");
            } catch (error) {
                console.error('Error fetching user data:', error);
            }
        };
    
        fetchUser();
    }, []);
    function stringToByteArray(str: string) {
        var numbers = str.split(',').map(Number);
        var byteArray: number[] = [];
        numbers.forEach(function(element) {
            byteArray.push(element);
        });
        return byteArray;
    }
    const handleUpdateProfile = async () => {
        

        const v = await userUpdate(toByte(photoBase64).toString(), username, firstName, lastName);
    };

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };

    const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
    };

    const handleFirstNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setFirstName(event.target.value);
    };

    const handleLastNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setLastName(event.target.value);
    };
    const handleChangePassword = () => {

        window.location.href = '/changepassword';
    };
    
    const handleVerify = () => {
        window.location.href = '/verify';
    };
    return (
        <div>
    <div style={{ margin: '0 auto', maxWidth: '70vh', minHeight: '35vh' }}>
        <div style={{ marginBottom: '0.15vh',marginTop: '15vh' }}></div>
        <a style={{ marginBottom: '1%',marginTop: '2vh', border: '3px solid black', color: 'black', justifyContent: 'center', display: 'flex',height: '5vh', width: '89%', alignItems: 'center', marginLeft: '6%', fontSize: '3.15vh', fontFamily: 'Montserrat, sans-serif', fontWeight: 'bold' }}>Your account:</a>
        <form onSubmit={(e) => e.preventDefault()} style={{ background: 'white', marginTop: '0vh', height: '20%', width: '90%', margin: 'auto', display: 'flex', justifyContent: 'center', alignItems: 'center',  }}>
            <label htmlFor="imageInput" style={{ cursor: 'pointer', marginLeft: '2.2%' }}>
                <div style={{ background: 'black', width: '29vh', height: '30vh', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                    <img style={{ width: '29vh', height: '100%', border: '2px solid black', objectFit: 'contain' }} src={photoBase64 ? photoBase64 : "none.jpg"} alt="Image" />
                </div>
            </label>
            <input
                type="file"
                id="imageInput"
                accept="image/*"
                style={{ display: 'none' }}
                onChange={handleImageChange}
            />
            <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center',height: '33vh', width: '200vh' }}>
                <div style={{ background: 'black', flexDirection: 'column', justifyContent: 'center', alignItems: 'center', marginLeft: '2vh' }}>
                    <div style={{ paddingLeft: '4%', background: 'black', width: '95%', color: 'white', marginBottom: '0.5vh' }}>
                        <a style={{ fontWeight: 'bold', height: '100%', width: '25%', background: 'black', color: 'white' }}>Username</a>
                        <input onChange={handleUsernameChange} value={username} style={{ paddingLeft: '0.5vh', background: 'white', color: 'black', height: '4.0vh', width: '100%' }}></input>
                    </div>
                    <div style={{ paddingLeft: '4%', background: 'black', width: '95%', color: 'white', marginBottom: '0.5vh' }}>
                        <a style={{ fontWeight: 'bold', height: '100%', width: '25%', background: 'black', color: 'white' }}>Firstname:</a>
                        <input onChange={handleFirstNameChange} value={firstName} style={{ paddingLeft: '0.5vh', background: 'white', color: 'black', height: '4.0vh', width: '100%' }}></input>
                    </div>
                    <div style={{ paddingLeft: '4%', background: 'black', width: '95%', color: 'white', marginBottom: '0.5vh' }}>
                        <a style={{ fontWeight: 'bold', height: '100%', width: '75%', background: 'black', color: 'white' }}>Lastname:</a>
                        <input onChange={handleLastNameChange} value={lastName} style={{ paddingLeft: '0.5vh', background: 'white', color: 'black', height: '4.0vh', width: '100%' }}></input>
                    </div>
                    <div style={{ paddingLeft: '4%', background: 'black', width: '95%', color: 'white', marginBottom: '0.5vh' }}>
                        <button type="button" onClick={handleUpdateProfile} style={{ paddingLeft: '0 %', fontSize: '2.5vh', fontWeight: 'Bold', background: 'red', color: 'white', border: 'none', width: '100%', height: '5vh', marginTop: '2vh', marginBottom: '1vh' }}>Update</button>
                    </div>
                </div>
            </div>
        </form>
        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <button  onClick={handleChangePassword} type="button" style={{ marginLeft: '0.8vh', border: '3px solid black', fontSize: '2.5vh', fontWeight: 'Bold', background: 'White', color: 'Black', width: '30.5vh', height: '5vh', marginTop: '0vh', marginBottom: '1vh' }}>Change Password</button>
            <button  onClick={handleVerify} type="button" style={{ marginLeft: '1.3vh', border: '3px solid black', fontSize: '2.5vh', fontWeight: 'Bold', background: 'White', color: 'Black', width: '30.7vh', height: '5vh', marginTop: '0vh', marginBottom: '1vh' }}>Verify</button>
        </div>
    </div>
</div>

    );
}
