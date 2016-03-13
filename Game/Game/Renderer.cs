using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    static class Renderer
    {
        static private RenderWindow window;
        static private List<RObject> toRender;

        public static void Init(RenderWindow w)
        {
            window = w;
            toRender = new List<RObject>();

        }

        public static void TickRenderer()
        {
            window.Clear(Color.Black);
            toRender = toRender.OrderBy((r) => (r.layer)).ToList();

            foreach (RObject rO in toRender)
            {
                if (rO.drawable == null)
                    continue;
                RenderStates rS = new RenderStates(rO.Transform);
                window.Draw(rO.drawable, rS);
            }
            window.Display();
            toRender.Clear();
        }

        public static void QueueForRender(RObject o)
        {
            toRender.Add(o);
        }
    }

    public abstract class RObject : Transformable
    {
        public int layer;
        public Drawable drawable;
        public RObject(int l)
        {
            layer = l;
        }
    }

    // No layers, will be drawn on top of everything
    abstract class RHUD : Transformable
    {
        public Drawable drawable;
    }
}