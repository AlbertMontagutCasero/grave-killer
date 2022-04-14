using UnityEngine;

namespace GraveKiller
{
    public class MouseTouchUnity : TouchProvider
    {
        public int GetTouchCount()
        {
            var isMouseJustPressed = Input.GetMouseButtonDown(0);
            var isMoveMouse = Input.GetMouseButton(0);
            var isMouseRelease = Input.GetMouseButtonUp(0);

            return isMouseJustPressed || isMoveMouse || isMouseRelease ? 1 : 0;
        }

        public TouchPhase GetTouchPhase()
        {
            var isMouseJustPressed = Input.GetMouseButtonDown(0);
            if (isMouseJustPressed)
            {
                return TouchPhase.Began;
            }

            var isMoveMouse = Input.GetMouseButton(0);
            if (isMoveMouse)
            {
                return TouchPhase.Moved;
            }
            
            var isMouseRelease = Input.GetMouseButtonUp(0);
            if (isMouseRelease)
            {
                return TouchPhase.Ended;
            }

            return TouchPhase.Canceled;
        }

        public Vector2 GetTouchPosition()
        {
            return Input.mousePosition;
        }
    }
}
