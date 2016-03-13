using System;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    class Bullet : GameObject
    {
        public float bulletDamage = 0f;
        public uint bulletSpeed = 175;
        public bool isPlayerOwned = false;
        public Vector2f velocity;
        public Vector2f startPos;

        private bool launch;

        public override void Start()
        {
            CircleShape c = new CircleShape(3);
            c.FillColor = Color.Blue;
            drawable = c;

            bounds = new BoundingBox(3, 3);
            drawLayer = 1;
        }

        public override void Update()
        {
            if (!launch)
                return;
            GameObject[] colliding = AABB.Colliding(bounds);
            if (colliding.Length > 0)
            {
                foreach (GameObject g in colliding)
                {
                    if (g is Player && !isPlayerOwned)
                    {
                        Player p = (Player)g;
                        p.Kill();
                    }
                    if (g is Enemy && isPlayerOwned)
                    {
                        Enemy e = (Enemy)g;
                        e.health -= bulletDamage;
                        shouldRender = false;
                        g.shouldRender = false;
                        break;
                    }
                    
                }
            }
            Position += velocity * Time.deltaTime;
        }

        public void Launch()
        {
            Position = startPos;
            if (isPlayerOwned)
            {
                velocity = new Vector2f(0, -1 * bulletSpeed);
            }
            else
            {
                velocity = GameManager.player.Position - Position;
            }
            launch = true;
        }
    }
}
