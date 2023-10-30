import React from 'react';

import styles from './Calculator.module.scss';

import { OperationButton } from './OperationButton/OperationButton';

export const Calculator = () => {
  return (
    <div className={styles.root}>
      <div className={styles.label}>x =</div>
      <textarea className={styles.input} />

      <div className={styles.label}>y =</div>
      <textarea className={styles.input} />

      <div className={styles.buttonsWrapper}>
        <OperationButton text="x + y" />
        <OperationButton text="x - y" />
        <OperationButton text="x!" disabled />
        <OperationButton text="x ^ 2" disabled />
        <OperationButton text="x <-> y" functional />
        <OperationButton text="очистить" functional remove />

        <OperationButton text="x * y" />
        <OperationButton text="x / y" />
        <OperationButton text="mod" disabled />
        <OperationButton text="x ^ 3" disabled />
        <OperationButton text="ответ -> x" functional />
        <OperationButton text="буфер -> x" functional />

        <OperationButton text="простое?" disabled />
        <OperationButton text="НОД" disabled />
        <OperationButton text="НОК" disabled />
        <OperationButton text="x ^ y" disabled />
        <OperationButton text="ответ -> y" functional />
        <OperationButton text="буфер -> y" functional />

        <OperationButton text="|x|" disabled />
        <OperationButton text="x > y" disabled />
        <OperationButton text="x < y" disabled />
        <OperationButton text="x >= 2" disabled />
        <OperationButton text="x <= y" disabled />
        <OperationButton text="x == y" disabled />
      </div>

      <div className={styles.label}>ответ =</div>
      <textarea className={styles.input} />
    </div>
  );
};
