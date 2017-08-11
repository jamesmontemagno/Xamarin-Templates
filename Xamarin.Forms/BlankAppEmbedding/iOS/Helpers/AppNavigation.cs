using System;
using System.Linq;
using System.Threading.Tasks;
using BlankAppEmbedded.Interfaces;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace BlankAppEmbedded2.iOS.Helpers
{
    public class AppNavigation : IAppNavigation
    {
        public void Pop()
        {
            var visibleController = GetVisibleNavigationViewController();

            visibleController.PopViewController(true);
        }

        public void Push(Page page)
        {
            var newController = page.CreateViewController();
            newController.AutomaticallyAdjustsScrollViewInsets = true;
            newController.EdgesForExtendedLayout = UIRectEdge.None;
            newController.Title = page.Title;

            var visibleController = GetVisibleNavigationViewController();
            visibleController.PushViewController(newController, true);
        }

        /// <summary>
        /// Gets the visible view controller.
        /// </summary>
        /// <returns>The visible view controller.</returns>
        UINavigationController GetVisibleNavigationViewController()
        {
            UIViewController viewController = null;
            var window = UIApplication.SharedApplication.KeyWindow;


            if (window != null && window.WindowLevel == UIWindowLevel.Normal)
                viewController = window.RootViewController;

            if (viewController == null)
            {
                window = UIApplication.SharedApplication.Windows.OrderByDescending(w => w.WindowLevel).FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);
                if (window == null)
                    throw new InvalidOperationException("Could not find current view controller");

                viewController = window.RootViewController;
            }

            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;

            if (viewController == null)
                throw new InvalidOperationException("Could not find current view controller");

            if (viewController is UINavigationController)
                return (UINavigationController)viewController;
            
            return viewController.NavigationController;
        }
    }
}
