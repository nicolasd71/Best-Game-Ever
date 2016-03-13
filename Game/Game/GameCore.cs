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

            Input.Init();
            Renderer.Init(window);
            Start();
        }

        public static void Start()
        {
            // Start some stuff, more init
            Game.Start();
            Update();
        }

        public static void Update()
        {
            // Main update loop, every engine-related process should be ran from here
            while (window.IsOpen)
            {
                // Dispatch SFML's window's messages
                window.DispatchEvents();
                // Maybe implement targetFps property in order to limit FPS (VSync-like)
                // todo: targetFPS

                // Run each GO's update method
                foreach (GameObject go in gameObjectList)
                {
                    // Basic culling, gameobject will be skipped if it is offscreen
                    if (go.Position.X < 0 || go.Position.X > window.Size.X || go.Position.Y < 0 || go.Position.Y > window.Size.Y)
                        go.shouldRender = false;

                    // If the GO should not be rendered, then it probably shouldn't be anything
                    if (!go.shouldRender)
                        continue;
                        
                    go.Update();

                    // Update GO's bounding box if it has one
                    if (go.bounds != null)
                        go.bounds.pos = go.Position;

                    // Place the GO in the next rendering queue
                    Renderer.QueueForRender(go);
                }

                Game.Update();

                // Clear key buffer
                Input.ClearKeyBuffer();

                // Render everything to screen
                Renderer.TickRenderer();
                // Call this only when update loop is finished.
                Time.FinishUpdate();
            }

            // The loop has exited, end the bloody game
        }

        public static void RegisterGameObject(GameObject go)
        {
            gameObjectList.Add(go);
            go.Init();
        }

        public static void UnregisterGameObject(GameObject go)
        {
            foreach (GameObject g in gameObjectList)
            {
                if (g.ID == g.ID)
                    gameObjectList.Remove(g);
            }
        }
    }
}