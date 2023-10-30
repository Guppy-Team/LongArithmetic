import React, { useState } from 'react';

import styles from './Calculator.module.scss';

import { OperationButton } from './OperationButton';

export const Calculator = () => {
  const [xInput, setXInput] = useState(0);
  const [yInput, setYInput] = useState(0);
  const [answer, setAnswer] = useState('');

  const addOperation = async () => {
    const response = await fetch('api/add', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ x: xInput, y: yInput }),
    });

    const data = await response.json();

    setAnswer(data.result);
  };

  const subtractOperation = async () => {
    const response = await fetch('api/subtract', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ x: xInput, y: yInput }),
    });

    const data = await response.json();

    setAnswer(data.result);
  };

  const multiplyOperation = async () => {
    const response = await fetch('api/multiply', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ x: xInput, y: yInput }),
    });

    const data = await response.json();

    setAnswer(data.result);
  };

  const divideOperation = async () => {
    const response = await fetch('api/divide', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ x: xInput, y: yInput }),
    });

    const data = await response.json();

    setAnswer(data.result);
  };

  const answerToX = () => {
    setXInput(answer);
  };

  const answerToY = () => {
    setYInput(answer);
  };

  const swapInputs = () => {
    const buffer = xInput;
    setXInput(yInput);
    setYInput(buffer);
  };

  const clearInputs = () => {
    setXInput(0);
    setYInput(0);
    setAnswer('');
  };

  return (
    <div className={styles.root}>
      <div className={styles.label}>x =</div>
      <textarea
        className={styles.input}
        value={xInput}
        onChange={(e) => setXInput(e.target.value)}
      />

      <div className={styles.label}>y =</div>
      <textarea
        className={styles.input}
        value={yInput}
        onChange={(e) => setYInput(e.target.value)}
      />

      <div className={styles.buttonsWrapper}>
        <OperationButton onClick={addOperation} text="x + y" />
        <OperationButton onClick={subtractOperation} text="x - y" />
        <OperationButton text="x!" disabled />
        <OperationButton text="x ^ 2" disabled />
        <OperationButton onClick={swapInputs} text="x <-> y" functional />
        <OperationButton
          onClick={clearInputs}
          text="очистить"
          functional
          remove
        />

        <OperationButton onClick={multiplyOperation} text="x * y" />
        <OperationButton onClick={divideOperation} text="x / y" />
        <OperationButton text="mod" disabled />
        <OperationButton text="x ^ 3" disabled />
        <OperationButton onClick={answerToX} text="ответ -> x" functional />
        <OperationButton text="буфер -> x" functional />

        <OperationButton text="простое?" disabled />
        <OperationButton text="НОД" disabled />
        <OperationButton text="НОК" disabled />
        <OperationButton text="x ^ y" disabled />
        <OperationButton onClick={answerToY} text="ответ -> y" functional />
        <OperationButton text="буфер -> y" functional />

        <OperationButton text="|x|" disabled />
        <OperationButton text="x > y" disabled />
        <OperationButton text="x < y" disabled />
        <OperationButton text="x >= 2" disabled />
        <OperationButton text="x <= y" disabled />
        <OperationButton text="x == y" disabled />
      </div>

      <div className={styles.label}>ответ =</div>
      <textarea
        className={styles.input}
        value={answer}
        onChange={(e) => setAnswer(e.target.value)}
      />
    </div>
  );
};
