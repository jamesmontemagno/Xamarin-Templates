using $safeprojectname$.Abstractions;
using System;

namespace $safeprojectname$
{
  /// <summary>
  /// Cross platform $safeprojectgroupname$ implemenations
  /// </summary>
  public class Cross$safeprojectgroupname$
  {
    static Lazy<I$safeprojectgroupname$> Implementation = new Lazy<I$safeprojectgroupname$>(() => Create$safeprojectgroupname$(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static I$safeprojectgroupname$ Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static I$safeprojectgroupname$ Create$safeprojectgroupname$()
    {
#if PORTABLE
        return null;
#else
        return new $safeprojectgroupname$Implementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
