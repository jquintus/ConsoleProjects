using System.Collections.Generic;
using System.Linq;

namespace AndroidIconResizer
{
    public class ImageSize
    {
        public ImageSize(string name, double ratio)
        {
            Name = name;
            Ratio = ratio;
        }

        public string Name { get; private set; }

        public double Ratio { get; private set; }

        public static IEnumerable<ImageSize> GetSizes(CommandLineOption options)
        {

            // Sizes:  http://developer.android.com/design/style/iconography.html
            var sizes = new ImageSize[]{
                  //new ImageSize("drawable-ldpi", .75),
                  new ImageSize("drawable-mdpi", 1),
                  new ImageSize("drawable-hdpi", 1.5),
                  new ImageSize("drawable-xhdpi", 2),
                  new ImageSize("drawable-xxhdpi", 3),
                  new ImageSize("drawable-xxxhdpi", 4),
                };

            if (options.IncludeXxxhdpi)
            {
                return sizes;
            }
            else
            {
                return sizes.Where(s => s.Name != "drawable-xxxhdpi");
            }

        }
    }
}