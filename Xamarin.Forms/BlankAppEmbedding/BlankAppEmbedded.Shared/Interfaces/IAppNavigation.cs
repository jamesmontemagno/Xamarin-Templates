using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlankAppEmbedded.Interfaces
{
    public interface IAppNavigation
    {
        Task PushAsync(Page page);
        Task PopAsync();
    }
}
