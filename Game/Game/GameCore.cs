using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace Game
{
    public static class GameCore
    {

        public static RenderWindow window;
        private static List<GameObject> gameObjectList = new List<GameObject>();

        public static void Init(VideoMode v, string t)
        {
            // Init some other stuff
            window = new RenderWindow(v, t);

            

            Renderer.Init(window);
            Start();
        }

        public static void Start()
        {
            // Start some stuff, more init
            Update();
        }

        public static void Update()
        {
            while (window.IsOpen) // Replace true with Game.WindowOpened or something
            {
                // Do loop
                // Dispatch SFML's window's messages
                window.DispatchEvents();
                // Maybe implement targetFps property in order to limit FPS (VSync-like)

                // Run each GO's update method
                foreach (GameObject go in gameObjectList)
                {
                    go.Update();
                }

                // Render everything to screen
                Render();
                Time.FinishUpdate(); // Call this only when update loop is finished.
                
            }
            // The loop has exited, end the bloody game
        }

        public static void Render()
        {
            Renderer.TickRenderer();
        }
    }
}