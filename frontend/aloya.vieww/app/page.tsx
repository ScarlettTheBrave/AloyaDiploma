"use client";
import React, { useState, useEffect } from 'react';

export default function Home() {
  const [currentSlide, setCurrentSlide] = useState(0);
  const slides1 = [
    { key: 'image1', value: '/photo1.jpeg' },
    { key: 'image2', value: '/photo2.jpg' },
    { key: 'image3', value: '/photo3.png' }
  ];
  const slides2 = [
    { key: 'image1', value: '/photo4.jpg' },
    { key: 'image2', value: '/photo5.jpg' },
    { key: 'image3', value: '/photo6.jpg' }
  ];
  const slides3 = [
    { key: 'image1', value: '/photo7.jpg' },
    { key: 'image2', value: '/photo8.jpg' },
    { key: 'image3', value: '/photo9.jpg' }
  ];

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentSlide((prevSlide) => (prevSlide + 1) % slides1.length);
    }, 2500);
  
    return () => clearInterval(interval);
  }, [slides1.length]);
  
  return (
    <div>
      <div style={{marginTop: '5vh', display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
      <svg style={{ alignSelf: 'center', marginBottom: '-0.7vh', marginRight: '1vh' }}  width="10vh" height="10vh" viewBox="0 0 1024 1024" fill="#00000"   version="1.1" xmlns="http://www.w3.org/2000/svg">
            <path d="M981.534498 248.354447l-0.403282-2.01641c-0.403282-1.881982-0.940991-3.629537-1.747555-5.511519-0.134427-0.403282-0.268855-0.940991-0.537709-1.344273-0.940991-2.150837-2.01641-4.032819-3.226255-5.914802l-1.075419-1.4787c-1.075418-1.4787-2.150837-2.822973-3.49511-4.167246-0.403282-0.403282-0.806564-0.940991-1.209846-1.344274-1.613128-1.613128-3.360683-3.091828-5.242664-4.436101-0.268855-0.134427-0.672137-0.403282-0.940992-0.537709-1.209846-0.806564-2.419691-1.613128-3.763964-2.285264l-430.167378-215.083689c-11.426321-5.645947-24.734624-5.645947-36.026518 0l-430.167378 215.083689c-1.344273 0.672137-2.554119 1.4787-3.763964 2.285264-0.268855 0.134427-0.672137 0.403282-0.940991 0.537709-1.881982 1.344273-3.629537 2.822973-5.242665 4.436101-0.403282 0.403282-0.806564 0.806564-1.209846 1.344274-1.209846 1.344273-2.419691 2.688546-3.49511 4.167246l-1.075418 1.4787c-1.209846 1.881982-2.285264 3.898392-3.226256 5.914802-0.134427 0.403282-0.268855 0.940991-0.537709 1.344273-0.672137 1.747555-1.209846 3.629537-1.747555 5.511519l-0.403282 2.01641c-0.403282 2.419691-0.672136 4.839383-0.672136 7.259074v512.974598c0 15.324713 8.603348 29.170725 22.314932 36.026518l430.167378 215.083689c0.268855 0.134427 0.672137 0.268855 1.075419 0.403282 1.881982 0.940991 4.032819 1.613128 6.049228 2.150837 0.806564 0.268855 1.4787 0.537709 2.285265 0.672137 2.822973 0.672137 5.780374 1.075418 8.737774 1.075418s5.914801-0.403282 8.737775-1.075418c0.806564-0.134427 1.4787-0.537709 2.285265-0.672137 2.150837-0.537709 4.167246-1.344273 6.049228-2.150837 0.268855-0.134427 0.672137-0.268855 1.075419-0.403282l430.167377-215.083689a40.328192 40.328192 0 0 0 22.314933-36.026518V255.613521c-0.268855-2.419691-0.537709-4.839383-0.940991-7.259074zM511.711065 85.56298L851.677721 255.613521l-123.135412 61.567706-199.08684-97.728651c-0.268855-0.134427-0.672137-0.134427-0.940991-0.268854-1.747555-0.806564-3.629537-1.4787-5.511519-2.01641-0.806564-0.268855-1.613128-0.537709-2.554119-0.806564a45.705284 45.705284 0 0 0-6.183656-0.806564c-0.806564 0-1.613128-0.268855-2.419692-0.268854h-0.268854c-5.780374 0-11.291894 1.209846-16.265704 3.49511-0.134427 0-0.268855 0.134427-0.403282 0.134427L287.351892 313.417263 171.744409 255.613521 511.711065 85.56298z m0 596.453955l-139.132261-69.498917 138.728979-77.967837 136.443715 79.446537L511.711065 682.016935zM688.482972 387.352281v157.14552L552.039257 464.916836V320.407483l136.443715 66.944798zM471.382873 464.513554l-144.509353 81.194093V384.126026L471.382873 318.256646v146.256908zM121.871879 512.10082V320.810765l124.345258 62.239842V614.534427c0 0.672137 0.134427 1.344273 0.268854 2.150837l0.403282 4.301674 0.806564 3.898392c0.268855 1.209846 0.672137 2.419691 1.075418 3.629537 0.537709 1.344273 1.075418 2.688546 1.747555 4.032819 0.268855 0.672137 0.537709 1.209846 0.806564 1.881983 0.134427 0.403282 0.537709 0.537709 0.672137 0.940991 1.613128 2.822973 3.49511 5.377092 5.780374 7.662356l0.403282 0.403282a42.075747 42.075747 0 0 0 9.678766 6.99022c0.537709 0.268855 0.940991 0.537709 1.4787 0.806564 0.403282 0.134427 0.672137 0.403282 0.940991 0.672136L471.382873 752.053561V918.340138l-349.510994-174.755497V512.10082zM901.550251 743.584641l-349.510994 174.755497V752.053561l194.785166-97.325369a40.287863 40.287863 0 0 0 22.180505-38.849492c0-0.403282 0.134427-0.806564 0.134427-1.209845V387.083426L901.550251 320.810765V743.584641z" />
            xmlns=2544
          </svg>
      </div>
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        <h1 style={{ marginTop: '2%',fontSize: '190%', fontFamily: 'Montserrat, sans-serif' }}>Welcome to the Aloya!</h1>
      </div>
      <div style={{ marginBottom: '0vh', display: 'flex', flexDirection: 'column', alignItems: 'center',  margin: '0 2%', maxWidth: '100%' }}>
        <p style={{ fontWeight: 'bolder', marginTop: '2%', fontSize: '150%', textAlign: 'center', maxHeight: '80%', maxWidth: '100%', fontFamily: 'Montserrat, sans-serif' }}>
          Test your knowledges in different spheras!
        </p>
      </div>
      <div style={{ marginBottom: '-10vh',marginTop: '-5vh' ,padding: '0px',height: '130%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center', minHeight: '70vh' }}>
        <div style={{ width: '90%', maxWidth: '1600vh', marginBottom: '20px', display: 'flex', flexDirection: 'row' }}>
          <div style={{ flex: '1', width: '1000px', height: '40%', overflow: 'hidden', position: 'relative', margin: '0 2%' }}>
            <div className="slider" style={{ display: 'flex', transition: 'transform 0.5s ease-in-out', transform: `translateX(-${currentSlide * 100}%)` }}>
              {slides1.map((slide, index) => (
                <img key={index} src={slide.value} alt={slide.key} style={{ maxHeight: '30vh', minWidth: '100%', objectFit: 'cover' }} />
              ))}
            </div>
            <div style={{ width: '100%', flex: '1', display: 'flex', alignItems: 'center' }}>
              <p style={{ background: 'black', color: 'white', textAlign: 'center', fontWeight: 'bolder', fontFamily: 'Montserrat, sans-serif', fontSize: '100%' }}>
                Welcome to our virtual realm, where imagination meets reality through the lens of 3D modeling.
                Dive into a world where creativity knows no bounds and innovation thrives in every pixel.
                Our site is your ultimate testing ground.
              </p>
            </div>
          </div>
          <div style={{ marginLeft: '10vh', flex: '1', width: '60%', height: '60%', overflow: 'hidden', position: 'relative', margin: '0 2%' }}>
            <div className="slider" style={{ width: '100%', height: '20%', display: 'flex', transition: 'transform 0.5s ease-in-out', transform: `translateX(-${currentSlide * 100}%)` }}>
              {slides2.map((slide, index) => (
                <img key={index} src={slide.value} alt={slide.key} style={{ maxHeight: '30vh', minWidth: '100%', objectFit: 'cover' }} />
              ))}
            </div>
            <div style={{ width: '100%', height: '100%', flex: '1', display: 'flex', alignItems: 'center' }}>
              <p style={{ background: 'black', color: 'white', textAlign: 'center', fontWeight: 'bolder', fontFamily: 'Montserrat, sans-serif', fontSize: '100%' }}>
                Dive into a vibrant world of architectural modeling, where every structure comes to life in a symphony of creativity and precision. 
                Test your skills in 3D architecture modeling. We can use different interactive methods.
              </p>
            </div>
          </div>
          <div style={{ marginLeft: '10vh', flex: '1', width: '200vh', height: '20%', overflow: 'hidden', position: 'relative', margin: '0 2%' }}>
            <div className="slider" style={{height: '10%', display: 'flex', transition: 'transform 0.5s ease-in-out', transform: `translateX(-${currentSlide * 100}%)` }}>
              {slides3.map((slide, index) => (
                <img key={index} src={slide.value} alt={slide.key} style={{ maxHeight: '30vh', minWidth: '100%', objectFit: 'cover' }} />
              ))}
            </div>
            <div style={{ width: '100%', height: '100%', flex: '1', display: 'flex', alignItems: 'center' }}>
              <p style={{ width: '100%', height: '100%', background: 'black', color: 'white', textAlign: 'center', fontWeight: 'bolder', fontFamily: 'Montserrat, sans-serif', fontSize: '100%' }}>
                Test your skills in material 3D modeling without payments and recordings in our system. Get knowledge about your capabilities. We can study you to understand essentials in material design and structure in modeling.
              </p>
            </div>
          </div>
        </div>
      </div>
      <div style={{ marginBottom: '15vh', display: 'flex', flexDirection: 'column', alignItems: 'center',  margin: '0 2%', maxWidth: '100%' }}>
        <p style={{ fontWeight: 'bolder', marginTop: '0%', fontSize: '110%', textAlign: 'center', maxHeight: '50%', maxWidth: '90%', fontFamily: 'Montserrat, sans-serif' }}>"Aloya Testing" is an innovative platform designed to revolutionize the testing experience. Through Aloya, users embark on a journey of exploration, where every click unlocks a new realm of possibilities. 
        With its intuitive interface, Aloya simplifies the testing process, making it accessible to both beginners and experts alike. The platform offers a diverse range of testing scenarios, from simple quizzes to complex simulations, catering to various skill levels and interests.</p>
      </div>
      <div style={{ marginBottom: '5vh'}}>
        
      </div>
    </div>
  );
}