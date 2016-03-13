using SFML.System;
using SFML.Window;
using System.Collections.Generic;
namespace Game
{
    public static class Input
    {
        private static List<Keyboard.Key> pressedKeys = new List<Keyboard.Key>();
        private static List<Keyboard.Key> releasedKeys = new List<Keyboard.Key>();

        public static Vector2f mousePosition { get; private set; }

        public static void Init()
        {
            GameCore.window.KeyPressed += OnKeyPressed;
            GameCore.window.KeyReleased += OnKeyReleased;

            GameCore.window.MouseMoved += Window_MouseMoved;
        }

        public static bool GetKey(Keyboard.Key key)
        {
            return Keyboard.IsKeyPressed(key);
        }

        public static bool GetKeyDown(Keyboard.Key key)
        {
            return pressedKeys.Contains(key);
        }

        public static bool GetKeyUp(Keyboard.Key key)
        {
            return releasedKeys.Contains(key);
        }

        public static void ClearKeyBuffer()
        {
            pressedKeys.Clear();
            releasedKeys.Clear();
        }

        private static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (!pressedKeys.Contains(e.Code))
                pressedKeys.Add(e.Code);
        }

        private static void OnKeyReleased(object sender, KeyEventArgs e)
        {
            if (!releasedKeys.Contains(e.Code))
                releasedKeys.Add(e.Code);
        }

        private static void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            mousePosition = new Vector2f(e.X, e.Y);
        }
    }
}