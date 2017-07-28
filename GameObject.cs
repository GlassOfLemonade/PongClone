using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongClone
{
    public class GameObject : IGameObject
    {
        #region Properties
        private Texture2D texture;
        private Vector2 position;
        public Vector2 direction;
        //protected Rectangle screen;
        internal Vector2 velocity;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public float VelocityX
        {
            get { return velocity.X; }
            set { velocity.X = value; }
        }
        public float VelocityY
        {
            get { return velocity.Y; }
            set { velocity.Y = value; }
        }
        /// <summary>
        /// wrote myself into a corner before here, will need to refactor the direction property later.
        /// need accessors for individual axes.
        /// </summary>
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
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

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            // update position of object
            position += Direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void SetPosition(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }
    }
}
