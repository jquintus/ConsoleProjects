namespace AndroidIconResizer
{
    public class ImageSize
    {
        public ImageSize(string name, double ratio)
        {
            Name = name;
            Ratio = ratio;
        }

        public static ImageSize[] Sizes
        {
            get
            {
                return new ImageSize[]{
                  new ImageSize("drawable-ldpi", .75),
                  new ImageSize("drawable-mdpi", 1),
                  new ImageSize("drawable-hdpi", 1.5),
                  new ImageSize("drawable-xhdpi",    2),
                };
            }
        }

        public string Name { get; private set; }

        public double Ratio { get; private set; }
    }
}
