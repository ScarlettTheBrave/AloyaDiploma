"use client";
import React, { useState } from 'react';
import LectionForm from './LectionForm'; // Assuming LectionForm is in a separate file
import TextTestForm from './TextTestForm'; // Assuming TextTestForm is in a separate file

const ModuleCreationPage: React.FC = () => {
  const [moduleData, setModuleData] = useState<Module>({
    id: 0,
    name: '',
    description: '',
    colour: '',
    photo: '',
    lections: [],
    tests: []
  });

  const handleLectionChange = (index: number, lectionData: LectionData) => {
    const updatedLections = [...moduleData.lections];
    updatedLections[index] = lectionData;
    setModuleData({ ...moduleData, lections: updatedLections });
  };

  const handleTestChange = (index: number, testData: Test) => {
    const updatedTests = [...moduleData.tests];
    updatedTests[index] = testData;
    setModuleData({ ...moduleData, tests: updatedTests });
  };

  // Other functions remain unchanged

  return (
    <div>
      <h1>Create Module</h1>
      <form onSubmit={handleSubmit}>
        {/* Module details inputs */}
        {/* Lections section */}
        <div>
          <h2>Lections</h2>
          {moduleData.lections.map((lection, index) => (
            <LectionForm
              key={index}
              lectionData={lection}
              onChange={(data) => handleLectionChange(index, data)}
            />
          ))}
          <button type="button" onClick={addLection}>Add Lection</button>
        </div>
        {/* Tests section */}
        <div>
          <h2>Tests</h2>
          {moduleData.tests.map((test, index) => (
            <TextTestForm
              key={index}
              textTests={test.areaTests} // Assuming you want to use areaTests for text-based tests
              onChange={(data) => handleTestChange(index, { ...test, areaTests: data })}
            />
          ))}
          <button type="button" onClick={addTest}>Add Test</button>
        </div>
        <button type="submit">Create Module</button>
      </form>
    </div>
  );
};

export default ModuleCreationPage;