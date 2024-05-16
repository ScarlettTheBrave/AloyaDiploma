import React, { useEffect, useState } from 'react';
import { GetUser } from '../api/userOp';
import { stringToByteArray, toBase64 } from '../api/photo';

const AvatarWithLoader = () => {
  const [photoBase64, setPhotoBase64] = useState('');

  useEffect(() => {
    const avaGet = async () => {
      const userd = await GetUser(); // Предполагается, что GetUser() возвращает данные пользователя
      let byteString = userd.photo; // Предполагается, что userd.photo содержит строку base64 изображения
      let base64string = toBase64(stringToByteArray(byteString)); // Предполагается, что toBase64 и stringToByteArray функции определены
      setPhotoBase64(base64string || "none.jpg");
    };

    avaGet(); // Запускаем загрузку при монтировании компонента

    // Очистка эффекта не требуется, так как мы не подписываемся на внешние изменения
  }, []);

  return (
    <div style={{ 
        backgroundImage: `url(${photoBase64 || "none.jpg"})`, // Используем photoBase64 в качестве URL для изображения или "none.jpg", если фотография отсутствует
        backgroundSize: 'cover', // Растягиваем изображение на всю ширину и высоту блока
        backgroundPosition: 'center', // Центрируем изображение
        width: '2.5vw',
        marginTop: '2vh',
        height: '5vh',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        borderRadius: '50%', // Делаем элемент круглым
        border: '2px solid white' // Добавляем белую тонкую рамку
      }}>
      </div>
  );
};

export default AvatarWithLoader;