using UnityEngine;

namespace GraveKiller
{
    public class FingerTouchUnity : TouchProvider
    {
        private Touch thisFameTouchCached;
        
        public int GetTouchCount()
        {
            return Input.touchCount;
        }

        public TouchPhase GetTouchPhase()
        {
            this.thisFameTouchCached = Input.GetTouch(0);

            return this.thisFameTouchCached.phase;
        }

        public Vector2 GetTouchPosition()
        {
            return this.thisFameTouchCached.position;
        }
    }
}
