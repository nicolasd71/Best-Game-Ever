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
            TestObject t = new TestObject();
            t.Position = new Vector2f(5, 5);
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
            drawable = c;
        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            if (Input.GetKey(Keyboard.Key.D))
                Position += new Vector2f(1 * 10 * Time.deltaTime, 0);
        }
    }
}
