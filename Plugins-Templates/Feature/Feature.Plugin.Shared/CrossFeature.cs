using Feature.Plugin.Abstractions;
using System;

namespace Feature.Plugin
{
  /// <summary>
  /// Cross platform Feature implemenations
  /// </summary>
  public class CrossFeature
  {
    static Lazy<IFeature> Implementation = new Lazy<IFeature>(() => CreateFeature(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IFeature Current
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

    static IFeature CreateFeature()
    {
#if PORTABLE
        return null;
#else
        return new FeatureImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
