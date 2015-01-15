using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AndroidResourceChecker
{
    public class DrawableFolder
    {
        private readonly DrawableFolders _drawable;
        private readonly DirectoryInfo _parent;

        public DrawableFolder(DirectoryInfo parent, DrawableFolders drawable)
        {
            _parent = parent;
            _drawable = drawable;

            Directory = new DirectoryInfo(Path.Combine(parent.FullName, drawable.ToPath()));
            if (this.Exists)
            {

                Resources = new HashSet<string>(Directory.GetFiles().Select(f => f.Name));
            }
            else
            {
                Resources = new HashSet<string>();
            }
        }

        public DirectoryInfo Directory { get; private set; }

        public DrawableFolders Drawable { get { return _drawable; } }

        public bool Exists { get { return Directory.Exists; } }

        public bool IsMainDrawable
        {
            get
            {
                if (Drawable == DrawableFolders.drawable) return false;
                if (Drawable == DrawableFolders.ldpi) return false;
                if (Drawable == DrawableFolders.xxhdpi) return false;
                if (Drawable == DrawableFolders.xxxhdpi) return false;
                return true;
            }
        }

        public HashSet<string> Resources { get; private set; }

        public bool WarnIfMissing
        {
            get
            {
                return !(_drawable == DrawableFolders.ldpi || _drawable == DrawableFolders.xxxhdpi);
            }
        }

        public static IEnumerable<Error> FindErrors(IEnumerable<DrawableFolder> folders)
        {
            foreach (var folder in folders.Where(f => f.Exists))
            {
                if (folder.Drawable == DrawableFolders.ldpi)
                {
                    yield return new Error("Do you really need the ldpi folder?");
                }
                foreach (var error in folder.CompareContents(folders.Where(f => f.Exists)))
                {
                    yield return error;
                }
            }
        }

        public override string ToString()
        {
            return _drawable.ToPath();
        }

        private IEnumerable<Error> CompareContents(DrawableFolder otherFolder)
        {
            if (this != otherFolder && IsMainDrawable && otherFolder.IsMainDrawable)
            {
                foreach (var file in Resources)
                {
                    if (!otherFolder.Resources.Contains(file))
                    {
                        yield return new Error(string.Format("{0} contains a file not in {1}:  {2}", this, otherFolder, file));
                    }
                }
            }
        }

        private IEnumerable<Error> CompareContents(IEnumerable<DrawableFolder> folders)
        {
            if (Drawable == DrawableFolders.xxxhdpi)
            {
                if (Resources.Count > 1)
                {
                    yield return new Error("Too many items in the xxxhdpi folder.  We only need the launcher icon here");
                }
            }

            foreach (DrawableFolder item in folders)
            {
                foreach (Error error in CompareContents(item))
                {
                    yield return error;
                }
            }
        }
    }
}