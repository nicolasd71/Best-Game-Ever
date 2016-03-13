using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Game
{
    static class AABB
    {
        public static bool Colliding(BoundingBox a, BoundingBox b)
        {

        }
    }

    struct BoundingBox
    {
        public int w;
        public int h;
        public Vector2f pos;
    }
}
