using $safeprojectgroupname$.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using $safeprojectname$;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof($safeprojectgroupname$.Forms.Plugin.Abstractions.$safeprojectgroupname$Control), typeof($safeprojectgroupname$Renderer))]
namespace $safeprojectname$
{
  /// <summary>
  /// $safeprojectgroupname$ Renderer
  /// </summary>
  public class $safeprojectgroupname$Renderer //: TRender (replace with renderer type
  {
    /// <summary>
    /// Used for registration with dependency service
    /// </summary>
    public static void Init(){}
  }
}