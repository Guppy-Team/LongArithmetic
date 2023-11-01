import React from 'react';
import { Link } from 'react-router-dom';

import styles from './NavMenu.module.scss';

export const NavMenu = () => {
  return (
    <header className={styles.root}>
      <div className={styles.wrapper}>
        <Link to="/" className={styles.logo}>
          Team Guppy
        </Link>

        <div className={styles.navigation}>
          <Link to="/about" className={styles.link}>
            О проекте
          </Link>
        </div>
      </div>
    </header>
  );
};
