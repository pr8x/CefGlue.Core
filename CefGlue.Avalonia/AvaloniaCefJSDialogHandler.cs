using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class AvaloniaCefJSDialogHandler : CefJSDialogHandler
    {
        protected override bool OnJSDialog(CefBrowser browser, string originUrl, CefJSDialogType dialogType,
            string message_text, string default_prompt_text, CefJSDialogCallback callback, out bool suppress_message)
        {
            bool success;
            string input = null;

            switch (dialogType)
            {
                case CefJSDialogType.Alert:
                    success = ShowJSAlert(message_text);
                    break;
                case CefJSDialogType.Confirm:
                    success = ShowJSConfirm(message_text);
                    break;
                case CefJSDialogType.Prompt:
                    success = ShowJSPromt(message_text, default_prompt_text, out input);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dialogType), dialogType, null);
            }

            callback.Continue(success, input);
            suppress_message = false;
            return true;
        }

        protected override bool OnBeforeUnloadDialog(CefBrowser browser, string messageText, bool isReload,
            CefJSDialogCallback callback)
        {
            return true;
        }

        protected override void OnDialogClosed(CefBrowser browser)
        {
        }

        protected override void OnResetDialogState(CefBrowser browser)
        {
        }

        private static bool ShowJSAlert(string message)
        {
            var alert = new AvaloniaCefJSAlert(message);

            return true;
        }

        private static bool ShowJSConfirm(string message)
        {
            var confirm = new AvaloniaCefJSConfirm(message);

            return true;
        }

        private static bool ShowJSPromt(string message, string defaultText, out string input)
        {
            var promt = new AvaloniaCefJSPrompt(message, defaultText);

            input = "not implemented.";

            return true;
        }
    }
}