﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame.Game.Players
{
    class ReloadingState : IPlayerState
    {
        public Boolean shoot()
        {
            return false;
        }

        public override string ToString()
        {

            return "Reloading";
        }
    }
}
