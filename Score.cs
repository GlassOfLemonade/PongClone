using System;

namespace PongClone
{
    public class Score
    {
        public int PlayerScore { get; set; }
        public int CpuScore { get; set; }

        public Score()
        {
            
        }

        public void Subscribe(CollisionChecks checker)
        {
            checker.playerGoal += new CollisionChecks.CollisionHandler(Player_Goal_Scored);
            checker.cpuGoal += new CollisionChecks.CollisionHandler(Cpu_Goal_Scored);
        }

        private void Cpu_Goal_Scored(CollisionChecks checker, EventArgs e)
        {
            CpuScore++;
        }

        private void Player_Goal_Scored(CollisionChecks checker, EventArgs e)
        {
            PlayerScore++;
        }
    }
}
