using System;
using Avalonia.Controls;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public static class CefGlueApplicationExtensions
    {
        public static T ConfigureCefGlue<T>(this T builder, string[] args) where T : AppBuilderBase<T>, new()
        {
            return builder.AfterSetup(b =>
            {
                CefRuntime.Load();
                var mainArgs = new CefMainArgs(args);
                var cefApp = new SampleCefApp();
                cefApp.RegisterCustomSchemes += CefApp_RegisterCustomSchemes;
                cefApp.WebKitInitialized += CefApp_WebKitInitialized;

                var exitCode = CefRuntime.ExecuteProcess(mainArgs, cefApp, IntPtr.Zero);
                if (exitCode != -1)
                {
                    return;
                }

                var cefSettings = new CefSettings
                {
                    SingleProcess = true,
                    WindowlessRenderingEnabled = true,
                    MultiThreadedMessageLoop = false,
                    LogSeverity = CefLogSeverity.Disable,
                    LogFile = "cef.log",
                    ExternalMessagePump = true
                };


                CefRuntime.Initialize(mainArgs, cefSettings, cefApp, IntPtr.Zero);
            });
        }

        private static void CefApp_WebKitInitialized(object sender, EventArgs e)
        {
            AvaloniaCefBrowser.OnWebKitInitialized(sender, e);
        }

        private static void CefApp_RegisterCustomSchemes(object sender, RegisterCustomSchemesEventArgs e)
        {
            AvaloniaCefBrowser.OnRegisterCustomSchemes(sender, e);
        }
    }
}