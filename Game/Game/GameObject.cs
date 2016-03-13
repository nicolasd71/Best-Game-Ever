using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject : RObject
    {
        private static int curObjectID = 0;

        public BoundingBox bounds { get; set; }
        public int ID { get; private set; }

        public bool shouldRender = true;

        public void Init()
        {
            curObjectID++;
            ID = curObjectID;
            GameCore.RegisterGameObject(this);
            Start();
        }
        public abstract void Start();
        public abstract void Update();
    }
}