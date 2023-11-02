import clsx from 'clsx';
import React from 'react';

import styles from './OperationButton.module.scss';

export const OperationButton = ({ text, functional, remove, ...args }) => {
  return (
    <button
      className={clsx(
        styles.root,
        functional && styles.functional,
        remove && styles.remove,
      )}
      {...args}
    >
      {text}
    </button>
  );
};
