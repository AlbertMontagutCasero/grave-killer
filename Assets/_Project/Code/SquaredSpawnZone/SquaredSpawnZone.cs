namespace GraveKiller
{
    public class SquaredSpawnZone
    {
        private readonly SignedRange xSignedRange;
        private readonly SignedRange ySignedRange;
        private RandomProvider randomProvider;

        public SquaredSpawnZone(
            SignedRange xSignedRange,
            SignedRange ySignedRange)
        {
            this.xSignedRange = xSignedRange;
            this.ySignedRange = ySignedRange;
            this.SetRandomProvider(new RandomUnity());
        }

        public void SetRandomProvider(RandomProvider randomProvider)
        {
            this.randomProvider = randomProvider;
        }

        public float GetX()
        {
            var isPositive = this.randomProvider.GetRandomBool();

            var currentXRange = isPositive
                ? this.xSignedRange.GetPositiveRange()
                : this.xSignedRange.GetNegativeRange();

            return this.randomProvider.GetRandomInclusive(currentXRange.min,
                currentXRange.max);
        }

        public float GetY()
        {
            var isPositive = this.randomProvider.GetRandomBool();

            var currentYRange = isPositive
                ? this.ySignedRange.GetPositiveRange()
                : this.ySignedRange.GetNegativeRange();

            return this.randomProvider.GetRandomInclusive(currentYRange.min,
                currentYRange.max);
        }
    }
}
