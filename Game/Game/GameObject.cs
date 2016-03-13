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
        public int ID { get; private set; }
        public GameObject(int l = 0)
            : base(l)
        {
            curObjectID++;
            ID = curObjectID;
            Start();
        }

        public abstract void Start();
        public abstract void Update();
    }
}
