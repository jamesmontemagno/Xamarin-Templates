using Feature.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using Feature.Forms.Plugin.Droid;

[assembly: Dependency(typeof(FeatureImplementation))]
namespace Feature.Forms.Plugin.Droid
{
  public class FeatureImplementation : IFeature
  {
  }
}
