using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    static class Renderer
    {
        static private bool ready = false;

        static private RenderWindow window;
        static private List<RObject> toRender;

        public static void Init(VideoMode v, string t)
        {
            window = new RenderWindow(v, t);
            toRender = new List<RObject>();
            //toRender.Add(new RObject(5));
            //toRender.Add(new RObject(0));
            //toRender.Add(new RObject(2));
            //toRender.Add(new RObject(4));
            //toRender.Add(new RObject(6));
        }

        public static void Init(uint w, uint h, string t)
        {
            window = new RenderWindow(new VideoMode(w, h), t);
            toRender = new List<RObject>();
        }

        public static void TickRenderer()
        {
            if (!ready)
                return;
            toRender = toRender.OrderBy((r) => (r.layer)).ToList();
            window.Clear(Color.Black);
            foreach (RObject rO in toRender)
            {
                RenderStates rS = new RenderStates(rO.Transform);
                window.Draw(rO.drawable, rS);
            }
            toRender.Clear();
        }
    }

    class RObject : Transformable
    {
        public int layer;
        public Drawable drawable;
        public RObject(int l = 0)
        {
            layer = l;
        }
    }
}