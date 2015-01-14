This app will resize all images (.png files) in a directory to various sizes to be used as drawable files in an android project.


# Command line options: #

    -i, --input-dir     (Default: .) Location of the images to process.  Default
                        value:  current directory.
    -o, --output-dir    (Default: .) Location of the output directory.  Default
                        value:  current directory.
    -h, --height        (Default: 100) The height of the output image in pixels
                        in the MDPI folder.  Default value:  100
    -w, --width         (Default: 100) The width of the output image in pixels in
                        the MDPI folder.  Default value:  100
    --help              Display this help screen.


# Sample Usage: #

## Resize all images in current directory to 100 pixels by 100 pixels ##
    AndroidIconResizer

### Directory Before ###
    * file.png (1024 pixels x 1024 pixels)

### Directory After ###
    * file.png (still 1024 pixels x 1024 pixels)
    * res/drawable-ldpi/file.png (75 x 75 pixels)
    * res/drawable-mdpi/file.png (100 x 100 pixels)
    * res/drawable-hdpi/file.png (150 x 150 pixels)
    * res/drawable-xhdpi/file.png (200 x 200 pixels)


## Resize all images in specified directory to 20 pixels by 50 pixels ## 
    AndroidIconResizer -i C:\inputFiles -w 20 -h 50

# Dependencies #

- [Magick.Net](https://magick.codeplex.com/) a .Net wrapper around [ImageMagick](http://www.imagemagick.org/)
- [Command Line Parser Library](https://commandline.codeplex.com/) a neat and easy to use parser