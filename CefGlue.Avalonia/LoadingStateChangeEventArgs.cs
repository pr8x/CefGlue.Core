using System;

namespace CefGlue.Avalonia
{
    public class LoadingStateChangeEventArgs : EventArgs
    {
        public LoadingStateChangeEventArgs(bool isLoading, bool canGoBack, bool canGoForward)
        {
            IsLoading = isLoading;
            CanGoBack = canGoBack;
            CanGoForward = canGoForward;
        }

        public bool IsLoading { get; }
        public bool CanGoBack { get; }
        public bool CanGoForward { get; }
    }
}