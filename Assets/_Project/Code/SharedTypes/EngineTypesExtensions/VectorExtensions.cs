using System.Numerics;

namespace GraveKiller
{
    public static class VectorExtensions
    {
        public static Vector3 ToSystemVector3(this UnityEngine.Vector3 vector3)
        {
            return new Vector3(vector3.x, vector3.y, vector3.z);
        }
        
        public static UnityEngine.Vector3 ToUnityVector3(this Vector3 vector3)
        {
            return new UnityEngine.Vector3(vector3.X, vector3.Y, vector3.Z);
        }
        
        public static UnityEngine.Vector2 ToUnityVector2(this Vector2 vector2)
        {
            return new UnityEngine.Vector2(vector2.X, vector2.Y);
        }
        
        public static Vector2 ToSystemVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.X, vector3.Y);
        }
        
        public static Vector2 ToSystemVector2(this UnityEngine.Vector2 vector2)
        {
            return new Vector2(vector2.x, vector2.y);
        }
        
        public static Vector3 ToSystemVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.X, vector2.Y, 0);
        }
        
        public static UnityEngine.Vector2 ToUnityVector2(this Vector3 vector3)
        {
            return new UnityEngine.Vector2(vector3.X, vector3.Y);
        }
        
        public static Vector2 ToSystemVector2(this UnityEngine.Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
        
        public static UnityEngine.Vector3 ToUnityVector3(this Vector2 vector2)
        {
            return new UnityEngine.Vector3(vector2.X, vector2.Y, 0);
        }
        
    }
}
