namespace GraveKiller
{
    public interface RandomProvider
    {
        float GetRandomInclusive(float min, float max);
        bool GetRandomBool();
    }
}
