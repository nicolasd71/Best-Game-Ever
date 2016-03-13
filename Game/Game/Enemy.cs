using SFML.Graphics;
namespace Game
{
    public class Enemy : GameObject
    {
        public float health { get; set; }

        public override void Start()
        {
            RectangleShape c = new RectangleShape(new SFML.System.Vector2f(10, 10));
            c.FillColor = Color.Magenta;
            drawable = c;

            bounds = new BoundingBox(10, 10);

            health = 100f;   
        }

        public override void Update()
        {
            
        }
    }
}