using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class AvaloniaCefLoadHandler : CefLoadHandler
    {
        private readonly AvaloniaCefBrowser _owner;

        public AvaloniaCefLoadHandler(AvaloniaCefBrowser owner)
        {
            _owner = owner;
        }

        protected override void OnLoadingStateChange(CefBrowser browser, bool isLoading, bool canGoBack,
            bool canGoForward)
        {
            _owner.OnLoadingStateChange(isLoading, canGoBack, canGoForward);
        }

        protected override void OnLoadError(CefBrowser browser, CefFrame frame, CefErrorCode errorCode,
            string errorText, string failedUrl)
        {
            _owner.OnLoadError(frame, errorCode, errorText, failedUrl);
        }

        protected override void OnLoadStart(CefBrowser browser, CefFrame frame, CefTransitionType transitionType)
        {
            _owner.OnLoadStart(frame);
        }

        protected override void OnLoadEnd(CefBrowser browser, CefFrame frame, int httpStatusCode)
        {
            _owner.OnLoadEnd(frame, httpStatusCode);
        }
    }
}