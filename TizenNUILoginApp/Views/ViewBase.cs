using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace TizenNUILoginApp.Views
{
    public class ViewBase : View
    {
        protected Window Window { get; private set; }

        public ViewBase()
        {
            Window = Window.Instance;
            BackgroundColor = new Color("#FFFFFF");
        }

        public virtual void Show()
        {
            Window.GetDefaultLayer().Add(this);
        }

        public virtual void Hide()
        {
            Window.GetDefaultLayer().Remove(this);
        }
    }
}
