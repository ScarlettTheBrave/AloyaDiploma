export const toByte = (base64str) => {
    // Проверяем, содержит ли строка запятую и префикс base64-данных
    const commaIndex = base64str.indexOf(',');
    
    // Если запятая и префикс найдены, продолжаем выполнение кода
    if (commaIndex !== -1 && base64str.startsWith('data:image')) {
        // Извлекаем часть строки после запятой и декодируем её
        const byteCharacters = atob(base64str.substring(commaIndex + 1));
        const byteArray = [];
        for (let i = 0; i < byteCharacters.length; i++) {
            byteArray.push(byteCharacters.charCodeAt(i));
        }
        return byteArray;
    } else {
        // Если запятая или префикс не найдены, возвращаем пустой массив
        return [];
    }
};

export const toBase64 = (byteArray) => {
    const byteString = String.fromCharCode.apply(null, byteArray);
    const base64String = 'data:image/png;base64,' + btoa(byteString);
    return base64String;
};
export const byteArrayToString = (byteArray) => {
    let result = '';
    let i = 0;
    while (i < byteArray.length) {
        const byte = byteArray[i++];
        if (byte < 0x80) {
            result += String.fromCharCode(byte);
        } else if (byte >= 0xC0 && byte < 0xE0) {
            const byte2 = byteArray[i++];
            result += String.fromCharCode(((byte & 0x1F) << 6) | (byte2 & 0x3F));
        } else if (byte >= 0xE0 && byte < 0xF0) {
            const byte2 = byteArray[i++];
            const byte3 = byteArray[i++];
            result += String.fromCharCode(((byte & 0xF) << 12) | ((byte2 & 0x3F) << 6) | (byte3 & 0x3F));
        } else if (byte >= 0xF0 && byte < 0xF8) {
            const byte2 = byteArray[i++];
            const byte3 = byteArray[i++];
            const byte4 = byteArray[i++];
            const codePoint = (((byte & 0x7) << 18) | ((byte2 & 0x3F) << 12) | ((byte3 & 0x3F) << 6) | (byte4 & 0x3F)) - 0x10000;
            result += String.fromCharCode((codePoint >> 10) | 0xD800, (codePoint & 0x3FF) | 0xDC00);
        }
    }
    return result;
};

export const stringToByteArray = (str) => {
    var numbers = str.split(',').map(Number);
    var byteArray = []; // Initialize byteArray as an empty array
    numbers.forEach(function(element) {
        byteArray.push(element);
    });
    return byteArray;
};