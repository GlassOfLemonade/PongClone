using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;

namespace PongClone
{
    public class SoundManager
    {
        ContentManager soundContent;
        private SoundEffect ballPaddleCollision;
        private SoundEffect ballScreenCollision;
        private SoundEffect ballStart;

        public SoundManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            soundContent = new ContentManager(serviceProvider, rootDirectory);
        }

        internal void LoadContent()
        {
            ballPaddleCollision = soundContent.Load<SoundEffect>("ballBarCollision");
            ballScreenCollision = soundContent.Load<SoundEffect>("ballEdgeCollision");
            ballStart = soundContent.Load<SoundEffect>("ballOutSound");
        }

        public void Subscribe(CollisionChecks checker)
        {
            checker.paddleBounce += new CollisionChecks.CollisionHandler(Paddle_Bounce);
            checker.screenBounce += new CollisionChecks.CollisionHandler(Screen_Bounce);
        }

        private void Screen_Bounce(CollisionChecks checker, EventArgs e)
        {
            ballScreenCollision.Play();
        }

        private void Paddle_Bounce(CollisionChecks checker, EventArgs e)
        {
            ballPaddleCollision.Play();
        }
    }
}
