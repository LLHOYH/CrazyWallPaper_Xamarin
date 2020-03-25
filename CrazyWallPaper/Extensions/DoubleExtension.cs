using System;
namespace CrazyWallPaper.Extensions
{
    public static class DoubleExtension
    {

        public static double Clamp (this double self, double min, double max)
        {
            return Math.Min(max, Math.Max(self, min));
        }
    }
}
