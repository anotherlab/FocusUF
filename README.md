# FocusUF
Command line tool for locking the focus of ~~a Microsoft® LifeCam HD-5000 webcam~~ any webcam that supports IAMCameraControl control interface from DirectShowLib.

The LifeCam HD-5000 webcam is a decent webcam with an annoying feature.  The autofocus keeps shifting the focus around if you move your head slightly.  When you are in a video chat with someone, this can get annoying for the other viewers.  Your face will shift in and out of focus.

FocusUF uses the [DirectShowLib library](https://www.nuget.org/packages/DirectShowLib/) library to provide easy access to the focus control of the webcam.  The DirectShowLib library maps the DirectShow Interfaces for use from a .NET app.  ~~The app is hard coded to connect to a LifeCam HD-5000, but it would be easy enough to change the code for other webcam.~~ You can now specify the webcam by name or partial name.

The code was written with Visual Studio 2017 and revised with Visual Studio 2019, it has not been tested with any other compiler.

## Note
I have added a Windows command line executable, in a zip file in the win32 folder.  This exe is not supported, it's supplied as is.

## How to use
Launch the app that will be using the webcam.  Wait until it is in focus and then run FocusUF.  It will detect the webcam and flip the autofocus setting to manual and lock it to the current focus setting.  The setting will persist until the webcam is reset or another app changes the focus setting.

Thanks to the changes submitted by [@cainhopwood](https://github.com/cainhopwood), we have command line options to that let you select a webcam by name or partial name. You also have the ability to set the exposure and focus by value.  Use the --list-cameras to get the list of webcams and the values supported for focus and exposure.
```dos
Usage: FocusUF [--help | -?] [--list-cameras | -l]
               [--focus-mode-manual | -fm] [--focus-mode-auto | -fa]
               [--set-focus <value> | -f <value>]
               [--exposure-mode-manual | -em] [--exposure-mode-auto | -ea]
               [--set-exposure <value> | -e <value>]
               [--camera-name <name> | -n <name>]
```
I added to the change making the camera name case insensitive.  The code will skip over virtual web cams.

The name "FocusUF" is a tip of the hat to the YouTube channel [AvE](https://www.youtube.com/user/arduinoversusevil/featured), where the host uses the phrase "Focus You F@*&" whenever his video camera loses focus.
