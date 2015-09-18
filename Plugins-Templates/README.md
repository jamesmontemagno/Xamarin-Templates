Plugin for Xamarin Templates
=====================

The Plugin for Xamarin Templates pack is available in Visual Studio 2012 and higher.

Project and Item templates to easily create Plugins for Xamarin and Windows including nuspec files.

Easily create your plugin and the template will generate your Interfaces, Portable Class Libraries, iOS, Android, Windows Phone, and Windows Store projects completely configured. Then add your nuspec file and fill in the information and you are done.


## How to get it:
Download it form the Visual Studio Gallery: https://visualstudiogallery.msdn.microsoft.com/afead421-3fbf-489a-a4e8-4a244ecdbb1e

## What's included?
That is a great question! I have started with a few basics that I use every day:

### Project Templates

#### Plugin for Xamarin
This project will automatically setup all of your portable class libraries, interfaces, and all necessary projects to make one amazing cross platform NuGet.

Simply add the nuspec and you are on your way. I even made it easier by including a NuSpec template!

**IMPORTANT**

Name your project the name of your plugin feature. It should be ONE word with NO other .'s or spaces. For instance:

* Settings
* Vibrate
* TextToSpeech

I use the name of the project to fill in a lot of really important information.


#### Control Plugin for Xamarin.Forms
This project will automatically setup and download all nugets for Xamarin.Forms and create your PCL and necessary projects to create a Control Plugin for Xamarin.Forms using custom renderers.

### Item Templates

#### Plugin for Xamarin NuSpec

It has never been easier to get your nuspec ready for NuGet. Add the nuspec to the ROOT of your solution.

**IMPORTANT**

Name the file the same as what you named your plugin so all of the file locations are correct!

#### Control Plugin for Xamarin.Forms NuSpec

It has never been easier to get your nuspec ready for NuGet. Add the nuspec to the ROOT of your solution. and it is ready for your Control Plugin for Xamarin.Forms

## License

MIT
