using System.Collections.Generic;
using SFML.System;
namespace Game
{
    public static class Game
    {
        public static List<GameObject> enemies = new List<GameObject>();
        public static Player p;
        public static void Start()
        {
            p = new Player();
            for (int i = 0; i < 5; i++)
            {
                Enemy e = new Enemy();
                e.SetPlayer(p);
                e.Position = new Vector2f(200, 200 + (i * 50));
                enemies.Add(e);
            }
        }

        public static void Update()
        {
            
        }
    }
}