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
    /// Handles sounds, scoring as a result of ball movement
    /// </summary>
    public class BallManager
    {
        private readonly Ball ball;

        public BallManager(Ball ball)
        {
            this.ball = ball;
        }
    }
}
