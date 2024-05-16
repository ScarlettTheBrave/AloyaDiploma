import React, { useState } from 'react';

interface LectionFormProps {
  onLectionSubmit: (data: LectionData) => void;
}
interface FormData {
    id: number;
    name: string;
    description: string;
    colour: string;
    photo: string;
    lections: LectionData[];
    test: TestData[];
  }
  
  interface LectionData {
    id: number;
    name: string;
    description: string;
    text: string;
    moduleId: number;
    links: LinkData[];
    illustrations: IllustrationData[];
  }
  
  interface LinkData {
    id: number;
    lectionId: number;
    name: string;
    type: number;
  }
  
  interface IllustrationData {
    id: number;
    lectionId: number;
    name: string;
    photo: string;
  }
  
  interface TestData {
    id: number;
    moduleId: number;
    name: string;
    areaTests: AreaTestData[];
    imageTests: ImageTestData[];
    formTests: FormTestData[];
    maxCost: number;
  }
  
  interface AreaTestData {
    id: number;
    testId: number;
    name: string;
    areaAnswers: AreaAnswerData[];
    question: string;
    cost: number;
  }
  
  interface ImageTestData {
    id: number;
    testId: number;
    name: string;
    images: ImageAnswerData[];
    question: string;
    cost: number;
  }
  
  interface FormTestData {
    id: number;
    name: string;
    testId: number;
    question: string;
    answers: FormAnswerData[];
    cost: number;
  }
  
  interface AreaAnswerData {
    id: number;
    areaTaskId: number;
    isRight: boolean;
    photo: string;
  }
  
  interface ImageAnswerData {
    id: number;
    imageTaskId: number;
    photo: string;
    isRight: boolean;
  }
  
  interface FormAnswerData {
    id: number;
    formTaskId: number;
    text: string;
    isRight: boolean;
  }
const LectionForm: React.FC<LectionFormProps> = ({ onLectionSubmit }) => {
  const [lectionData, setLectionData] = useState<LectionData>({
    id: 0,
    name: '',
    description: '',
    text: '',
    moduleId: 0,
    links: [],
    illustrations: []
  });

  const handleLectionChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setLectionData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleLinkChange = (index: number, e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    const updatedLinks = [...lectionData.links];
    updatedLinks[index] = { ...updatedLinks[index], [name]: value };
    setLectionData(prevState => ({
      ...prevState,
      links: updatedLinks
    }));
  };

  const handleIllustrationChange = (index: number, e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    const updatedIllustrations = [...lectionData.illustrations];
    updatedIllustrations[index] = { ...updatedIllustrations[index], [name]: value };
    setLectionData(prevState => ({
      ...prevState,
      illustrations: updatedIllustrations
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onLectionSubmit(lectionData);
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name:
        <input type="text" name="name" value={lectionData.name} onChange={handleLectionChange} />
      </label>
      <label>
        Description:
        <textarea name="description" value={lectionData.description} onChange={handleLectionChange} />
      </label>
      <label>
        Text:
        <textarea name="text" value={lectionData.text} onChange={handleLectionChange} />
      </label>
      {/* Подформа для ввода данных о ссылках */}
      {lectionData.links.map((link, index) => (
        <div key={index}>
          <input type="text" name="name" value={link.name} onChange={(e) => handleLinkChange(index, e)} />
          {/* Другие поля для ссылок */}
        </div>
      ))}
      {/* Кнопка для добавления новой ссылки */}
      <button type="button" onClick={() => setLectionData(prevState => ({ ...prevState, links: [...prevState.links, { id: 0, lectionId: 0, name: '', type: 0 }] }))}>Add Link</button>
      {/* Подформа для ввода данных об иллюстрациях */}
      {lectionData.illustrations.map((illustration, index) => (
        <div key={index}>
          <input type="text" name="name" value={illustration.name} onChange={(e) => handleIllustrationChange(index, e)} />
          {/* Другие поля для иллюстраций */}
        </div>
      ))}
      {/* Кнопка для добавления новой иллюстрации */}
      <button type="button" onClick={() => setLectionData(prevState => ({ ...prevState, illustrations: [...prevState.illustrations, { id: 0, lectionId: 0, name: '', photo: '' }] }))}>Add Illustration</button>
      <button type="submit">Submit Lection</button>
    </form>
  );
};

export default LectionForm;
