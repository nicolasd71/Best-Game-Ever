namespace Game
{
    public static class GameCore
    {
        public static void Init()
        {
            // Init some other stuff
            Start();
        }

        public static void Start()
        {
            // Start some stuff, more init
            Update();
        }

        public static void Update()
        {
            while (true) // Replace true with Game.WindowOpened or something
            {
                // Do loop
                // Maybe implement targetFps property in order to limit FPS (VSync-like)
                Time.FinishUpdate(); // Call this only when update loop is finished.
            }

            // The loop has exited, end the bloody game
        }

        public static void Render()
        {
            // Render stuff here, idk
        }
    }
}