import React from 'react';

import { Calculator } from '../../components/Calculator';

import styles from './Home.module.scss';

export const Home = () => {
  return (
    <div>
      <h1 className={styles.title}>Проект «Длинная арифметика»</h1>
      <p className={styles.subtitle}>
        Создание аналога класса <code>BigInteger</code> из <code>C#</code> под
        названием <code>BigNumber</code>
      </p>

      <Calculator />
    </div>
  );
};
