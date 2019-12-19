using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class LoadStartEventArgs : EventArgs
    {
        public LoadStartEventArgs(CefFrame frame)
        {
            Frame = frame;
        }

        public CefFrame Frame { get; }
    }
}