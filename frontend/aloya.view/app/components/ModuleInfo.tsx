import React, { useState, ChangeEvent } from 'react';

interface ModuleInfoFormProps {
  onsubmit: (data: any) => void; // Предполагая, что тип данных data - any
}

const ModuleInfoForm: React.FC<ModuleInfoFormProps> = ({ onsubmit }) => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [color, setColor] = useState('');
  const [selectedImage, setSelectedImage] = useState<File | null>(null);

  const handleImageChange = (event: ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    setSelectedImage(file || null);
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const moduleInfoObject = {
      name,
      description,
      color,
      image: selectedImage,
    };
    // Вызываем функцию обратного вызова и передаем ей данные формы
    onsubmit(moduleInfoObject);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>Name:</label>
        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />

        <label>Description:</label>
        <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />

        <label>Color:</label>
        <input type="text" value={color} onChange={(e) => setColor(e.target.value)} />

        <label htmlFor="imageInput">
          Upload Image:
          <input
            type="file"
            id="imageInput"
            accept="image/*"
            style={{ display: 'none' }}
            onChange={handleImageChange}
          />
        </label>

        <button type="submit">Set</button>
      </form>
    </div>
  );
};

export default ModuleInfoForm;
