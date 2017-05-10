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
    /// All Game Objects have these properties & functions in common
    /// </summary>
    interface IGameObject
    {
        Rectangle CollisionRectangle { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
