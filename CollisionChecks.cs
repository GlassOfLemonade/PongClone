using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongClone
{
    public class CollisionChecks
    {
        public Ball Ball { get; set; }
        public PlayerPaddle Player { get; set; }
        public CpuPaddle Cpu { get; set; }
        public Rectangle Screen { get; set; }

        private List<GameObject> GameObjects = new List<GameObject>(); // object pool? I have no idea what this would be called.

        public EventArgs e = null;
        public delegate void CollisionHandler(CollisionChecks checker, EventArgs e);
        public event CollisionHandler bounce; // event notification for bounce
        public event CollisionHandler goal;

        public CollisionChecks(Ball ball, PlayerPaddle player, CpuPaddle cpu, Rectangle screen)
        {
            this.Ball = ball;
            this.Player = player;
            this.Cpu = cpu;
            this.Screen = screen;

            // need to find a way to organize this, among other things, better. As more objects would be cumbersome
            GameObjects.Add(Ball);
            GameObjects.Add(Player);
            GameObjects.Add(Cpu);
        }

        public void Update(GameTime gameTime)
        {
            CheckScreenBounds();
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (Ball.CollisionRectangle.Intersects(Player.CollisionRectangle))
            {
                Ball.VelocityX = -Ball.VelocityX * 1.05f;
                if (bounce != null)
                {
                    bounce(this, e);
                }
            }
            if (Ball.CollisionRectangle.Intersects(Cpu.CollisionRectangle))
            {
                Ball.VelocityX = -Ball.VelocityX * 1.05f;
                if (bounce != null)
                {
                    bounce(this, e);
                }
            }
        }

        private void CheckScreenBounds()
        {
            foreach (var gameObject in GameObjects)
            {
                if (gameObject is PlayerPaddle || gameObject is CpuPaddle)
                {
                    if (gameObject.Position.Y + gameObject.Height > Screen.Height - gameObject.Width)
                    {
                        gameObject.SetPosition((int)gameObject.Position.X, Screen.Height - gameObject.Height - gameObject.Width);
                    }
                    else if (gameObject.Position.Y < 0 + gameObject.Width)
                    {
                        gameObject.SetPosition((int)gameObject.Position.X, 0 + gameObject.Width);
                    }
                }
                else if (gameObject is Ball)
                {
                    // bounce on screen y axis
                    if (gameObject.Position.Y < 0 + gameObject.Width || gameObject.Position.Y > Screen.Height - gameObject.Height)
                    {
                        gameObject.direction.Y = -gameObject.direction.Y;
                        if (bounce != null)
                        {
                            bounce(this, e);
                        }
                    }
                    // stuff for passing x axis goal
                    if (gameObject.Position.X < 0 || gameObject.Position.X > Screen.Width)
                    {
                        Ball.Reset();
                        if (goal != null)
                        {
                            goal(this, e);
                        }
                    }
                }
            }
        }
    }
}
