using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace CefGlue.Avalonia
{
    internal class AvaloniaCefBrowserTheme : Styles
    {
        public AvaloniaCefBrowserTheme()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}