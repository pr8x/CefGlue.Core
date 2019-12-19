using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace CefGlue.Avalonia
{
    /// <summary>
    ///     Interaction logic for WpfCefJSConfirm.xaml
    /// </summary>
    public class AvaloniaCefJSConfirm : Window
    {
        public AvaloniaCefJSConfirm(string message)
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