namespace GraveKiller
{
    public class RandomUnity : RandomProvider
    {
        public float GetRandomInclusive(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public bool GetRandomBool()
        {
            return UnityEngine.Random.Range(0, 2) == 0;
        }
    }
}
