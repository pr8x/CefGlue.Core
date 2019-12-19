﻿using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class LoadErrorEventArgs : EventArgs
    {
        public LoadErrorEventArgs(CefFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
        {
            Frame = frame;
            ErrorCode = errorCode;
            ErrorText = errorText;
            FailedUrl = failedUrl;
        }

        public string FailedUrl { get; }

        public string ErrorText { get; }

        public CefErrorCode ErrorCode { get; }

        public CefFrame Frame { get; }
    }
}