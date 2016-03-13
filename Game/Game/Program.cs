using System;
using SFML;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore.Init(new SFML.Window.VideoMode(800, 600), "Test game");
        }
    }
}
