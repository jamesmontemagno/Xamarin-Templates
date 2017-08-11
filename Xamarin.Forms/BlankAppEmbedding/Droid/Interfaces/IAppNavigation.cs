using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlankAppEmbedded.Interfaces
{
    public interface IAppNavigation
    {
        void Push(Page page);
        void Pop();
    }
}
