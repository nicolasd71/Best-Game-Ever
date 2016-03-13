namespace Game
{
    public class Enemy : GameObject
    {
        public float health { get; set; }

        public override void Start()
        {
            health = 100f;   
        }

        public override void Update()
        {
            
        }
    }
}