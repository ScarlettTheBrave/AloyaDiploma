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
interface ModuleUserPageProps {
  id: number;
}
const ModuleUserPage = () => {
  const [module, setModule] = useState<Module | null>(null);
  const storedId = localStorage.getItem('moduleId');
  useEffect(() => {
    const fetchModule = async () => {
      try {
        const response = await fetch(`http://localhost:5047/api/Admin/Module?id=${storedId}`);
        const data = await response.json();
        setModule(data); // Установка данных модуля в состояние
      } catch (error) {
        console.error("Ошибка загрузки модуля:", error);
      }
    };

    fetchModule();
  }, []);

  if (!module) {
    return <div>Loading...</div>;
  }
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
