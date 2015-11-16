﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    public class EasyState:DifficultyState
    {
        public EasyState()
        {
            enemyScreenPts = 3;
            enemySpeed = 2;
            maxEnemies = 3;
            enemyKillWorth = 5;
        }
    }
}
