﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HunterGame.Game.Items;
using System.Collections.Generic;
namespace HunterGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Hunter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameController controller;

        KeyboardState currentKeyboardState, oldKeyboardState;
        MouseState currentMouseState, oldMouseState;

        //mouse position and sprite
        private Vector2 cursor;
        private Texture2D crosshair;

        //pause
        bool paused;

        //itemappeared
        bool itemappeared = false;
        //enemies

        //items
        Texture2D itemImage;
        Vector2 itemVector;
        //use item
        Player player;

        ItemManager items;
        public Hunter()
        {
            //sets up window and Game
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1080;

            //use item
            player = new Player(3);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            //Handles game logic separate from Rendering
            controller = new GameController();
            //mouse and keyboard states
            currentKeyboardState = new KeyboardState();
            currentMouseState = new MouseState();

            //initialize cursor
            cursor = new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            paused = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            crosshair = Content.Load<Texture2D>("Graphics\\circle-03");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            oldKeyboardState = currentKeyboardState;
            oldMouseState = currentMouseState;

            //mouse
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            //update mouse sprite position.  Image is drawn from bottom right so we subtract
            cursor.X = currentMouseState.X-(crosshair.Width/2);
            cursor.Y = currentMouseState.Y-(crosshair.Height/2);

            //check for a paused key press.
            
                if (currentKeyboardState.IsKeyDown(Keys.Escape) && oldKeyboardState.IsKeyUp(Keys.Escape))
                {
                    paused = true;
                    Exit();
                }

            if (currentKeyboardState.IsKeyDown(Keys.W) && oldKeyboardState.IsKeyUp(Keys.W))
            {
                //check if time to spawn an item


                //spawn a random item and draw to screen.
                items = new ItemManager();
                items.createRandomItem();
                itemappeared = true;


            }

            if (currentKeyboardState.IsKeyDown(Keys.E) && oldKeyboardState.IsKeyUp(Keys.E))
            {
               
                //print change in lives for player
                player.changeLives(items.useItem());
                Console.Write(player.lives);

            }
                
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(crosshair, cursor);
            if (itemappeared)
            {
                //draw item
                items.Draw(this, spriteBatch);
                //move around screen
                items.changePosition(1, 1);
            }
           
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
        
        //performs actions when game is activated

        protected override void OnActivated(object sender, EventArgs args)
        {

            this.Window.Title = "Hunter";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            this.Window.Title = "Paused";
            base.OnDeactivated(sender, args);
        }
    }
}
