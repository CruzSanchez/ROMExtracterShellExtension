using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameExtracterExstenion.ExtensionMethods
{
    internal static class IEnumerableStringExtensions
    {
        /// <summary>
        /// This will check to see if any of the selected folders contain files that have ROM file extensions
        /// </summary>
        /// <param name="files">An Enumerable collection of files to check</param>
        /// <param name="extensions">An array of extensions to check for</param>
        /// <returns>This returns true if there is at least one file that has a ROM extension</returns>
        public static bool ContainsAny(this IEnumerable<string> files, string[] extensions)
        {
            foreach (var file in files)
            {
                foreach (var ext in extensions)
                {
                    if (file.Contains(ext))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
