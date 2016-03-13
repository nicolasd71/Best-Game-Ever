using SFML.Graphics;
namespace Game
{
    public abstract class RObject : Transformable
    {
        public int drawLayer = 0;
        public Drawable drawable;
    }
}