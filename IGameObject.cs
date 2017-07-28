using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
