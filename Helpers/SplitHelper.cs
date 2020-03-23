using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Helpers
{
    public static class SplitHelper
    {
        public static string Split(string value, char separator, int position)
        {
            return value.Split(separator)[position];
        }
    }
}
