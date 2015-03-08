Console app to parse FTP data out of [Microsoft Azure publish profiles](https://msdn.microsoft.com/en-us/library/dn385850%28v=nav.70%29.aspx) and save it in a format that can be imported by [FileZilla Client](https://filezilla-project.org/)

## Direct Download ##
* [pubToFz.exe](../apps/pubToFz.exe)
    
## Command Line Arguments ##


    pubToFz path_to_input [path_to_output]
    
If path_to_output is omitted, the file is saved as filezilla.xml in the current directory     


    
    
## Sample Usage ##

    pubToFz c:\users\myName\downloads\file.publishProfile
    pubToFz c:\users\myName\downloads\file.publishProfile filezilla.xml
