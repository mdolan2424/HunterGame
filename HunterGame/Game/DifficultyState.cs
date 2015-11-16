﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public abstract class DifficultyState
    {
        protected int enemySpeed;
        protected int maxEnemies;
        protected int enemyScreenPts;
        protected int enemyKillWorth;
    
        public int EnemySpeed
        {
            get { return enemySpeed; }
        }
        public int MaxEnemies
        {
            get { return maxEnemies; }
        }
        public int EnemyScreenPts
        {
            get { return enemyScreenPts; }
        }
        public int EnemyKillWorth
        {
            get { return enemyKillWorth; }
        }
    }

}
