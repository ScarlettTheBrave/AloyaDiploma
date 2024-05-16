"use client";

import { useState } from "react";
import { byteArrayToString, toBase64, toByte } from "../api/photo";
import {addModule} from "../api/AddModule.js";

export default function ModuleManag() {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [color, setColor] = useState('');
    const [photoBase64, setPhotoBase64] = useState('');
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
    const handleSubmit = async () => {
        var photo = (toByte(photoBase64).toString());
        const r =  await addModule(photo, name, description, color);
    };

    const handleDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDescription(event.target.value);
    };

    const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleColorChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setColor(event.target.value);
    };

    return (
    <form onSubmit={(e) => e.preventDefault()} style={{display: 'flex', alignItems: 'center',justifyContent: 'center', flexDirection: 'column', marginTop: '5em'}}>
        <p style={{fontSize: '2em'}}>Create a module</p>
        <div style={{background: 'black',border: '1.5px solid black', width: '15vw', height: '6vh',flexDirection: 'row'}}>
            <label style={{color: 'white'}}>Name:</label>
            <input style={{width: '15vw',height: '4vh'}} name="name" value={name} onChange={handleNameChange}></input>
        </div>
        <div style={{background: 'black',border: '1.5px solid black', width: '15vw', height: '6vh',marginTop: '1em'}}>
            <label style={{color: 'white'}}>Description:</label>
            <input style={{width: '15vw',height: '4vh'}} name="description" value={description} onChange={handleDescriptionChange}></input>
        </div>
        <div style={{background: 'black',border: '1.5px solid black', width: '15vw', height: '6.5vh',marginTop: '1em'}}>
            <label style={{color: 'white'}}>Color:</label>
            <input style={{width: '15vw',height: '4vh'}} name="color" value={color} onChange={handleColorChange}></input>
        </div>
        <label htmlFor="imageInput" style={{ cursor: 'pointer',marginTop: '1em'}}>
            <div style={{ background: 'black', width: '31vh', height: '31vh', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <img style={{ width: '100%', height: '100%', border: '2px solid black', objectFit: 'contain' }} src={photoBase64 ? photoBase64 : "load.jpg"} alt="Image" />
            </div>
        </label>
        <input
            type="file"
            id="imageInput"
            accept="image/*"
            style={{ display: 'none' }}
            name="photo"
            onChange={handleImageChange}
        />
        <button onClick={handleSubmit} style={{background: 'black',color: 'white',border: 'none', width: '31vh',height: '5vh',marginTop: '1em'}} type="submit">Create</button>
        <a href="\addLection">Add Lection</a>
        <a href="\AddTest">Add Test</a>
    </form>)
}