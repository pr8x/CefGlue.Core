using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class LoadEndEventArgs : EventArgs
    {
        public LoadEndEventArgs(CefFrame frame, int httpStatusCode)
        {
            Frame = frame;
            HttpStatusCode = httpStatusCode;
        }

        public int HttpStatusCode { get; }

        public CefFrame Frame { get; }
    }
}