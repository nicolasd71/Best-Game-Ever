using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Collections.Generic;

namespace Game
{
    public static class AABB
    {
        private static GameObject[] goList;
        public static bool Colliding(BoundingBox a, BoundingBox b)
        {
            bool ret = a.pos.X < b.pos.X + b.w && a.pos.X + a.w > b.pos.X && a.pos.Y < b.pos.Y + b.h && a.h + a.pos.Y > b.pos.Y;
            return ret;
        }

        public static GameObject[] Colliding(BoundingBox a)
        {
            List<GameObject> ret = new List<GameObject>();
            if (goList == null || goList.Length != GameCore.GetRegisterGameObjectsCount())
                goList = GameCore.GetRegisteredGameObjects();
            foreach (GameObject g in goList)
            {
                // If not collidable
                if (g.bounds == null)
                    continue;
                // Prevent self-colliding, while we're at it
                if (g.bounds == a)
                    continue;
                // If colliding, add to the return list
                if(Colliding(a, g.bounds))
                    ret.Add(g);
            }
            return ret.ToArray();
        }
    }

    public class BoundingBox
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
