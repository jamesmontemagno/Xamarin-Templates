using $safeprojectgroupname$.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using $safeprojectname$;

[assembly: Dependency(typeof($safeprojectgroupname$Implementation))]
namespace $safeprojectname$
{
  /// <summary>
  /// $safeprojectgroupname$ Implementation
  /// </summary>
  public class $safeprojectgroupname$Implementation : I$safeprojectgroupname$
  {
    /// <summary>
    /// Used for registration with dependency service
    /// </summary>
    public static void Init(){}
  }
}
