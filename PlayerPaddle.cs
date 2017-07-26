using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    public class PlayerPaddle : GameObject
    {
        private const float PADDLE_VEL = 0.4f;

        public PlayerPaddle(Texture2D texture, Vector2 position)
            :base(texture, position)
        {

        }

        #region Input
        public void InputHandler(KeyboardState KeyState)
        {
            // up
            if (KeyState.IsKeyDown(Keys.W))
            {
                velocity = new Vector2(0, PADDLE_VEL);
                this.Direction = new Vector2(0, -1);
            }
            // down
            else if (KeyState.IsKeyDown(Keys.S))
            {
                velocity = new Vector2(0,PADDLE_VEL);
                this.Direction = new Vector2(0, 1);
            }
            // not moving
            else
            {
                velocity = Vector2.Zero;
            }
        }
        #endregion

        //protected void CheckScreenBounds()
        //{
        //    if (Position.Y + Height > screen.Height - Width)
        //    {
        //        SetPosition((int)Position.X, screen.Height - Height - Width);
        //    }
        //    else if (Position.Y < 0 + Width)
        //    {
        //        SetPosition((int)Position.X, 0 + Width);
        //    }
        //}

        public override void Update(GameTime gameTime)
        {
            Position += Direction * velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            InputHandler(Keyboard.GetState());
            //CheckScreenBounds();
        }
    }
}
