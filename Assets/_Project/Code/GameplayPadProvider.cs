namespace GraveKiller
{
    public static class GameplayPadProvider
    {
        public static TouchProvider GetPadImplementation()
        {
#if UNITY_EDITOR
            return new MouseTouchUnity();
#endif
#if UNITY_ANDROID
            return new FingerTouchUnity();
#endif
        }
    }
}
