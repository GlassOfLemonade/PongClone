using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PongClone
{
    /// <summary>
    /// Handles all of ball's properties
    /// </summary>
    public class Ball : GameObject
    {
        #region Properties
        private Vector2 startingPos;
        #endregion

        #region Constructor
        public Ball(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            startingPos = position;
            DefaultSpeed();
            SetDirection();
        }
        #endregion

        #region Methods
        private void DefaultSpeed()
        {
            Random rand = new Random(); // random seed to calculate a new velocity
            Random rand2 = new Random();
            int yVel = rand2.Next(0,4);
            int seed = rand.Next(0,2);
            if (seed == 0) { velocity = new Vector2( 0.2f, (float)yVel / 10); }
            else if (seed == 1) { velocity = new Vector2( -0.2f, (float)yVel / 10); }
            /* 
            need to make angle library later to make sure vector always resolves to the same magnitude
            */
        }
        private void SetDirection()
        {
            Direction = new Vector2(1f, 1f);
        }
        public void Reset()
        {
            Position = startingPos;
            DefaultSpeed();
            SetDirection();
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            Position += Direction * velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}
