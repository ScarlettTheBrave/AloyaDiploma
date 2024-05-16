"use client";
import React, { useState } from 'react';

const AddModule = () => {
    const [lectionForms, setLectionForms] = useState<any[]>([]); // Либо примените более конкретный тип данных для элементов, если это возможно

    const addLectionForm = () => {
        const newForm = (
            <div key={lectionForms.length}>
                <div>
                    <label>Name:</label>
                    <input type="text" onChange={(e) => handleInputChange(e, 'name')} />
                </div>
                <div>
                    <label>About:</label>
                    <textarea onChange={(e) => handleInputChange(e, 'about')} />
                </div>
                <div>
                    <label>Content:</label>
                    <textarea onChange={(e) => handleInputChange(e, 'content')} />
                </div>
            </div>
        );
        setLectionForms(prevForms => [...prevForms, newForm]);
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>, field: string) => {
        const { value } = e.target;
        const updatedForm = [...lectionForms];
        const index = updatedForm.length - 1;
        const lectionData = { ...updatedForm[index].props, [field]: value }; // Необходимо убедиться, что props доступны
        updatedForm[index] = lectionData;
        setLectionForms(updatedForm);
    };

    const handleSubmit = () => {
        console.log(lectionForms);
    };

    return (
        <div style={{ marginTop: '10vh', display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
            <form style={{ flexDirection: 'column', width: '22.5%', height: '50%' }}>
                <div>
                    <label>name</label>
                    <input></input>
                </div>
                <div>
                    <label>name</label>
                    <input></input>
                </div>
                <button type="button" onClick={addLectionForm}>Add Lection</button>
                {lectionForms.map(form => form)}
                <button type="button" onClick={handleSubmit}>Submit</button>
            </form>
        </div>
    );
};

export default AddModule;