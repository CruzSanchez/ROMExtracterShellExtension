using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExtracterExstenion.ExtensionMethods
{
    internal static class StringExtensions
    {
        /// <summary>
        /// This method will check to see if "this" string ends with any of the specified file extensions from a provided array.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <param name="extensions">An array, containing file extensions to check for.</param>
        /// <returns>Returns true if "this" string ends with one of the file extensions.</returns>
        public static bool EndsWithAny(this string s, string[] extensions) 
        {
            foreach (var ext in extensions)
            {
                if (s.EndsWith(ext))
                {
                    return true;
                }
            }

            return false;             
        }
    }
}
