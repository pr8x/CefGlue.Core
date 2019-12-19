using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace CefGlue.Avalonia
{
    /// <summary>
    ///     Interaction logic for WpfCefJSPrompt.xaml
    /// </summary>
    public class AvaloniaCefJSPrompt : Window
    {
        public AvaloniaCefJSPrompt(string message, string defaultText)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        [UsedImplicitly]
        private void OkButton_Click(object sender, PointerPressedEventArgs e)
        {
            Close(true);
        }

        [UsedImplicitly]
        private void CancelButton_Click(object sender, PointerPressedEventArgs e)
        {
            Close(false);
        }
    }
}