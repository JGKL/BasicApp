using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicApp.Common
{
    public static class StringExtensions
    {
        /// <summary>
        /// Replace the found word with an empty string
        /// </summary>
        /// <param name="source">The fullword</param>
        /// <param name="values">Collection of words which the fullwords ends with</param>
        /// <returns>The given word without the found suffix which is removed.</returns>
        public static string TrimEnd(this string source, string[] values)
        {
            var wordMatch = values.FirstOrDefault(suffix => source.EndsWith(suffix));
            if (wordMatch != null)
                return source.Replace(wordMatch, string.Empty);

            return source;
        }
    }
}
