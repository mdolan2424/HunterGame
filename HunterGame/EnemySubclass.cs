﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterGame
{
    //Easy Enemy sub class inherits from our 'Enemy' prototype interface
    public class EnemySubclass : Enemy
    {
        //Basic attributes. speed, icon
        float speed;
        int killWorth;
        //how many locations the enemy goes to before leaving the screen
        int screenPoints;
        //how many locations the enemy has been to.
        int locCount;
        String icon;
        //Starting position
        int StartX;
        int StartY;
        //window size
        int WindowX;
        int WindowY;
        Vector2 dest = new Vector2();
        public Vector2 Destination
        {
            get { return dest; }
            set { dest = value; }
        }
        public int KillWorth
        {
            get{return killWorth;}
        }
        public float Speed
        {
            get { return speed; }
        }
        
        public int ScreenPoints
        {
            get { return screenPoints; }
        }


        //Here we throw the cloneable exception
        public object Clone()
        {
            throw new NotImplementedException();
        }

        //The main
        public EnemySubclass(int WindowX, int WindowY)
        {
            //Set our difficulty and window size
            this.WindowX = WindowX;
            this.WindowY = WindowY;
            locCount = 0;
            Console.Write("This is the Easy Enemy Class....\n");
        }
        //Basic getters
        public int[] getStartPos()
        {
            int[] returnA = new int[2];
            returnA[0] = this.StartX;
            returnA[1] = this.StartY;

            return returnA;
        }

   
        //Method for setting all the appropriate settings based on difficulty setting
        public void setDifficultyAttribs(float speed, int killWorth, int screenPoints)
        {
            //Generate random starting position for the enemy
            Random Ran = new Random();

            this.StartX = 0; //We do this to make sure it starts off screen.
            this.StartY = Ran.Next(this.WindowY);
            
            this.speed = speed;
            this.killWorth = killWorth;
            this.screenPoints = screenPoints;

        }

        //Impportant piece. This is the bit of code that calls the super (aka 'base' in C#)
        //Of the ICloneable to return the cloned object.
        public Enemy CloneCopy()
        {
            EnemySubclass EnemyObject = null;

            try
            {
                EnemyObject = (EnemySubclass)base.MemberwiseClone();
            }
            catch
            {

                Console.Write("We have a problem");
            }

            

            return EnemyObject;


        }
        public void incrementLocCount()
        {
            locCount++;
        }
        public int getLocationCount()
        {
            return locCount;
        }
    }
}
