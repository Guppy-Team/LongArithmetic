import React from 'react';

import { Calculator } from '../../components/Calculator';

import styles from './Home.module.scss';
import { Link } from 'react-router-dom';

export const Home = () => {
  return (
    <div>
      <h1 className={styles.title}>Проект «Длинная арифметика»</h1>
      <p className={styles.subtitle}>
        Реализация класса <code>BigNumber</code>, аналогичного классу{' '}
        <code>BigInteger</code> из <code>C#</code>. <br /> Пояснения к операциям
        находится на странице{' '}
        <Link className={styles.importantLink} to="/about">
          О проекте
        </Link>
      </p>

      <Calculator />
    </div>
  );
};
