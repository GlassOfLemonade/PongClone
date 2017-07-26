using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PongClone
{
    /// <summary>
    /// Handles all initialization and AI of CPU paddle.
    /// </summary>
    public class CpuPaddle : GameObject
    {
        private const float PADDLE_VEL = 0.4f;

        public CpuPaddle(Texture2D texture, Vector2 position)
            : base(texture, position)
        {

        }

        //private void CheckScreenBounds()
        //{
        //    if (Position.Y + Height > screen.Height - Width)
        //    {
        //        SetPosition((int)Position.X, screen.Height - Height - Width);
        //    }
        //    if (Position.Y < 0 + Width)
        //    {
        //        SetPosition((int)Position.X, 0 + Width);
        //    }
        //}

        #region AI
        public void MovePaddle(Ball ball)
        {
            if (Position.Y + (Height/2) > ball.Position.Y + (ball.Height/2))
            {
                velocity = new Vector2(0, PADDLE_VEL);
                Direction = new Vector2(0, -1);
            }
            else if (Position.Y + (Height / 2) < ball.Position.Y + (ball.Height/2))
            {
                velocity = new Vector2(0, PADDLE_VEL);
                Direction = new Vector2(0, 1);
            }
            else if (Position.Y - Height == ball.Position.Y - ball.Height)
            {
                velocity = Vector2.Zero;
            }
        }
        #endregion

        public void Update(GameTime gameTime, Ball ball)
        {
            Position += Direction * velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //CheckScreenBounds();
            MovePaddle(ball);
        }
    }
}
