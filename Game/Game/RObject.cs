using SFML.Graphics;
namespace Game
{
    public abstract class RObject : Transformable
    {
        public int layer;
        public Drawable drawable;
        public RObject(int l)
        {
            layer = l;
        }
    }
}