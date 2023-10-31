import React, { useState } from 'react';

import styles from './Calculator.module.scss';

import { OperationButton } from './OperationButton';

export const Calculator = () => {
  const [inputX, setInputX] = useState('0');
  const [inputY, setInputY] = useState('0');
  const [answer, setAnswer] = useState('');

  const handleInputChange = (e, setState) => {
    let value = e.target.value;
    value = processInputValue(value);
    setState(value);
  };

  const handleClipboardPaste = (setState) => {
    navigator.clipboard.readText().then((value) => {
      if (containsNumericValue(value)) {
        value = processInputValue(value);
        setState(value);
      }
    });
  };

  const containsNumericValue = (value) => {
    return /\d/.test(value);
  };

  const processInputValue = (value) => {
    if (value.indexOf('-') === 0) {
      value = '-' + value.replace(/-/g, '');
    } else {
      value = value.replace(/-/g, '');
    }
    value = value.replace(/[^\d-]/g, '');
    return value;
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

      if (typeof data.result === 'boolean') {
        if (operationName === 'greaterthan') {
          setAnswer(data.result ? `Да, X больше Y` : `Нет, X не больше Y`);
        } else if (operationName === 'lessthan') {
          setAnswer(data.result ? `Да, X меньше Y` : `Нет, X не меньше Y`);
        } else if (operationName === 'greaterthanorequalto') {
          setAnswer(
            data.result
              ? `Да, X больше или равно Y`
              : `Нет, X не больше или равно Y`,
          );
        } else if (operationName === 'lessthanorequalto') {
          setAnswer(
            data.result
              ? `Да, X меньше или равно Y`
              : `Нет, X не меньше или равно Y`,
          );
        } else if (operationName === 'equalto') {
          setAnswer(data.result ? `Да, X равно Y` : `Нет, X не равно Y`);
        }
      } else {
        setAnswer(data.result);
      }
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
    if (parseInt(inputY) === 0) {
      alert('Нельзя делить на ноль.');
    } else {
      performOperation('divide');
    }
  };

  const powOperation = () => {
    if (parseInt(inputX) === 0) {
      alert('Нельзя возвести нуль в степень.');
    } else {
      performOperation('pow');
    }
  };

  const pow2Operation = () => {
    if (parseInt(inputX) === 0) {
      alert('Нельзя возвести нуль в квадрат.');
    } else {
      performOperation('pow', { x: inputX, y: '2' });
    }
  };

  const pow3Operation = () => {
    if (parseInt(inputX) === 0) {
      alert('Нельзя возвести нуль в куб.');
    } else {
      performOperation('pow', { x: inputX, y: '3' });
    }
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

  const answerToInput = (setState) => {
    const regex = /^(-)?\d+/;

    if (answer === '') {
      setState('0');
    } else if (regex.test(answer)) {
      setState(answer);
    } else {
      setState('0');
    }
  };

  // Примените эти функции к inputX и inputY
  const answerToX = () => {
    answerToInput(setInputX);
  };

  const answerToY = () => {
    answerToInput(setInputY);
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
    {
      onClick: () => handleClipboardPaste(setInputX),
      text: 'буфер -> x',
      functional: true,
    },

    { onClick: isPrime, text: 'простое?', disabled: true },
    { onClick: gcdOperation, text: 'НОД', disabled: true },
    { onClick: lcmOperation, text: 'НОК', disabled: true },
    { onClick: powOperation, text: 'x ^ y' },
    { onClick: answerToY, text: 'ответ -> y', functional: true },
    {
      onClick: () => handleClipboardPaste(setInputY),
      text: 'буфер -> y',
      functional: true,
    },

    { onClick: absOperation, text: '|x|' },
    { onClick: greaterThan, text: 'x > y' },
    { onClick: lessThan, text: 'x < y' },
    { onClick: greaterThanOrEqualTo, text: 'x >= y' },
    { onClick: lessThanOrEqualTo, text: 'x <= y' },
    { onClick: equalTo, text: 'x == y' },
  ];

  const digitsCounter = () => {
    const words = ['цифра', 'цифры', 'цифр'];
    let adjustedLength = answer.length;
    const cases = [2, 0, 1, 1, 1, 2];

    if (answer.includes('-')) {
      adjustedLength--;
    }

    const nounIndex = [
      adjustedLength % 100 > 4 && adjustedLength % 100 < 20
        ? 2
        : cases[adjustedLength % 10 < 5 ? adjustedLength % 10 : 5],
    ];

    return (
      /^(-)?\d+$/.test(answer) && (
        <p className={styles.digitsCount}>
          {adjustedLength} {words[nounIndex]}
        </p>
      )
    );
  };

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
      {digitsCounter()}
    </div>
  );
};
