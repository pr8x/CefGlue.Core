﻿using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class AvaloniaCefRenderProcessHandler : CefRenderProcessHandler
    {
        protected override bool OnProcessMessageReceived(CefBrowser browser, CefProcessId sourceProcess,
            CefProcessMessage message)
        {
            if (message.Name != "executeJs")
            {
                return false;
            }

            var context = browser.GetMainFrame().V8Context;

            context.TryEval(message.Arguments.GetString(0), message.Arguments.GetString(1), 1, out var value,
                out var exception);

            var response = CefProcessMessage.Create("executeJsResult");

            if (value.IsString)
            {
                response.Arguments.SetString(0, value.GetStringValue());
            }

            browser.SendProcessMessage(CefProcessId.Browser, response);
            return true;

        }

        public event EventHandler WebKitInitialized;

        protected override void OnWebKitInitialized()
        {
            WebKitInitialized?.Invoke(this, EventArgs.Empty);
            base.OnWebKitInitialized();
        }
    }
}