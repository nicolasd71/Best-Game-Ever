using System;
using SFML;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCore.Init(); // Maybe handle RenderWindow creation from Init() ?
            SFML.Graphics.RenderWindow w = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(800, 600), "Test");
            Console.ReadLine();
        }
    }
}
