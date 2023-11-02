import React, { useState } from 'react';

import styles from './Calculator.module.scss';

import { OperationButton } from './OperationButton';

export const Calculator = () => {
  const [inputX, setInputX] = useState('0');
  const [inputY, setInputY] = useState('0');
  const [answer, setAnswer] = useState('');

  const isDigitsValue = (value) => {
    return /^(-)?\d+/.test(value);
  };

  const handleInputChange = (e, setState) => {
    const value = processInputValue(e.target.value);
    setState(value);
  };

  const handleClipboardPaste = (setState) => {
    navigator.clipboard.readText().then((value) => {
      if (isDigitsValue(value)) {
        value = processInputValue(value);
        setState(value);
      }
    });
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
      const answer = determineAnswer(operationName, data.result);

      setAnswer(answer);
    } catch (error) {
      console.error('ОШИБКА:', error);
    }
  };

  const determineAnswer = (operationName, value) => {
    switch (operationName.toLowerCase()) {
      case 'greaterthan':
        return value ? 'Да, X больше Y' : 'Нет, X не больше Y';
      case 'lessthan':
        return value ? 'Да, X меньше Y' : 'Нет, X не меньше Y';
      case 'greaterthanorequalto':
        return value
          ? 'Да, X больше или равно Y'
          : 'Нет, X не больше или равно Y';
      case 'lessthanorequalto':
        return value
          ? 'Да, X меньше или равно Y'
          : 'Нет, X не меньше или равно Y';
      case 'equalto':
        return value ? 'Да, X равно Y' : 'Нет, X не равно Y';

      default:
        return value;
    }
  };

  const answerToInput = (setState) => {
    const value = isDigitsValue(answer) ? answer : '0';

    setState(value);
  };

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

  const operations = {
    add: () => performOperation('add'),
    subtract: () => performOperation('subtract'),
    multiply: () => performOperation('multiply'),
    divide: () => {
      if (parseInt(inputY) === 0) {
        alert('Нельзя делить на ноль.');
      } else {
        performOperation('divide');
      }
    },
    mod: () => {
      if (parseInt(inputY) === 0) {
        alert('Нельзя делить на ноль.');
      } else {
        performOperation('mod');
      }
    },
    factorial: () => {
      if (parseInt(inputX) > 5000) {
        setAnswer('Эта операция может занять очень много времени.');
      } else {
        performOperation('factorial');
      }
    },
    pow: () => {
      if (parseInt(inputX) === 0) {
        alert('Нельзя возвести нуль в степень.');
      } else {
        performOperation('pow');
      }
    },
    pow2: () => {
      if (parseInt(inputX) === 0) {
        alert('Нельзя возвести нуль в квадрат.');
      } else {
        performOperation('pow', { x: inputX, y: '2' });
      }
    },
    pow3: () => {
      if (parseInt(inputX) === 0) {
        alert('Нельзя возвести нуль в куб.');
      } else {
        performOperation('pow', { x: inputX, y: '3' });
      }
    },
    abs: () => performOperation('abs'),
    greaterThan: () => performOperation('greaterthan'),
    lessThan: () => performOperation('lessthan'),
    greaterThanOrEqualTo: () => performOperation('greaterthanorequalto'),
    lessThanOrEqualTo: () => performOperation('lessthanorequalto'),
    equalTo: () => performOperation('equalto'),
    isPrime: () => performOperation('isprime'),
    gcd: () => performOperation('gcd'),
    lcm: () => performOperation('lcm'),
  };

  const operationButtons = [
    { onClick: operations.add, text: 'x + y' },
    { onClick: operations.subtract, text: 'x - y' },
    { onClick: operations.factorial, text: 'x!' },
    { onClick: operations.pow2, text: 'x ^ 2' },
    { onClick: swapInputs, text: 'x <-> y', functional: true },
    { onClick: clearInputs, text: 'очистить', functional: true, remove: true },

    { onClick: operations.multiply, text: 'x * y' },
    { onClick: operations.divide, text: 'x / y' },
    { onClick: operations.mod, text: 'x % y' },
    { onClick: operations.pow3, text: 'x ^ 3' },
    { onClick: answerToX, text: 'ответ -> x', functional: true },
    {
      onClick: () => handleClipboardPaste(setInputX),
      text: 'буфер -> x',
      functional: true,
    },

    { onClick: operations.isPrime, text: 'простое?', disabled: true },
    { onClick: operations.gcd, text: 'НОД' },
    { onClick: operations.lcm, text: 'НОК' },
    { onClick: operations.pow, text: 'x ^ y' },
    { onClick: answerToY, text: 'ответ -> y', functional: true },
    {
      onClick: () => handleClipboardPaste(setInputY),
      text: 'буфер -> y',
      functional: true,
    },

    { onClick: operations.abs, text: '|x|' },
    { onClick: operations.greaterThan, text: 'x > y' },
    { onClick: operations.lessThan, text: 'x < y' },
    { onClick: operations.greaterThanOrEqualTo, text: 'x >= y' },
    { onClick: operations.lessThanOrEqualTo, text: 'x <= y' },
    { onClick: operations.equalTo, text: 'x == y' },
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
      isDigitsValue(answer) && (
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
