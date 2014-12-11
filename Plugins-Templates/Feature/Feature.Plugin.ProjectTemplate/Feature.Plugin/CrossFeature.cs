using $safeprojectname$.Abstractions;
using System;

namespace $safeprojectname$
{
  /// <summary>
  /// Cross platform $SpecificSolutionName$ implemenations
  /// </summary>
  public class Cross$SpecificSolutionName$
  {
    static Lazy<I$SpecificSolutionName$> Implementation = new Lazy<I$SpecificSolutionName$>(() => Create$SpecificSolutionName$(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static I$SpecificSolutionName$ Current
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

    static I$SpecificSolutionName$ Create$SpecificSolutionName$()
    {
#if PORTABLE
        return null;
#else
        return new $SpecificSolutionName$Implementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
