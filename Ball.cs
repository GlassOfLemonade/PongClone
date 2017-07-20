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
    /// <summary>
    /// Handles all of ball's properties
    /// </summary>
    public class Ball : GameObject
    {
        #region Properties
        private Vector2 startingPos;
        // random seed for angle calculations
        private Random rand = new Random();
        #endregion

        #region Constructor
        public Ball(Texture2D texture, Vector2 position, Rectangle screen)
            : base(texture, position, screen)
        {
            startingPos = position;
            DefaultSpeed();
            SetDirection();
        }
        #endregion

        #region Methods
        public void DefaultSpeed()
        {
            velocity = new Vector2(0.2f, 0.2f);
        }
        public void SetDirection()
        {
            Direction = new Vector2(1f, 1f);
        }
        public void Reset()
        {
            DefaultSpeed();
            SetDirection();
        }
        #endregion

        #region Updates
        public override void Update(GameTime gameTime)
        {
            Position += Direction * velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            VerticalBounce();
        }
        #endregion

        #region Bounce Mechanics
        public void VerticalBounce()
        {
            if(Position.Y < 0 + Width || Position.Y > screen.Height - Height)
            {
                direction.Y = -direction.Y;
            }
        }
        #endregion
    }
}
