using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Mathf
    {
        public static float Clamp(float val, float min, float max)
        {
            if(val < min)
                return min;
            if (val > max)
                return max;
            return val;
        }
    }
}
