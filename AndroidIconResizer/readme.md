Collection of small utilities I have found useful while writing Android apps

# Android Icon Resizer #
This app will resize all images (.png files) in a directory to various sizes to be used as drawable files in an android project.


## Command line options: ##

    --include-xxxhdpi   (Default: False) Include an xxxhdpi sized image.  Note
                        that google only suggests this for launcher icons.
                        (http://developer.android.com/guide/practices/screens_support.html#xxxhdpi-note)
    -i, --input-dir     Location of the images to process.  Default
                        value:  current directory.
    -o, --output-dir    Location of the output directory.  Default
                        value:  current directory.
    -h, --height        (Default: 100) The height of the output image in pixels
                        in the MDPI folder.  Default value:  100
    -w, --width         (Default: 100) The width of the output image in pixels in
                        the MDPI folder.  Default value:  100
    --help              Display this help screen.


## Sample Usage: ##

### Resize all images in current directory to 100 pixels by 100 pixels ###

    AndroidIconResizer

#### Directory Before ####

    * file.png (1024 pixels x 1024 pixels)

#### Directory After ####

    * file.png (still 1024 pixels x 1024 pixels)
    * res/drawable-mdpi/file.png   (100 x 100 pixels)
    * res/drawable-hdpi/file.png   (150 x 150 pixels)
    * res/drawable-xhdpi/file.png  (200 x 200 pixels)
    * res/drawable-xxhdpi/file.png (300 x 300 pixels)


### Resize all images in specified directory to 20 by 50 pixels ###

    AndroidIconResizer -i C:\inputFiles -w 20 -h 50

## Dependencies ##

- [Magick.Net](https://magick.codeplex.com/) a .Net wrapper around [ImageMagick](http://www.imagemagick.org/)
- [Command Line Parser Library](https://commandline.codeplex.com/) a neat and easy to use parser

# Android Resoucre Checker (arc) #

This app will look at the resource directory of an android app and let you know if you are missing anything

## Command line options: ##

    -r, --resource-dir    (Default: .) Location of the resource directory
    --help                Display this help screen.

## Sample Usage: ##

    arc -r c:/source/MyAndroidProject/Resouces
    arc -r c:/source/MyAndroidProject

The app tries to be intelligent about where your resource directory is.  If you specify a parent directory of the resource folder, it will do its best to find your resource folder.  The above two examples will do the same thing. 

If you don't specify a directory, it assumes the current directory

## Dependencies ##

- [Command Line Parser Library](https://commandline.codeplex.com/) a neat and easy to use parser
