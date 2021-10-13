using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading.Tasks;

namespace Immune_System_Simulator.User
{
    class Camera
    {
        public Matrix transform;
        private Viewport viewPort;
        private Player player;

        public static Vector2 Origin; // The top-left of the screen.

        private float zoom = 1.0f;
        public float Zoom
        {
            get
            {
                return MathHelper.Clamp(zoom, 0.3f, 1.5f);
            }
        }

        private static double shakeOffset;
        public int scroll;

        public MouseState mouse;
        public MouseState oldMouse = Mouse.GetState();

        public Vector2 scrollingValue = new Vector2();

        Vector3 Scale
        {
            get
            {
                return new Vector3(Zoom, Zoom, 0); // Z is always set to 0 (2D Environment).
            }
        }

        public Camera(Viewport viewPort, Player player)
        {
            this.viewPort = viewPort;
            this.player = player;
        }

        public void Update()
        {
            #region Zooming

            mouse = Mouse.GetState();
            scroll += mouse.ScrollWheelValue - oldMouse.ScrollWheelValue;
            zoom += (float)scroll / 3000; // Arbitrary value of 3000 just makes scrolling less extreme.
            scroll = 0;

            zoom = Zoom; // Re-Clamping the 'zoom' Variable.

            #endregion

            #region Scrolling

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                scrollingValue.X -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                scrollingValue.X += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                scrollingValue.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                scrollingValue.Y += 5;

            if (Keyboard.GetState().IsKeyDown(Keys.X))
                scrollingValue = new Vector2(); // Resetting the Camera at the Player

            #endregion

            /* MAGIC NUMBERS:
             * 650 = Viewport.Width / 2
             * 350 = Viewport.height / 2
             */
            Origin = new Vector2(player.cellControlling.Position.X + 12 - 650 / Zoom + scrollingValue.X + (int)shakeOffset,
                    player.cellControlling.Position.Y + 12 - 350 / Zoom + scrollingValue.Y + (int)shakeOffset);

            transform = Matrix.CreateTranslation(new Vector3(-Origin.X, -Origin.Y, 0)) *
                Matrix.CreateTranslation(new Vector3(viewPort.X / 2, viewPort.Y / 2, 0)) * Matrix.CreateScale(Scale);

            oldMouse = mouse;
        }

        public static void Screenshake()
        {
            Task task = Task.Run(() =>
            {
                for (int i = -5; i <= 5; i++)
                {
                    shakeOffset = Math.Sin(Convert.ToDouble(i)) * 5;
                    Task.Delay(1);
                }
                shakeOffset = 0;
            });
        }
    }
}
