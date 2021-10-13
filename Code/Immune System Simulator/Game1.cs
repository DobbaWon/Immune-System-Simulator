using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Immune_System_Simulator.User;

namespace Immune_System_Simulator
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        static Player player = new Player();

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1300;
            graphics.PreferredBackBufferHeight = 700;
        }

        protected override void Initialize() {

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            WhiteBloodCell.Texture = Content.Load<Texture2D>("Textures//White Blood Cell With Pointer");
            DestinationMarker.Texture = Content.Load<Texture2D>("Textures//Pointer Beacon");
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            player.cellControlling.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update();

            base.Update(gameTime);
        }

        protected override void UnloadContent() {
        }

    }
}
