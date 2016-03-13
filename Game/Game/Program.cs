using System;
using SFML;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore.Init(new SFML.Window.VideoMode(800, 600), "Test game");

        }
    }

    class TestObject : GameObject
    {
        public TestObject()
            : base(new BoundingBox(5, 5))
        {
            CircleShape c = new CircleShape(2.5f);
            c.FillColor = Color.White;
        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            if (Input.GetKey(Keyboard.Key.D))
                Position += new Vector2f(1, 0);
        }
    }
}
