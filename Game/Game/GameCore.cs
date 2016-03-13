using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;

namespace Game
{
    public static class GameCore
    {
        public static bool SkipCulledObjectUpdate = true;
        public static RenderWindow window;
        private static List<GameObject> gameObjectList = new List<GameObject>();
        private static List<GameObject> tempGOList = new List<GameObject>();

        public static void Init(VideoMode v, string t)
        {
            // Init some other stuff
            window = new RenderWindow(v, t);
            // Has to be False to allow GetKeyDown to work
            window.SetKeyRepeatEnabled(false);

            // Window events
            window.Closed += (object sender, System.EventArgs e) =>
            {
                window.Close();
            };

            // Init other core components
            Input.Init(window);
            Renderer.Init(window);
            
            // Start the main loop
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
                    else
                        go.shouldRender = true;

                    // If the GO is not to be rendered, then it probably shouldn't be evaluated as a whole
                    if (!go.shouldRender && SkipCulledObjectUpdate)
                        continue;
                        
                    go.Update();

                    // Update GO's bounding box if it has one
                    if (go.bounds != null)
                        go.bounds.pos = go.Position;

                    // Place the GO in the next rendering queue
                    Renderer.QueueForRender(go);
                }

                // Update Game's state
                Game.Update();

                // Clear key buffer
                Input.ClearKeyBuffer();

                // Render everything to screen
                Renderer.TickRenderer();

                // Populate game object collection with newly created game objects
                gameObjectList.AddRange(tempGOList);
                tempGOList.Clear();

                // Call this only when update loop is finished.
                Time.FinishUpdate();

                System.Threading.Thread.Sleep(10);
            }

            // The loop has exited, end the bloody game
        }

        public static void RegisterGameObject(GameObject go)
        {
            tempGOList.Add(go);
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

        public static GameObject[] GetRegisteredGameObjects()
        {
            return gameObjectList.ToArray();
        }

        public static int GetRegisterGameObjectsCount()
        {
            return gameObjectList.Count;
        }
    }
}