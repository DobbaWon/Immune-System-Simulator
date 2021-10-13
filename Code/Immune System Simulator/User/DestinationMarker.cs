using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Immune_System_Simulator.User
{
    class DestinationMarker
    {
        public static Texture2D Texture;
        public readonly int width = 28, height = 28;

        private float animationTimer = 4f;
        public int AnimationTimer {
            get {
                return (int)animationTimer;
            }
        }

        public Rectangle SourceRectangle {
            get {
                switch (AnimationTimer) {
                    case 4:
                        return new Rectangle(0, 0, width, height);

                    case 3:
                        return new Rectangle(0, 0, width, height);

                    case 2:
                        return new Rectangle(width, 0, width, height);

                    case 1:
                        return new Rectangle(0, height, width, height);

                    case 0:
                        return new Rectangle(width, height, width, height);
                }
                return new Rectangle(); // Will never occur, however the "get" Keyword doesn't like Switches, so this is required.
            }
        }

        private float x, y;
        public Vector2 Position {
            get {
                return new Vector2(x, y);
            }
        }

        public Rectangle Rectangle {
            get {
                return new Rectangle((int)x, (int)y, width, height);
            }
        }

        public DestinationMarker(float x, float y) {

            this.x = x;
            this.y = y;
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White);
        }

        public void Update() {

            animationTimer -= 0.1f;
            if (animationTimer <= 0) {

                animationTimer = 4;
            }
        }
    }
}
