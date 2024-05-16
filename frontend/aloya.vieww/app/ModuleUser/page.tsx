"use client";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

interface Module {
  id: number;
  name: string;
  description: string;
  image: string;
  colour: string;
}

const ModuleUserPage = () => {
  const { id } = useParams<{ id: string }>(); // Получение id из URL
  const [module, setModule] = useState<Module | null>(null);

  useEffect(() => {
    const fetchModule = async () => {
      try {
        const response = await fetch(`http://localhost:5047/api/Admin/Modules/${id}`);
        const data = await response.json();
        setModule(data); // Установка данных модуля в состояние
      } catch (error) {
        console.error("Ошибка загрузки модуля:", error);
      }
    };

    fetchModule();
  }, [id]);

  // Если модуль еще загружается, отображаем загрузочное сообщение
  if (!module) {
    return <div>Loading...</div>;
  }

  // Отображение информации о модуле
  return (
    <div>
      <h2>{module.name}</h2>
      <p>{module.description}</p>
      <img src={module.image} alt={module.name} />
      <div style={{ backgroundColor: module.colour, width: "100px", height: "100px" }}></div>
    </div>
  );
};

export default ModuleUserPage;
