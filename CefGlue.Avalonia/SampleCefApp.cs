using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal sealed class SampleCefApp : CefApp
    {
        private CefBrowserProcessHandler _browserProcessHandler;

        public event EventHandler WebKitInitialized;
        public event RegisterCustomSchemesHandler RegisterCustomSchemes;

        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            if (string.IsNullOrEmpty(processType))
            {
                commandLine.AppendSwitch("disable-gpu");
                commandLine.AppendSwitch("disable-gpu-compositing");
                commandLine.AppendSwitch("enable-begin-frame-scheduling");
                commandLine.AppendSwitch("disable-smooth-scrolling");
            }
        }

        protected override CefBrowserProcessHandler GetBrowserProcessHandler()
        {
            return _browserProcessHandler ?? (_browserProcessHandler = new AvaloniaCefBrowserProcessHandler());
        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            var handler = new AvaloniaCefRenderProcessHandler();
            handler.WebKitInitialized += Handler_WebKitInitialized;
            return handler;
        }

        private void Handler_WebKitInitialized(object sender, EventArgs e)
        {
            WebKitInitialized?.Invoke(sender, e);
        }

        protected override void OnRegisterCustomSchemes(CefSchemeRegistrar registrar)
        {
            RegisterCustomSchemes?.Invoke(this, new RegisterCustomSchemesEventArgs(registrar));
        }
    }
}