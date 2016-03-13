using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class GameObject : RObject
    {
        public Guid ID { get; private set; }
        public GameObject(int l = 0)
            : base(l)
        {
            ID = Guid.NewGuid();
        }

        public abstract void Start();
        public abstract void Update();
    }
}
