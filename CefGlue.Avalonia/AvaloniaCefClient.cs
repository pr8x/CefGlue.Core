using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal class MessageReceivedEventArgs : EventArgs
    {
        public CefBrowser Browser { get; set; }
        public CefProcessId ProcessId { get; set; }
        public CefProcessMessage Message { get; set; }
    }

    internal class AvaloniaCefClient : CefClient
    {
        private readonly AvaloniaCefDisplayHandler _displayHandler;
        private readonly AvaloniaCefJSDialogHandler _jsDialogHandler;

        private readonly AvaloniaCefLifeSpanHandler _lifeSpanHandler;
        private readonly AvaloniaCefLoadHandler _loadHandler;
        private AvaloniaCefBrowser _owner;
        private readonly AvaloniaCefRenderHandler _renderHandler;

        public AvaloniaCefClient(AvaloniaCefBrowser owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));

            _lifeSpanHandler = new AvaloniaCefLifeSpanHandler(owner);
            _displayHandler = new AvaloniaCefDisplayHandler(owner);
            _renderHandler = new AvaloniaCefRenderHandler(owner);
            _loadHandler = new AvaloniaCefLoadHandler(owner);
            _jsDialogHandler = new AvaloniaCefJSDialogHandler();
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        protected override CefLifeSpanHandler GetLifeSpanHandler()
        {
            return _lifeSpanHandler;
        }

        protected override CefDisplayHandler GetDisplayHandler()
        {
            return _displayHandler;
        }

        protected override CefRenderHandler GetRenderHandler()
        {
            return _renderHandler;
        }

        protected override CefLoadHandler GetLoadHandler()
        {
            return _loadHandler;
        }

        protected override CefJSDialogHandler GetJSDialogHandler()
        {
            return _jsDialogHandler;
        }

        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess,
            CefProcessMessage message)
        {
            MessageReceived?.Invoke(this,
                new MessageReceivedEventArgs {Browser = browser, ProcessId = sourceProcess, Message = message});

            return base.OnProcessMessageReceived(browser, sourceProcess, message);
        }
    }
}