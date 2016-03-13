using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class GameObject : RObject
    {
        private static int curObjectID = 0;

        public BoundingBox bounds { get; set; }
        public int ID { get; private set; }

        public bool shouldRender = true;

        public GameObject(int l = 0)
            : base(l)
        {
            curObjectID++;
            ID = curObjectID;
            Start();
        }

        public GameObject(BoundingBox b, int l = 0)
            : base(l)
        {
            curObjectID++;
            bounds = b;
            ID = curObjectID;
            Start();
        }

        public abstract void Start();
        public abstract void Update();
    }
}