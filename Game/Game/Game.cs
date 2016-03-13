using System.Collections.Generic;
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
                enemies.Add(new Enemy());
            }
        }

        public static void Update()
        {
            
        }
    }
}