using System;
using Key = SFML.Window.Keyboard.Key;
namespace Game
{
    public static class Game
    {
        public static void Start()
        {
            
        }

        public static void Update()
        {
            if (Input.GetKeyDown(Key.Z))
            {
                Console.WriteLine("Z");
            }
        }
    }
}