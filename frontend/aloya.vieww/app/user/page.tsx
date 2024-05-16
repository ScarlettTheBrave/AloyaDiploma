"use client"
import { useState } from 'react';
import { Input, Typography, Button,Form } from 'antd';
import { handleSignUp } from '../api/login.js';
import AuthInput from '../components/TextInput';
import PasswordInput from '../components/PasswordInput';
export default function AuthPage() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [showErrorPopup, setShowErrorPopup] = useState(false);
    const [errorOccurred, setErrorOccurred] = useState(false);
    const [showSuccessPopup, setShowSuccessPopup] = useState(false);
    const [successOccurred,setSuccessOccurred] = useState(false);
    const handleError = (time: number | undefined) => {
      setShowErrorPopup(true);
      setErrorOccurred(true);
      setTimeout(() => {
        setShowErrorPopup(false);
        setErrorOccurred(false);
      }, time);
    };
    const handleSuccess = (time: number | undefined) => {
      setShowSuccessPopup(true);
      setSuccessOccurred(true);
      setTimeout(() => {
        setShowSuccessPopup(false);
        setSuccessOccurred(false);
      }, time);
    };
  const handleSignUpClick = async () => {
    try {
      var response = await handleSignUp(email, password);
      if (response === undefined) {
        handleError(5000);
        } else {
            handleSuccess(5000);
        }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  const handleEmailChange = (value: string) => {
    setEmail(value);
};

const handlePasswordChange = (value: string) => {
    setPassword(value);
};
  return (
    <div style={{background: 'white', display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
      <form style={{ display: 'flex', flexDirection: 'column' }} onSubmit={(e) => e.preventDefault()}> 
      <svg style={{ alignSelf: 'center' }}  width="5vh" height="5vh" viewBox="0 0 1024 1024" fill="#000000"   version="1.1" xmlns="http://www.w3.org/2000/svg">
        <path d="M981.534498 248.354447l-0.403282-2.01641c-0.403282-1.881982-0.940991-3.629537-1.747555-5.511519-0.134427-0.403282-0.268855-0.940991-0.537709-1.344273-0.940991-2.150837-2.01641-4.032819-3.226255-5.914802l-1.075419-1.4787c-1.075418-1.4787-2.150837-2.822973-3.49511-4.167246-0.403282-0.403282-0.806564-0.940991-1.209846-1.344274-1.613128-1.613128-3.360683-3.091828-5.242664-4.436101-0.268855-0.134427-0.672137-0.403282-0.940992-0.537709-1.209846-0.806564-2.419691-1.613128-3.763964-2.285264l-430.167378-215.083689c-11.426321-5.645947-24.734624-5.645947-36.026518 0l-430.167378 215.083689c-1.344273 0.672137-2.554119 1.4787-3.763964 2.285264-0.268855 0.134427-0.672137 0.403282-0.940991 0.537709-1.881982 1.344273-3.629537 2.822973-5.242665 4.436101-0.403282 0.403282-0.806564 0.806564-1.209846 1.344274-1.209846 1.344273-2.419691 2.688546-3.49511 4.167246l-1.075418 1.4787c-1.209846 1.881982-2.285264 3.898392-3.226256 5.914802-0.134427 0.403282-0.268855 0.940991-0.537709 1.344273-0.672137 1.747555-1.209846 3.629537-1.747555 5.511519l-0.403282 2.01641c-0.403282 2.419691-0.672136 4.839383-0.672136 7.259074v512.974598c0 15.324713 8.603348 29.170725 22.314932 36.026518l430.167378 215.083689c0.268855 0.134427 0.672137 0.268855 1.075419 0.403282 1.881982 0.940991 4.032819 1.613128 6.049228 2.150837 0.806564 0.268855 1.4787 0.537709 2.285265 0.672137 2.822973 0.672137 5.780374 1.075418 8.737774 1.075418s5.914801-0.403282 8.737775-1.075418c0.806564-0.134427 1.4787-0.537709 2.285265-0.672137 2.150837-0.537709 4.167246-1.344273 6.049228-2.150837 0.268855-0.134427 0.672137-0.268855 1.075419-0.403282l430.167377-215.083689a40.328192 40.328192 0 0 0 22.314933-36.026518V255.613521c-0.268855-2.419691-0.537709-4.839383-0.940991-7.259074zM511.711065 85.56298L851.677721 255.613521l-123.135412 61.567706-199.08684-97.728651c-0.268855-0.134427-0.672137-0.134427-0.940991-0.268854-1.747555-0.806564-3.629537-1.4787-5.511519-2.01641-0.806564-0.268855-1.613128-0.537709-2.554119-0.806564a45.705284 45.705284 0 0 0-6.183656-0.806564c-0.806564 0-1.613128-0.268855-2.419692-0.268854h-0.268854c-5.780374 0-11.291894 1.209846-16.265704 3.49511-0.134427 0-0.268855 0.134427-0.403282 0.134427L287.351892 313.417263 171.744409 255.613521 511.711065 85.56298z m0 596.453955l-139.132261-69.498917 138.728979-77.967837 136.443715 79.446537L511.711065 682.016935zM688.482972 387.352281v157.14552L552.039257 464.916836V320.407483l136.443715 66.944798zM471.382873 464.513554l-144.509353 81.194093V384.126026L471.382873 318.256646v146.256908zM121.871879 512.10082V320.810765l124.345258 62.239842V614.534427c0 0.672137 0.134427 1.344273 0.268854 2.150837l0.403282 4.301674 0.806564 3.898392c0.268855 1.209846 0.672137 2.419691 1.075418 3.629537 0.537709 1.344273 1.075418 2.688546 1.747555 4.032819 0.268855 0.672137 0.537709 1.209846 0.806564 1.881983 0.134427 0.403282 0.537709 0.537709 0.672137 0.940991 1.613128 2.822973 3.49511 5.377092 5.780374 7.662356l0.403282 0.403282a42.075747 42.075747 0 0 0 9.678766 6.99022c0.537709 0.268855 0.940991 0.537709 1.4787 0.806564 0.403282 0.134427 0.672137 0.403282 0.940991 0.672136L471.382873 752.053561V918.340138l-349.510994-174.755497V512.10082zM901.550251 743.584641l-349.510994 174.755497V752.053561l194.785166-97.325369a40.287863 40.287863 0 0 0 22.180505-38.849492c0-0.403282 0.134427-0.806564 0.134427-1.209845V387.083426L901.550251 320.810765V743.584641z" />
      xmlns=2544
      </svg>
        <span style={{fontFamily: 'Roboto, sans-serif',  textAlign: 'center', fontWeight: 'bolder', fontSize: '3vh',marginTop: '1vh', marginBottom: '1vh' }}>Welcome</span>
        <span style={{fontFamily: 'Roboto, sans-serif',  textAlign: 'center', fontWeight: 'lighter', fontSize: '2vh', marginBottom: '5vh' }}>Log in to Aloya </span>
        <AuthInput 
                    fieldsetStyles={{marginTop: '3vh'}}
                    ald='email'
                    legendPar='Email'
                    onChange={handleEmailChange}> 
                </AuthInput>
                <PasswordInput 
                    fieldsetStyles={{marginTop: '3vh'}}
                    ald='password'
                    legendPar='Password'
                    onChange={handlePasswordChange}>
                </PasswordInput>
        <Button type="primary" style={{background: 'black',height: '8vh',marginTop: '3vh', marginBottom: '2vh' }} onClick={handleSignUpClick}>Log In</Button>
        <div style={{ fontFamily: 'Roboto, sans-serif', textAlign: 'center' }}>
          <span>Not registered yet?</span>
          <a href="/register" style={{ marginLeft: '5px', textDecoration: 'underline', color: '#1890ff' }}>Sign Up</a>
        </div>
      </form>
      {showErrorPopup && (
        <div style={{ position: 'absolute', top: '15%', left: '80%', transform: 'translate(-50%, -50%)', background: 'red', padding: '20px', borderRadius: '5px', color: 'white', zIndex: 9999 }}>
        Bad Auth
      </div>
      )}
       {showSuccessPopup && (
        <div style={{ position: 'absolute', top: '15%', left: '80%', transform: 'translate(-50%, -50%)', background: 'green', padding: '20px', borderRadius: '5px', color: 'white', zIndex: 9999 }}>
        Success!
      </div>
      )}
    </div>
  );
}
