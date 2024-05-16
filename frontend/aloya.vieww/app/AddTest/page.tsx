"use client";
import React, { useState } from 'react';
import { Input, Button } from 'antd';
import { addTester } from "../api/addTests";
import { toByte } from '../api/photo';

interface AreaAnswer {
  id: number;
  isRight: boolean;
  x: number;
  y: number;
  radius: number;
}

interface AreaTask {
  id: number;
  name: string;
  question: string;
  photo: string;
  areaAnswers: AreaAnswer[];
}

interface ImageAnswer {
  id: number;
  isRight: boolean;
  photo: string;
}

interface ImageTask {
  id: number;
  name: string;
  question: string;
  images: ImageAnswer[];
}

interface FormAnswer {
  id: number;
  isRight: boolean;
  text: string;
}

interface FormTask {
  id: number;
  name: string;
  question: string;
  answers: FormAnswer[];
}

type TaskType = AreaTask | ImageTask | FormTask;

const AddTest: React.FC = () => {
  const [formData, setFormData] = useState<TaskType[]>([]);
  const [moduleId, setModuleId] = useState('');
  
  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>, taskId: number, fieldName: keyof TaskType) => {
    const { value } = event.target;
    const updatedData = formData.map(task => {
      if (task.id === taskId) {
        return { ...task, [fieldName]: value };
      }
      return task;
    });
    setFormData(updatedData);
  };

  const handleImageInputChange = (event: React.ChangeEvent<HTMLInputElement>, taskId: number, answerId?: number) => {
    const file = event.target.files && event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        const byteString = toByte(reader.result as string).toString();
        const updatedData = formData.map(task => {
          if (task.id === taskId) {
            if ('photo' in task && answerId === undefined) {
              return { ...task, photo: byteString };
            } else if ('images' in task && answerId !== undefined) {
              const updatedImages = task.images.map(image => {
                if (image.id === answerId) {
                  return { ...image, photo: byteString }; // Обновляем только фото нужного ответа
                }
                return image;
              });
              return { ...task, images: updatedImages };
            }
          }
          return task;
        });
        setFormData(updatedData);
      };
      reader.readAsDataURL(file);
    }
  };
  

  const handleAnswerInputChange = (event: React.ChangeEvent<HTMLInputElement>, taskId: number, answerId: number, fieldName: any, taskType: string) => {
    const { value, type, checked } = event.target;
    const updatedData = formData.map(task => {
      if (task.id === taskId) {
        switch (taskType) {
          case "area":
            if ('areaAnswers' in task) {
              const updatedAnswers = task.areaAnswers.map(answer => {
                if (answer.id === answerId) {
                  return type === 'checkbox' ? { ...answer, [fieldName]: checked } : { ...answer, [fieldName]: parseFloat(value) };
                }
                return answer;
              });
              return { ...task, areaAnswers: updatedAnswers };
            }
            break;
          case "image":
            if ('images' in task) {
              const updatedImages = task.images.map(image => {
                if (image.id === answerId) {
                  return type === 'checkbox' ? { ...image, [fieldName]: checked } : { ...image, [fieldName]: value };
                }
                return image;
              });
              return { ...task, images: updatedImages };
            }
            break;
          case "form":
            if ('answers' in task) {
              const updatedAnswers = task.answers.map(answer => {
                if (answer.id === answerId) {
                  return type === 'checkbox' ? { ...answer, [fieldName]: checked } : { ...answer, [fieldName]: value };
                }
                return answer;
              });
              return { ...task, answers: updatedAnswers };
            }
            break;
          default:
            return task;
        }
      }
      return task;
    });
    setFormData(updatedData);
  };

  const addTask = (taskType: string) => {
    const newTaskId = formData.length + 1;
    let newTask: TaskType;
    switch (taskType) {
      case "area":
        newTask = {
          id: newTaskId,
          name: '',
          question: '',
          photo: '',
          areaAnswers: [],
        };
        break;
      case "image":
        newTask = {
          id: newTaskId,
          name: '',
          question: '',
          images: [],
        };
        break;
      case "form":
        newTask = {
          id: newTaskId,
          name: '',
          question: '',
          answers: [],
        };
        break;
      default:
        newTask = {
          id: newTaskId,
          name: '',
          question: '',
          photo: '',
          areaAnswers: [],
        };
        break;
    }
    setFormData([...formData, newTask]);
  };

  const addAnswer = (taskId: number, taskType: string) => {
    const updatedData = formData.map(task => {
      if (task.id === taskId) {
        switch (taskType) {
          case "area":
            if ('areaAnswers' in task) {
              const newAreaAnswerId = task.areaAnswers.length + 1;
              const newAreaAnswer: AreaAnswer = {
                id: newAreaAnswerId,
                isRight: false,
                x: 0
                ,
                y: 0,
                radius: 0,
              };
              return { ...task, areaAnswers: [...task.areaAnswers, newAreaAnswer] };
            }
            break;
          case "image":
            if ('images' in task) {
              const newImageAnswerId = task.images.length + 1;
              const newImageAnswer: ImageAnswer = {
                id: newImageAnswerId,
                isRight: false,
                photo: '',
              };
              return { ...task, images: [...task.images, newImageAnswer] };
            }
            break;
          case "form":
            if ('answers' in task) {
              const newFormAnswerId = task.answers.length + 1;
              const newFormAnswer: FormAnswer = {
                id: newFormAnswerId,
                isRight: false,
                text: '',
              };
              return { ...task, answers: [...task.answers, newFormAnswer] };
            }
            break;
          default:
            return task;
        }
      }
      return task;
    });
    setFormData(updatedData);
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log(formData);
    const formDataToSend = {
      id: 0,
      moduleId: moduleId ? moduleId : 1,
      name: "string",
      areaTests: [] as AreaTask[],
      imageTests: [] as ImageTask[],
      formTests: [] as FormTask[],
      maxCost: 20
    };

    formData.forEach(task => {
      if ('areaAnswers' in task) {
        const areaTest: AreaTask = {
          id: task.id,
          name: task.name,
          photo: task.photo,
          areaAnswers: task.areaAnswers,
          question: task.question,
        };
        formDataToSend.areaTests.push(areaTest);
      } else if ('images' in task) {
        const imageTest: ImageTask = {
          id: task.id,
          name: task.name,
          images: task.images,
          question: task.question,
        };
        formDataToSend.imageTests.push(imageTest);
      } else if ('answers' in task) {
        const formTest: FormTask = {
          id: task.id,
          name: task.name,
          question: task.question,
          answers: task.answers,
        };
        formDataToSend.formTests.push(formTest);
      }
    });
    console.log(formDataToSend);
    await addTester(formDataToSend);
  };

  const handleModuleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setModuleId(event.target.value);
  };

  return (
    <form onSubmit={handleSubmit} style={{ display: 'flex', alignItems: 'center', flexDirection: 'column', marginTop: '5vh', marginBottom: '5vh', width: '25%', marginLeft: '40%' }}>
      <label>ModuleId:</label>
      <input onChange={handleModuleChange}></input>
      <Button onClick={() => addTask("area")}>Add Area Task - Add Area Answer</Button>
      <Button onClick={() => addTask("image")}>Add Image Task - Add Image</Button>
      <Button onClick={() => addTask("form")}>Add Form Task - Add Form Answer</Button>
      {formData.map(task => (
        <div key={task.id}>
          <Input
            placeholder="Task Name"
            value={task.name}
            onChange={(e) => handleInputChange(e, task.id, "name")}
          />
          <Input
            placeholder="Task Question"
            value={task.question}
            onChange={(e) => handleInputChange(e, task.id, "question")}
          />
          {task.hasOwnProperty('photo') && (
            <Input
              type="file"
              onChange={(e) => handleImageInputChange(e, task.id)}
            />
          )}
          <Button style={{ width: '20%' }} onClick={() => addAnswer(task.id, "area")}>Area Answer</Button>
          {'areaAnswers' in task && task.areaAnswers.map(answer => (
            <div key={answer.id} style={{ background: 'purple', borderRadius: '1vh', marginBottom: '1vh', marginTop: '1vh' }}>
              <label>Is Right:</label>
              <Input
                type="checkbox"
                checked={answer.isRight}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "isRight", "area")}
              />
              <label>X:</label>
              <Input
                value={answer.x.toString()}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "x", "area")}
              />
              <label>Y:</label>
              <Input
                value={answer.y.toString()}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "y", "area")}
              />
              <label>Radius:</label>
              <Input
                value={answer.radius.toString()}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "radius", "area")}
              />
            </div>
          ))}
          <Button style={{ width: '30%' }} onClick={() => addAnswer(task.id, "image")}>Image Answer</Button>
          {'images' in task && task.images.map(image => (
            <div key={image.id} style={{ background: 'orange', borderRadius: '1vh', marginBottom: '1vh', marginTop: '1vh' }}>
              <label>Is Right:</label>
              <Input
                type="checkbox"
                checked={image.isRight}
                onChange={(e) => handleAnswerInputChange(e, task.id, image.id, "isRight", "image")}
              />
              <label>Photo:</label>
              <Input
                type="file"
                onChange={(e) => handleImageInputChange(e, task.id, image.id)}
              />
            </div>
          ))}
          <Button style={{ width: '30%' }} onClick={() => addAnswer(task.id, "form")}>Form Answer</Button>
          {'answers' in task && task.answers.map(answer => (
            <div key={answer.id} style={{ background: 'green', borderRadius: '1vh', marginBottom: '1vh', marginTop: '1vh' }}>
              <div style={{ display: 'flex', flexDirection: 'column' }}>
                <label style={{ marginLeft: '20vh' }}>Form Answer</label>
                <label>Is Right:</label>
              </div>
              <Input
                type="checkbox"
                checked={answer.isRight}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "isRight", "form")}
              />
              <label>Text:</label>
              <Input
                value={answer.text}
                onChange={(e) => handleAnswerInputChange(e, task.id, answer.id, "text", "form")}
              />
            </div>
          ))}
        </div>
      ))}
      <button type="submit">Submit</button>
    </form>
  );
};

export default AddTest;
