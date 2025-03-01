﻿using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class BrowserCreatedEventArgs : EventArgs
    {
        public BrowserCreatedEventArgs(CefBrowser browser)
        {
            Browser = browser;
        }

        public CefBrowser Browser { get; }
    }

    public delegate void BrowserCreatedHandler(object sender, BrowserCreatedEventArgs e);
}