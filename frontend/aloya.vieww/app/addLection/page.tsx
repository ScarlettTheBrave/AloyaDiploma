"use client";
import React, { useState } from 'react';
import { Input, Button, Form, message } from 'antd';
import { addLections } from "../api/addLections";

interface Link {
  id: number;
  name: string;
  type: number;
}

interface Illustration {
  id: number;
  name: string;
  photo: Uint8Array | null;
}

interface FormData {
  name: string;
  description: string;
  text: string;
  moduleId: number;
  links: Link[];
  illustrations: Illustration[];
}

export default function LecPage(par: number) {
  const [formData, setFormData] = useState<FormData>({
    name: '',
    description: '',
    text: '',
    moduleId: 0,
    links: [],
    illustrations: []
  });

  const [errors, setErrors] = useState<Record<string, string>>({});

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>, fieldName: string) => {
    const { value } = event.target;
    setFormData(prevState => ({
      ...prevState,
      [fieldName]: value
    }));
  };

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>, index: number) => {
    const file = event.target.files?.[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = () => {
            const arrayBuffer = reader.result as ArrayBuffer;
            const byteArray = new Uint8Array(arrayBuffer);
            setFormData(prevState => ({
                ...prevState,
                illustrations: prevState.illustrations.map((item, i) => i === index ? { ...item, photo: byteArray } : item)
            }));
        };
        reader.readAsArrayBuffer(file);
    }
    // Создание новой иллюстрации только если выбрано новое изображение
    if (!formData.illustrations[index].photo) {
        setFormData(prevState => ({
            ...prevState,
            illustrations: prevState.illustrations.map((item, i) => i === index ? { ...item, id: prevState.illustrations.length, photo: null } : item)
        }));
    }
};


  const addLink = () => {
    const newLinkId = formData.links.length;
    setFormData(prevState => ({
      ...prevState,
      links: [...prevState.links, { id: newLinkId, name: '', type: 0 }]
    }));
  };

  const addIllustration = () => {
    const newIllustrationId = formData.illustrations.length;
    setFormData(prevState => ({
      ...prevState,
      illustrations: [...prevState.illustrations, { id: newIllustrationId, name: '', photo: null }]
    }));
  };

  const validateForm = () => {
    const newErrors: Record<string, string> = {};
    if (!formData.name) newErrors.name = 'Name is required';
    if (!formData.description) newErrors.description = 'Description is required';
    if (!formData.text) newErrors.text = 'Text is required';
    return newErrors;
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const validationErrors = validateForm();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    const payload = {
      Name: formData.name,
      Description: formData.description,
      Text: formData.text,
      ModuleId: formData.moduleId,
      Links: formData.links.map(({ id, ...rest }) => rest),
      Illustrations: formData.illustrations.map(({ id, photo, ...rest }) => ({
        ...rest,
        "PhotoBase64": photo ? Array.from(new Uint8Array(photo)).join(',') : null
      }))
    };

   
      const response = await addLections(payload);
    
        setFormData({
          name: '',
          description: '',
          text: '',
          moduleId: par ? par : 0,
          links: [],
          illustrations: []
        });
      
    
  };

  return (
    <form onSubmit={handleSubmit} style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', marginTop: '3vh', marginBottom: '3vh' }}>
      <label style={{ paddingLeft: '15vh', paddingTop: '4vh', alignItems: 'center', background: 'black', color: 'white', fontSize: '1rem', width: '43vh', height: '5rem' }}>ADD LECTION</label>
      <div style={{width: '43vh'}}>
        <label>
          Module ID:
          <Input type="text" name="moduleId" value={formData.moduleId} onChange={(e) => handleInputChange(e, "moduleId")} />
        </label>
        <br />
        <label>
          Name:
          <Input type="text" name="name" value={formData.name} onChange={(e) => handleInputChange(e, "name")} />
          {errors.name && <span style={{ color: 'red' }}>{errors.name}</span>}
        </label>
        <br />
        <label>
          Description:
          <Input type="text" name="description" value={formData.description} onChange={(e) => handleInputChange(e, "description")} />
          {errors.description && <span style={{ color: 'red' }}>{errors.description}</span>}
        </label>
        <br />
        <label>
          Text:
          <Input.TextArea name="text" value={formData.text} onChange={(e) => handleInputChange(e, "text")} rows={4} />
          {errors.text && <span style={{ color: 'red' }}>{errors.text}</span>}
        </label>
        <br />
      </div>
      {formData.links.map((link, index) => (
        <div key={index} style={{ borderRadius: '1rem', background: 'black', display: 'flex', alignItems: 'center', flexDirection: 'column', marginTop: '5vh', marginBottom: '1vh', height: '10rem', width: '20rem' }}>
          <label style={{ color: 'white', fontSize: '1rem' }}>
            LINK
          </label>
          <label style={{ color: 'white' }}>
            Link Name:
            <Input value={link.name} onChange={(e) => setFormData(prevState => ({
              ...prevState,
              links: prevState.links.map((item, i) => i === index ? { ...item, name: e.target.value } : item)
            }))} />
          </label>
          <label style={{ color: 'white' }}>
            Link Type:
            <Input type="number" value={link.type} onChange={(e) => setFormData(prevState => ({
              ...prevState,
              links: prevState.links.map((item, i) => i === index ? { ...item, type: parseInt(e.target.value) } : item)
            }))} />
          </label>
        </div>
      ))}
      <button style={{background: 'black', marginTop: '5vh', width: '20rem', height: '3rem' }} type="button" onClick={addLink}>Add Link</button>
      <br />
      {formData.illustrations.map((illustration, index) => (
        <div key={index} style={{ borderRadius: '1rem', background: 'black', display: 'flex', alignItems: 'center', flexDirection: 'column', marginTop: '5vh', marginBottom: '1vh', height: '10rem', width: '20rem' }}>
          <label style={{ color: 'white', fontSize: '1rem' }}>
            ILLUSTRATION
          </label>
          <label style={{ color: 'white' }}>
            Illustration Name:
            <Input value={illustration.name} onChange={(e) => setFormData(prevState => ({
              ...prevState,
              illustrations: prevState.illustrations.map((item, i) => i === index ? { ...item, name: e.target.value } : item)
            }))} />
          </label>
          <label style={{ color: 'white',width: '19vw' }}>
            Illustration Photo:
            
            <Input type="file" onChange={(e) => handleFileChange(e, index)} />
          </label>
        </div>
      ))}
      <button style={{background: 'black', marginTop: '5vh', width: '20rem', height: '3rem' }} type="button" onClick={addIllustration}>Add Illustration</button>
      <br />
      <button style={{background: 'black', width: '20rem', height: '3rem' }} type="submit">Submit</button>
      <a href="\modulesmanag">Back</a>
    </form>
  );
};
