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
    public class GameObject : IGameObject
    {
        #region Properties
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 direction;
        protected Rectangle screen;
        private Vector2 velocity;

        public Vector2 Position
        {
            get { return position; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Vector2 Direction
        {
            get { return direction; }
        }

        public int Width
        {
            get { return texture.Width; }
        }
        public int Height
        {
            get { return texture.Height; }
        }

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }
        #endregion

        public GameObject(Texture2D texture, Vector2 position, Rectangle screen)
        {
            this.texture = texture;
            this.position = position;
            this.screen = screen;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            // update position of object
            position += direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
    }
}
