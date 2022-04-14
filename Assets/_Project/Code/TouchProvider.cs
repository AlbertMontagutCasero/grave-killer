using UnityEngine;

namespace GraveKiller
{
    public interface TouchProvider
    {
        int GetTouchCount();
        TouchPhase GetTouchPhase();
        Vector2 GetTouchPosition();
    }
}
