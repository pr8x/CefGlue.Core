using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal sealed class AvaloniaCefDisplayHandler : CefDisplayHandler
    {
        private readonly AvaloniaCefBrowser _owner;

        public AvaloniaCefDisplayHandler(AvaloniaCefBrowser owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
        {
        }

        protected override void OnTitleChange(CefBrowser browser, string title)
        {
        }

        protected override bool OnTooltip(CefBrowser browser, string text)
        {
            //return _owner.OnTooltip(text);
            return true;
        }

        protected override void OnStatusMessage(CefBrowser browser, string value)
        {
        }

        protected override bool OnConsoleMessage(CefBrowser browser, string message, string source, int line)
        {
            return false;
        }
    }
}