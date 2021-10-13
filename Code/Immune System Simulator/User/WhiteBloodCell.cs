using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Immune_System_Simulator.User
{
    class WhiteBloodCell
    {
        public static Texture2D Texture;
        public Player player;

        private float x, y;
        public Vector2 Position {
            get {
                return new Vector2(x, y);
            }
        }

        private int width, height;
        public Rectangle Rectangle {
            get {
                return new Rectangle((int)x, (int)y, width, height);
            }
        }

        private float velocity = 6;

        public Vector2 Direction {
            get {
                return new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            }
        }

        public DestinationMarker destination;

        public float Rotation = 0;

        public float scale;
        public Vector2 Origin {
            get {
                return new Vector2(width / 2, height / 2);
            }
        }

        public WhiteBloodCell(Player player, float x, float y) {

            this.player = player;
            this.x = x;
            this.y = y;

            width = 300;
            height = 300;
            scale = 1;
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, scale, SpriteEffects.None, 0);

            if (destination != null) {

                destination.Draw(spriteBatch);
            }
        }

        public void Update() {

            if (destination != null) {

                Rotation = (float)Math.Atan2((double)destination.Position.Y - y, (double)destination.Position.X - x);

                if (!destination.Rectangle.Intersects(Rectangle)) {
                    x += Direction.X * velocity;
                    y += Direction.Y * velocity;
                }

                destination.Update();
            }
        }
    }
}
