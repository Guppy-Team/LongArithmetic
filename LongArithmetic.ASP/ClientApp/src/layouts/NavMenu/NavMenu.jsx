import React from 'react';

import styles from './NavMenu.module.scss';

export const NavMenu = () => {
  return (
    <header className={styles.root}>
      <div className={styles.wrapper}>
        <a href="" className={styles.logo}>
          Team Guppy
        </a>

        <div className={styles.navigation}>
          <a href="" className={styles.link}>
            О проекте
          </a>
        </div>
      </div>
    </header>
  );
};
