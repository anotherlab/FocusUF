using DirectShowLib;
using System;
using System.Linq;
using System.Reflection;

// Started with the code posted here: https://stackoverflow.com/a/18189027/206

namespace FocusUF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FocusUF " + Assembly.GetEntryAssembly().GetName().Version);
            Console.WriteLine("Get the source at https://github.com/anotherlab/FocusUF");

            // Get the list of connected video cameras
            DsDevice[] devs = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            
            // Filter that list down to the one with hyper-aggressive focus
            var dev = devs.Where(d => d.Name == "Microsoft® LifeCam HD-5000").FirstOrDefault();

            if (dev != null)
            {
                // DirectShow uses a module system called filters to exposure the functionality
                // We create a new object that implements the IFilterGraph2 interface so that we can
                // new filters to exposure the functionality that we need.
                if (new FilterGraph() is IFilterGraph2 graphBuilder)
                {
                    // Create a video capture filter for the device
                    graphBuilder.AddSourceFilterForMoniker(dev.Mon, null, dev.Name, out IBaseFilter capFilter);

                    // Cast that filter to IAMCameraControl from the DirectShowLib
                    IAMCameraControl _camera = capFilter as IAMCameraControl;

                    // Get the current focus settings from the webcam
                    _camera.Get(CameraControlProperty.Focus, out int v, out CameraControlFlags f);

                    // If the camera was not in manual focus mode, lock it into manual at the current focus setting
                    if (f != CameraControlFlags.Manual)
                    {
                        _camera.Set(CameraControlProperty.Focus, v, CameraControlFlags.Manual);
                        Console.WriteLine("Manual focus engaged");
                    }
                    else
                    {
                        Console.WriteLine("Manual focus already engaged");
                    }
                }
            }
            else 
            {
                Console.WriteLine("No matching webcams found");
            }

        }
    }
}
