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
    class Ball
    {
        #region Fields
        private int xPos;
        private int yPos;

        public Texture2D texture;
        #endregion

        #region Constructor
        public Ball(Texture2D texture, int xPos, int yPos)
        {
            this.texture = texture;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        #endregion
    }
}
