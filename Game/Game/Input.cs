using SFML.Window;
using System.Collections.Generic;
namespace Game
{
    public static class Input
    {
        public static List<Keyboard.Key> pressedKeys = new List<Keyboard.Key>();

        public static bool GetKey(Keyboard.Key key)
        {
            return Keyboard.IsKeyPressed(key);
        }
    }
}