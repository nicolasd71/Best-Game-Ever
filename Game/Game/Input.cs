using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;

namespace Game
{
    public static class Input
    {
        private static List<Keyboard.Key> pressedKeys = new List<Keyboard.Key>();
        private static List<Keyboard.Key> releasedKeys = new List<Keyboard.Key>();

        public static Vector2f mousePosition { get; private set; }

        private static RenderWindow window;
        public static void Init(RenderWindow w)
        {
            window = w;
            window.KeyPressed += OnKeyPressed;
            window.KeyReleased += OnKeyReleased;

            window.MouseMoved += OnMouseMoved;
            window.MouseButtonPressed += OnMouseButtonPressed;
            window.MouseButtonReleased += OnMouseButtonReleased;
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

        public static bool GetMouseButton(Mouse.Button button)
        {
            return Mouse.IsButtonPressed(button);
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

        private static void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            // todo
        }

        private static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            // todo
        }

        private static void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            // todo
        }
    }
}