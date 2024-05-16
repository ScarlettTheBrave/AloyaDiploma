"use client";
import { useEffect, useState } from "react";
import { stringToByteArray, toBase64 } from "../api/photo";

interface Module {
  id: number;
  name: string;
  description: string;
  image: string;
  colour: string;
}

export default function ModulesPage() {
  const [modules, setModules] = useState<Module[]>([]);

  useEffect(() => {
    const fetchModules = async () => {
      try {
        const response = await fetch("http://localhost:5047/api/Admin/Modules");
        const data = await response.json();
        const parsedData = data.map((item: any) => ({
          colour: item.colour,
          description: item.description,
          id: item.id,
          image: item.image,
          name: item.name
        }));
        setModules(parsedData);
      } catch (error) {
        console.error("Ошибка загрузки модулей:", error);
      }
    };

    fetchModules();
  }, []);

  return (
    <div style={{ marginTop: '4vh', marginBottom: '4vh', display: "flex", flexDirection: "column", alignItems: "center" }}>
        <h2>Available modules!</h2>
      {modules.map((module) => (
         <a
         href={`/ModuleUser/${module.id}`}
      
         style={{
            marginTop: '4vh',
            marginBottom: '4vh',
           display: "flex",
           alignItems: "center",
           justifyContent: "center",
           width: "400px",
           height: "200px",
           backgroundColor: "#f0f0f0", // цвет фона
           color: "#black", // цвет текста
           textDecoration: "none", // убираем стандартное подчеркивание ссылки
           textAlign: "center", 
           overflow: "hidden", 
           borderRadius: "15px", 
         }}
       >
         <div
           style={{
             width: "150px",
             height: "150px",
             borderRadius: "50%", 
             overflow: "hidden", 
             backgroundColor: "#fff", 
             marginRight: "4vw",
           }}
         >
           <img
             src={toBase64(stringToByteArray(module.image))}
             alt={module.name}
             style={{
               width: "100%",
               height: "100%", 
               textAlign: "center", 
             }}
           />
         </div>
         <div style={{ textAlign: "left" }}>
           <h3 style={{ margin: 0, fontSize: '1rem'}}>{module.name}</h3>
           <p style={{ margin: 0 }}>{module.description}</p>
         </div>
       </a>
      ))}
    </div>
  );
}
