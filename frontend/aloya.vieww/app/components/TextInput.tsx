"use client";
import React, { useState } from 'react';

interface Props {
    fieldsetStyles?: React.CSSProperties;
    legendStyles?: React.CSSProperties;
    inputStyles?: React.CSSProperties;
    legendPar?: string;
    ald: string;
    onChange?: (value: string) => void;
}

const AuthInput: React.FC<Props> = ({ 
    fieldsetStyles = {},
    legendStyles = {},
    inputStyles = {},
    legendPar = "Example",
    ald,
    onChange
}) => {
    const [isInputFocused, setIsInputFocused] = useState(false);
    const [isEmpty, setIsEmpty] = useState(true);
    const [inputValue, setInputValue] = useState('');

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = event.target.value;
        setInputValue(newValue);
        setIsEmpty(newValue === '');

        if (onChange) {
            onChange(newValue);
        }
    };

    const fieldsetStyle: React.CSSProperties = {
        width: '43vh',
        height: '8vh',
        borderColor: isInputFocused ? '#1890ff' : 'gray',
        borderStyle: 'solid',
        borderWidth: '0.25vh',
        borderRadius: '1.75vh',
        boxShadow: isInputFocused ? '0 0 5px rgba(107, 184, 255, 0.5)' : 'none',
        position: 'relative',
        ...fieldsetStyles
    };

    const legendStyle: React.CSSProperties = {
        visibility: isEmpty ? 'hidden' : 'visible',
        position: 'absolute',
        background: 'White',
        marginRight: '1.5vh',
        marginLeft: '2.5vh',
        marginTop: '-1.5vh',
        paddingBottom: '0.5vh',
        paddingRight: '0.6vh',
        paddingLeft: '0.6vh',
        color: isInputFocused ? '#1890ff' : 'gray',
        ...legendStyles
    };

    const inputStyle: React.CSSProperties = {
        background: 'rgba(0, 0, 0, 0)',
        marginTop: '1vh',
        color: 'black',
        border: 'none',
        height: '6vh',
        width: '40vh',
        marginLeft: '1.35vh',
        outline: 'none',
        ...inputStyles
    };

    return (
        <fieldset style={fieldsetStyle}>
            <legend style={legendStyle}>{legendPar}</legend>
            <input
                placeholder={legendPar}
                style={inputStyle}
                value={inputValue}
                onFocus={() => setIsInputFocused(true)}
                onBlur={() => setIsInputFocused(false)}
                onChange={handleChange}
            />
        </fieldset>
    );
};

export default AuthInput;