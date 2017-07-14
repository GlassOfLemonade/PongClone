using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    public class PlayerPaddle : GameObject
    {
        public PlayerPaddle(Texture2D texture, Vector2 position, Rectangle screen)
            :base(texture, position, screen)
        {

        }

        #region Input
        public void InputHandler(KeyboardState KeyState)
        {
            // up
            if (KeyState.IsKeyDown(Keys.W))
            {
                Velocity = new Vector2(0,0.4f);
                this.direction = new Vector2(0, -1);
            }
            // down
            else if (KeyState.IsKeyDown(Keys.S))
            {
                Velocity = new Vector2(0,0.4f);
                this.direction = new Vector2(0, 1);
            }
            // not moving
            else
            {
                Velocity = Vector2.Zero;
            }
        }
        #endregion

        protected void CheckScreenBounds()
        {
            if (Position.Y + Height > screen.Height - texture.Width)
            {
                SetPosition((int)Position.X, screen.Height - Height - texture.Width);
            }
            else if (Position.Y < 0 + texture.Width)
            {
                SetPosition((int)Position.X, 0 + texture.Width);
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            InputHandler(Keyboard.GetState());
            CheckScreenBounds();
        }
    }
}
