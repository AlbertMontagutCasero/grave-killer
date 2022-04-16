namespace GraveKiller
{
    public class SignedRange
    {
        private Range positiveSignedRange;

        public SignedRange(Range positiveSignedRange)
        {
            this.positiveSignedRange = positiveSignedRange;
        }

        public float GetPositiveMin()
        {
            return this.positiveSignedRange.min;
        }

        public float GetNegativeMin()
        {
            return -this.positiveSignedRange.max;
        }

        public float GetPositiveMax()
        {
            return this.positiveSignedRange.max;
        }

        public float GetNegativeMax()
        {
            return -this.positiveSignedRange.min;
        }

        public Range GetPositiveRange()
        {
            return new Range(this.GetPositiveMin(), this.GetPositiveMax());
        }

        public Range GetNegativeRange()
        {
            return new Range(this.GetNegativeMin(), this.GetNegativeMax());
        }
    }
}
