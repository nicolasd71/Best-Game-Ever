using System;
using SFML.System;

namespace Game
{
    class Bullet : GameObject
    {
        public float bulletDamage = 0f;
        public float bulletSpeed = 20f;
        public bool isPlayerOwned = false;
        public override void Start()
        {
            
        }

        public override void Update()
        {
            GameObject[] colliding = AABB.Colliding(bounds);
            if (colliding.Length > 0)
            {
                foreach (GameObject g in colliding)
                {
                    if (isPlayerOwned && g is Player)
                        continue;
                    g.shouldRender = false;
                    Console.WriteLine("Hit an ennemy");
                }
            }
            Position += new Vector2f(0, 1 * bulletSpeed * Time.deltaTime);
        }
    }
}
