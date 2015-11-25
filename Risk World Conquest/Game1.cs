using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;


namespace Risk_World_Conquest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int width;
        int height;
        Texture2D mainMenu;
        Rectangle mainMenuRec;
        enum GameState
        {
            MainMenu,
            Options,
            Playing,
        }
        GameState CurrentGameState = GameState.MainMenu;

        cButton btnPlay;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            width = 1366;
            height = 768;
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Camara.SetGraphicsDeviceManager(graphics);
            Camara.SetTarget(Vector2.Zero);
            Camara.SetWorldWidth(7);
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
            btnPlay = new cButton(Content.Load<Texture2D>("risklogo"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
            mainMenu = Content.Load<Texture2D>("800x600");
            mainMenuRec = new Rectangle((int)((width / 2) - (mainMenu.Width / 2)), (int)((height / 2) - (mainMenu.Height / 2)), 800, 600);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);
                    break;
                case GameState.Playing:
                    break;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            Console.WriteLine((int)((width / 2) / 2));
            Console.WriteLine((int)((height / 2) / 2));

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(mainMenu,mainMenuRec,Color.White);
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    //spriteBatch.Draw(Content.Load<Texture2D>bntWIII)
                    btnPlay.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
