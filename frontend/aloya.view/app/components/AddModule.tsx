"use client";
import React from 'react';

interface CustomButtonsProps {
    handleButtonClick: (containerId: number) => void;
}

const CustomButtons: React.FC<CustomButtonsProps> = ({ handleButtonClick }) => {
    const handleInnerMouse = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.currentTarget.style.background = '#1c1c1b';
    }

    const handleInnerMouseLeave = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.currentTarget.style.background = '#000000';
    }

    const TwoFiveButton = {
        background: '#000000',
        height: '20vh',
        width: '25vw',
        marginRight: '0.7rem',
        fontSize: '2.5rem'
    }

    return (
        <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <div>
                <button onMouseOver={handleInnerMouse} onMouseLeave={handleInnerMouseLeave} onClick={() => handleButtonClick(5)} style={TwoFiveButton}>Lections</button>
            </div>
            <div>
                <button onMouseOver={handleInnerMouse} onMouseLeave={handleInnerMouseLeave} onClick={() => handleButtonClick(15)} style={TwoFiveButton}>Module</button>
            </div>
            <div>
                <button onMouseOver={handleInnerMouse} onMouseLeave={handleInnerMouseLeave} onClick={() => handleButtonClick(3)} style={TwoFiveButton}>Tests</button>
            </div>
        </div>
    );
};

export default CustomButtons;