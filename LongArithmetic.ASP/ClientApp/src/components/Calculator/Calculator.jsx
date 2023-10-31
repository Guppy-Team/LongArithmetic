import React, { useState } from 'react';

import styles from './Calculator.module.scss';

import { OperationButton } from './OperationButton';

export const Calculator = () => {
  const [inputX, setInputX] = useState('0');
  const [inputY, setInputY] = useState('0');
  const [answer, setAnswer] = useState('');

  const handleInputChange = (e, setState) => {
    let value = e.target.value;

    if (value.indexOf('-') === 0) {
      value = '-' + value.replace(/-/g, '');
    } else {
      value = value.replace(/-/g, '');
    }

    value = value.replace(/[^\d-]/g, '');

    setState(value);
  };

  const performOperation = async (
    operationName,
    body = { x: inputX, y: inputY },
  ) => {
    try {
      const response = await fetch(`api/${operationName}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(body),
      });

      const data = await response.json();
      setAnswer(data.result);
    } catch (error) {
      console.error('ОШИБКА:', error);
    }
  };

  const addOperation = () => {
    performOperation('add');
  };

  const subtractOperation = () => {
    performOperation('subtract');
  };

  const multiplyOperation = () => {
    performOperation('multiply');
  };

  const divideOperation = () => {
    performOperation('divide');
  };

  const powOperation = () => {
    performOperation('pow');
  };

  const pow2Operation = () => {
    performOperation('pow', { x: inputX, y: '2' });
  };

  const pow3Operation = () => {
    performOperation('pow', { x: inputX, y: '3' });
  };

  const factorialOperation = () => {
    performOperation('factorial');
  };

  const modOperation = () => {
    performOperation('mod');
  };

  const gcdOperation = () => {
    performOperation('gcd');
  };

  const lcmOperation = () => {
    performOperation('lcm');
  };

  const isPrime = () => {
    performOperation('isprime', { x: inputX });
  };

  const absOperation = () => {
    performOperation('abs', { x: inputX });
  };

  const greaterThan = () => {
    performOperation('greaterthan');
  };

  const lessThan = () => {
    performOperation('lessthan');
  };

  const greaterThanOrEqualTo = () => {
    performOperation('greaterthanorequalto');
  };

  const lessThanOrEqualTo = () => {
    performOperation('lessthanorequalto');
  };

  const equalTo = () => {
    performOperation('equalto');
  };

  const answerToX = () => {
    if (answer === '') {
      setInputX('0');
    } else {
      setInputX(answer);
    }
  };

  const answerToY = () => {
    if (answer === '') {
      setInputY('0');
    } else {
      setInputY(answer);
    }
  };

  const swapInputs = () => {
    setInputX(inputY);
    setInputY(inputX);
  };

  const clearInputs = () => {
    setInputX('0');
    setInputY('0');
    setAnswer('');
  };

  const operationButtons = [
    { onClick: addOperation, text: 'x + y' },
    { onClick: subtractOperation, text: 'x - y' },
    { onClick: factorialOperation, text: 'x!', disabled: true },
    { onClick: pow2Operation, text: 'x ^ 2' },
    { onClick: swapInputs, text: 'x <-> y', functional: true },
    { onClick: clearInputs, text: 'очистить', functional: true, remove: true },

    { onClick: multiplyOperation, text: 'x * y' },
    { onClick: divideOperation, text: 'x / y' },
    { onClick: modOperation, text: 'mod', disabled: true },
    { onClick: pow3Operation, text: 'x ^ 3' },
    { onClick: answerToX, text: 'ответ -> x', functional: true },
    { onClick: () => console.log('тык'), text: 'буфер -> x', functional: true },

    { onClick: isPrime, text: 'простое?', disabled: true },
    { onClick: gcdOperation, text: 'НОД', disabled: true },
    { onClick: lcmOperation, text: 'НОК', disabled: true },
    { onClick: powOperation, text: 'x ^ y' },
    { onClick: answerToY, text: 'ответ -> y', functional: true },
    { onClick: () => console.log('тык'), text: 'буфер -> y', functional: true },

    { onClick: absOperation, text: '|x|' },
    { onClick: greaterThan, text: 'x > y' },
    { onClick: lessThan, text: 'x < y' },
    { onClick: greaterThanOrEqualTo, text: 'x >= y' },
    { onClick: lessThanOrEqualTo, text: 'x <= y' },
    { onClick: equalTo, text: 'x == y' },
  ];

  return (
    <div className={styles.root}>
      <div className={styles.label}>x =</div>
      <textarea
        className={styles.input}
        value={inputX}
        onChange={(e) => handleInputChange(e, setInputX)}
      />

      <div className={styles.label}>y =</div>
      <textarea
        className={styles.input}
        value={inputY}
        onChange={(e) => handleInputChange(e, setInputY)}
      />

      <div className={styles.buttonsWrapper}>
        {operationButtons.map((obj) => (
          <OperationButton key={obj.text} {...obj} />
        ))}
      </div>

      <div className={styles.label}>ответ =</div>
      <textarea
        className={styles.input}
        readOnly
        value={answer}
        onChange={(e) => setAnswer(e.target.value)}
      />
      {answer && (
        <p className={styles.digitsCount}>
          {answer.length} {answer.length === 1 ? 'digit' : 'digits'}
        </p>
      )}
    </div>
  );
};
