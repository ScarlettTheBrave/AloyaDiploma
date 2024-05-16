"use client";
import React, { useState } from 'react';
import { EyeOutlined, EyeInvisibleOutlined } from '@ant-design/icons';
interface Props {
    fieldsetStyles?: React.CSSProperties;
    legendStyles?: React.CSSProperties;
    inputStyles?: React.CSSProperties;
    legendPar?: string;
    ald: string;
    onChange?: (value: string) => void;
}

const PasswordInput: React.FC<Props> = ({
    fieldsetStyles = {},
    legendStyles = {},
    inputStyles = {},
    legendPar = "Example",
    onChange
}) => {
    const [isInputFocused, setIsInputFocused] = useState(false);
    const [isEmpty, setIsEmpty] = useState(true);
    const [showPassword, setShowPassword] = useState(false);
    const [inputValue, setInputValue] = useState('');

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

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
        width: '35vh',
        marginLeft: '1.35vh',
        outline: 'none',
        paddingRight: '3.5vh',
        ...inputStyles
    };

    return (
        <fieldset style={fieldsetStyle}>
            <legend style={legendStyle}>{legendPar}</legend>
            <div style={{ position: 'relative' }}>
                <input
                    type={showPassword ? 'text' : 'password'}
                    placeholder={legendPar}
                    style={inputStyle}
                    onFocus={() => setIsInputFocused(true)}
                    onBlur={() => setIsInputFocused(false)}
                    onChange={handleChange}
                />
                <div style={{ position: 'absolute', right: '1.25vh', top: '2.5vh' }} onClick={togglePasswordVisibility}>
                    {showPassword ? <EyeOutlined style={{color: isInputFocused? '#1890ff' : 'gray'}}/> : <EyeInvisibleOutlined style={{color: isInputFocused? '#1890ff' : 'gray'}}/>}
                </div>
            </div>
        </fieldset>
    );
};

export default PasswordInput;