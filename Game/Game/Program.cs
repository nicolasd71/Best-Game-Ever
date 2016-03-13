using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            SFML.Graphics.RenderWindow w = new SFML.Graphics.RenderWindow(new SFML.Window.VideoMode(800, 600), "Test");
            Console.ReadLine();
        }
    }
}
