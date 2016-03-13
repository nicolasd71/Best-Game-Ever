using System;
namespace Game
{
    public static class Time
    {
        private static DateTime startTime = DateTime.Now;
        private static DateTime lastUpdateTime = DateTime.Now;

        public static float time
        {
            get
            {
                return (float)(DateTime.Now - startTime).TotalMilliseconds / 1000f;
            }
        }
        public static float deltaTime { get; private set; }

        internal static void FinishUpdate() // Call this when the update loop is finished, sets delta time accordingly.
        {
            DateTime now = DateTime.Now;
            deltaTime = (float)(now - lastUpdateTime).TotalMilliseconds / 1000f;
            lastUpdateTime = now;
        }
    }
}