using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Jengine;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public enum State //Declaring our different play states available.
        {
            Menu,
            Play
        }

        static public State gameState; //Declaring the variable for switching between states.
        public static bool stateSwitch;
        List<Menu> menus = new List<Menu>();
        List<MenuButton> buttons = new List<MenuButton>();
        List<playerCollide> collider = new List<playerCollide>();
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            gameState = State.Menu;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
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

            // TODO: use this.Content to load your game content here
            stateSwitch = false;
            switch (gameState) //Allows us to run through the different gamestates and give the correct output based on the current state.
            {
                case State.Menu:
                    menus.Add(new Menu("background@2x3", Content.Load<Texture2D>("background@2x3")));
                    menus.ForEach(x => x.Initialize());
                    buttons.Add(new MenuButton(100,500,new Vector2(300,300), Content.Load<Texture2D>("Button"), 1, 3, Content.Load<SpriteFont>("ButtonText"), "Start"));
                    buttons.Add(new MenuButton(100,500,new Vector2(300,500), Content.Load<Texture2D>("Button"), 2, 3, Content.Load<SpriteFont>("ButtonText"), "Options"));
                    buttons.Add(new MenuButton(100, 500, new Vector2(300, 700), Content.Load<Texture2D>("Button"), 3, 3, Content.Load<SpriteFont>("ButtonText"), "Exit"));
                    buttons.ForEach(x => x.Initialize());
                    return;

                case State.Play:
                    player = new Player(new Vector2(100, 100), 1, Content);
                    collider.Add(new playerCollide(new Vector2(500,500), Content.Load<Texture2D>("playerRight@2x1"), "playerRight@2x1"));
                    collider.Add(new playerCollide(new Vector2(900,500), Content.Load<Texture2D>("playerRight@2x1"), "playerRight@2x1"));
                    return;
            }
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

            // TODO: Add your update logic here

            switch (gameState)
            {
                case State.Menu:
                    menus.ForEach(x => x.Update());
                    buttons.ForEach(x => x.Update());
                    buttons.ForEach(x => x.Function());
                    if (stateSwitch)
                        LoadContent();
                    return;

                case State.Play:
                    player.Update();    
                    collider.ForEach(x => x.UpdateCollision(player));
                    return;
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
            // TODO: Add your drawing code here

            switch (gameState)
            {
                case State.Menu:
                    spriteBatch.Begin();
                    menus.ForEach(x => x.Draw(spriteBatch));
                    buttons.ForEach(x => x.Draw(spriteBatch));
                    buttons.ForEach(x => x.TextDraw(spriteBatch));
                    spriteBatch.End();
                    return;

                case State.Play:
                    spriteBatch.Begin();
                    player.Draw(spriteBatch);
                    collider.ForEach(x => x.Draw(spriteBatch));
                    spriteBatch.End();
                    return;
            }
            base.Draw(gameTime);
        }
    }
}
