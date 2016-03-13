using SFML.System;
using System;
namespace Game
{
    public static class Vector2fExtension
    {
        public static Vector2f Normalize(this Vector2f v)
        {
            float magnitude = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (magnitude != 0)
            {
                return v / magnitude;
            }
            return v;
        }
    }
}