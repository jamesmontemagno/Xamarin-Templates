using Feature.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using Feature.Forms.Plugin.iOS;

[assembly: Dependency(typeof(FeatureImplementation))]
namespace Feature.Forms.Plugin.iOS
{
  public class FeatureImplementation : IFeature
  {
  }
}
