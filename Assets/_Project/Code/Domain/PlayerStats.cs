namespace GraveKiller
{
    public class PlayerStats
    {
        private float speed;

        public PlayerStats(float speed)
        {
            this.speed = speed;
        }

        public float GetSpeed()
        {
            return this.speed;
        }
    }
}
