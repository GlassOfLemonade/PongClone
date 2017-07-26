using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace PongClone
{
    public class SoundManager
    {
        public SoundManager()
        {

        }

        private void Subscribe(CollisionChecks checker)
        {
            checker.bounce += new CollisionChecks.CollisionHandler(Ball_Bounced);
        }

        private void Ball_Bounced(CollisionChecks checker, EventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}
