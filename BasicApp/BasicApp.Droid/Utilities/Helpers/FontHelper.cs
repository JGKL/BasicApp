using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;

namespace BasicApp.Droid.Utilities.Helpers
{
    public class FontHelper
    {
        private static readonly Dictionary<string, Typeface> _typefaces = new Dictionary<string, Typeface>();

        public static Typeface Get(Context context, string fontFileName)
        {
            var typeface = _typefaces.FirstOrDefault(x => x.Key == fontFileName).Value;
            if (typeface == null)
            {
                typeface = Typeface.CreateFromAsset(context.Assets, fontFileName);
                _typefaces.Add(fontFileName, typeface);
            }
            return typeface;
        }
    }
}