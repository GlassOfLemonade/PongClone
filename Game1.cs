using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // screen size
        private const int Width = 800;
        private const int Height = 600;

        Ball ball;
        PlayerPaddle playerPaddle;
        CpuPaddle cpuPaddle;
        CollisionChecks CollisionHandler;
        SoundManager soundManager;
        Rectangle screen;
        Score score;
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;

            soundManager = new SoundManager(Services, Content.RootDirectory);
            score = new Score();
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
            var ballTexture = this.Content.Load<Texture2D>("PongBall");
            var paddleTexture = this.Content.Load<Texture2D>("PongBar");
            screen = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);

            ball = new Ball(ballTexture, new Vector2((Width/2)-(ballTexture.Width/2), (Height/2)-(ballTexture.Height/2)));
            playerPaddle = new PlayerPaddle(paddleTexture, new Vector2(Width - (paddleTexture.Width * 2), (Height / 2) - (paddleTexture.Height / 2)));
            cpuPaddle = new CpuPaddle(paddleTexture, new Vector2(0 + (paddleTexture.Width * 2), (Height / 2) - (paddleTexture.Height / 2)));

            CollisionHandler = new CollisionChecks(ball, playerPaddle, cpuPaddle, screen);

            font = this.Content.Load<SpriteFont>("Score");

            #region Audio Content
            soundManager.LoadContent();
            soundManager.Subscribe(CollisionHandler);
            #endregion
            score.Subscribe(CollisionHandler);
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
            ball.Update(gameTime);
            playerPaddle.Update(gameTime);
            cpuPaddle.Update(gameTime, ball);
            CollisionHandler.Update(gameTime);
            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            playerPaddle.Draw(spriteBatch);
            cpuPaddle.Draw(spriteBatch);
            spriteBatch.DrawString(font, score.PlayerScore.ToString(), new Vector2((float)Window.ClientBounds.Width * (3f / 4f), 50), Color.White);
            spriteBatch.DrawString(font, score.CpuScore.ToString(), new Vector2((float)Window.ClientBounds.Width * (1f / 4f), 50), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
