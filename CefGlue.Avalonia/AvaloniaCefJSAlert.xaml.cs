using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace CefGlue.Avalonia
{
    /// <summary>
    ///     Interaction logic for AvaloniaCefJSAlert.xaml
    /// </summary>
    public class AvaloniaCefJSAlert : Window
    {
        public AvaloniaCefJSAlert(string message)
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
            Close();
        }
    }
}