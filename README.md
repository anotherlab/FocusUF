# FocusUF
Command line tool for locking the focus of a Microsoft® LifeCam HD-5000 webcam

The LifeCam HD-5000 webcam is a decent webcam with an annoying feature.  The autofocus keeps shifting the focus around if you move your head slightly.  When you are in a video chat with someone, this can get annoying for the other viewers.  Your face will shift in and out of focus.

FocusUF uses the [DirectShowLib library](https://www.nuget.org/packages/DirectShowLib/) library to provide easy access to the focus control of the webcam.  The DirectShowLib library maps the DirectShow Interfaces for use from a .NET app.  The app is hard coded to connect to a LifeCam HD-5000, but it would be easy enough to change the code for other webcam.

The code was written with Visual Studio 2017, it has not been tested with any other compiler.

## Note
This repo only has the source code, not the actual command line tool. You will need to compile the code.

## How to use
Launch the app that will be using the webcam.  Wait until it is in focus and then run FocusUF.  It will detect the webcam and flip the autofocus setting to manual and lock it to the current focus setting.  The setting will persist until the webcam is reset or another app changes the focus setting.

The name "FocusUF" is a tip of the hat to the YouTube channel [AvE](https://www.youtube.com/user/arduinoversusevil/featured), where the host uses the phrase "Focus You F@*&" whenever his video camera loses focus.
