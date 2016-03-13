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
            return b.pos.X >= a.pos.X + a.w || b.pos.X + b.w <= a.pos.X || b.pos.Y >= a.pos.Y + a.h || b.pos.Y + b.h <= a.pos.Y;
        }
    }

    class BoundingBox
    {
        public BoundingBox(int w, int h)
        {
            this.w = w;
            this.h = w;
        }

        public int w;
        public int h;
        public Vector2f pos;
    }
}
