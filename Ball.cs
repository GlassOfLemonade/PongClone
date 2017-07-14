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
            Velocity = new Vector2(0.4f, 0.4f);
        }
        public void SetDirection()
        {
            direction = new Vector2(0.7f, 0.7f);
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
            position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            VerticalBounce();
        }
        #endregion

        #region Bounce Mechanics
        public void VerticalBounce()
        {
            if(position.Y < 0 + texture.Width || position.Y > screen.Height - texture.Height)
            {
                direction.Y = -direction.Y;
            }
        }
        public void PaddleBounce(PlayerPaddle paddle)
        {
            Velocity *= 1.05f;
            
        }
        #endregion
    }
}
