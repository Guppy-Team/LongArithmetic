import React from 'react';
import { NavMenu } from '../NavMenu';

import styles from './Layout.module.scss';

export const Layout = ({ children }) => {
  return (
    <div className="wrapper">
      <NavMenu />
      <main className={styles.root}>
        <div className="container">{children}</div>
      </main>
    </div>
  );
};
