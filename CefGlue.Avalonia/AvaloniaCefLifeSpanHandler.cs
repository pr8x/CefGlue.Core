using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal sealed class AvaloniaCefLifeSpanHandler : CefLifeSpanHandler
    {
        private readonly AvaloniaCefBrowser _owner;

        public AvaloniaCefLifeSpanHandler(AvaloniaCefBrowser owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        protected override void OnAfterCreated(CefBrowser browser)
        {
            _owner.HandleAfterCreated(browser);
        }
    }
}