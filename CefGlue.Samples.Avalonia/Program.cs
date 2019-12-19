using Avalonia;
using CefGlue.Avalonia;

namespace CefGlue.Samples.Avalonia
{
    internal static class Program
    {
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder
                .Configure<App>()
                .UsePlatformDetect();
        }

        public static int Main(string[] args)
        {
            return BuildAvaloniaApp()
                .ConfigureCefGlue(args)
                .StartWithClassicDesktopLifetime(args);
        }
    }
}
