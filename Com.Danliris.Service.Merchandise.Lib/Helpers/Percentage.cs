using System;

namespace Com.Danliris.Service.Merchandiser.Lib.Helpers
{
    public static class Percentage
    {
        public static double ToFraction(dynamic number)
        {
            try
            {
                return (double)number / 100; 
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double ToPercent(dynamic number)
        {
            try
            {
                return (double)number * 100;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
