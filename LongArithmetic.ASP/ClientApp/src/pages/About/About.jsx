import React from 'react';

import { OperationButton } from '../../components/Calculator/OperationButton';

import styles from './About.module.scss';

export const About = () => {
  const operations = [
    { text: 'x + y', descr: 'сложение' },
    { text: 'x * y', descr: 'умножение' },
    { text: 'x - y', descr: 'вычитание' },
    { text: 'x / y', descr: 'целочисленное деление' },
    { text: 'x ^ y', descr: 'возведение числа X в степень Y' },
    { text: 'x!', descr: 'считает факториал числа X' },
    { text: 'mod', descr: 'вычисление остатка от деления числа X на Y' },
    { text: '|x|', descr: 'возвращает число X по модулю' },
    { text: 'НОД', descr: 'ищет Наибольший общий делитель' },
    { text: 'простое?', descr: 'проверяет, является ли число X простым' },
    { text: 'НОК', descr: 'ищет Наименьший общее кратное' },
    { text: 'x == y', descr: 'проверяет, равно ли число X числу Y' },
    { text: 'x > y', descr: 'проверяет, больше ли число X числа Y' },
    {
      text: 'x >= y',
      descr: 'проверяет, больше или равно ли число X числа Y',
    },
    { text: 'x < y', descr: 'проверяет, меньше ли число X числа Y' },
    {
      text: 'x <= y',
      descr: 'проверяет, меньше или равно ли число X числа Y',
    },
  ];

  const functions = [
    {
      text: 'x <-> y',
      descr: 'меняет местами значения из полей X и Y',
      functional: true,
    },
    {
      text: 'очистить',
      descr: 'очищает поля X, Y и Ответ',
      functional: true,
      remove: true,
    },
    {
      text: 'ответ -> x',
      descr: 'помещает значение из ответа в после X',
      functional: true,
    },
    {
      text: 'буфер -> x',
      descr: 'помещает значение из буфера обмена в после X',
      functional: true,
    },
    {
      text: 'ответ -> y',
      descr: 'помещает значение из ответа в после Y',
      functional: true,
    },
    {
      text: 'буфер -> y',
      descr: 'помещает значение из буфера обмена в после Y',
      functional: true,
    },
  ];

  return (
    <div>
      <h1 className={styles.title}>О проекте</h1>

      <p className={styles.subtitle}>
        Проект <b>«Длинная арифметика»</b>, в котором реализован класс{' '}
        <code>BigNumber</code>, <br />
        аналогичный классу <code>BigInteger</code> в языке программирования{' '}
        <code>C#</code> и интерфейсный проект на <code>React.JS</code>. <br />
        Связью между библиотекой классов и интерфейсом на <code>
          React.JS
        </code>{' '}
        послужил <code>ASP.NET Core Web API</code>, <br />
        на котором был реализован <code>API</code>.
      </p>

      <p className={styles.subtitle}>
        <span className={styles.subtitleHeader}>Над проектом работали:</span>
        <ul>
          <li>Шабалов Павел — интерфейс (React.JS), библиотека классов</li>
          <li>Кондратьев Иван — интерфейс (WPF), библиотека классов</li>
          <li>Даньшин Глеб — библиотека классов</li>
          <li>Янович Михаил — библиотека классов</li>
          <li>Константинова Дарья — библиотека классов</li>
          <li>
            Поляков Владимир — набор тестов для методов из библиотеки классов
          </li>
        </ul>
      </p>

      <div className={styles.explanationBlock}>
        <span className={styles.subtitleHeader}>Пояснение к операциям</span>
        <div className={styles.explanation}>
          {operations.map((obj, i) => (
            <span key={i} className={styles.descr}>
              <OperationButton {...obj} />
              <span>— {obj.descr}</span>
            </span>
          ))}
        </div>
      </div>

      <div className={styles.explanationBlock}>
        <span className={styles.subtitleHeader}>
          Пояснение к функциональным кнопкам
        </span>
        <div className={styles.explanation}>
          {functions.map((obj, i) => (
            <span key={i} className={styles.descr}>
              <OperationButton {...obj} />
              <span>— {obj.descr}</span>
            </span>
          ))}
        </div>
      </div>
    </div>
  );
};
