using Microsoft.Xna.Framework.Input;


namespace Immune_System_Simulator.User
{
    class Player 
    {
        public MouseState mouse;
        public MouseState oldMouse;

        public KeyboardState keyboard;
        public KeyboardState oldKeyboard;

        public WhiteBloodCell cellControlling; // The Cell which the Player is currently controlling

        public Player() {

            cellControlling = new WhiteBloodCell(this, 150, 150);
        }

        public void Update() {

            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (mouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released) {

                cellControlling.destination = new DestinationMarker(mouse.Position.X, mouse.Position.Y);
            }

            cellControlling.Update();

            oldMouse = mouse;
            oldKeyboard = keyboard;
        }
    }
}

