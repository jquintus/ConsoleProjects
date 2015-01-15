using System;

namespace AndroidResourceChecker
{
    public enum DrawableFolders
    {
        drawable,
        ldpi,
        mdpi,
        hdpi,
        xhdpi,
        xxhdpi,
        xxxhdpi,
    }

    public static class DrawableFoldersExtensions
    {
        public static string ToPath(this DrawableFolders size)
        {
            switch (size)
            {
                case DrawableFolders.drawable: return "drawable";
                case DrawableFolders.ldpi: return "drawable-ldpi";
                case DrawableFolders.mdpi: return "drawable-mdpi";
                case DrawableFolders.hdpi: return "drawable-hdpi";
                case DrawableFolders.xhdpi: return "drawable-xhdpi";
                case DrawableFolders.xxhdpi: return "drawable-xxhdpi";
                case DrawableFolders.xxxhdpi: return "drawable-xxxhdpi";
                default: throw new ArgumentOutOfRangeException(size.ToString());
            }
        }
    }
}