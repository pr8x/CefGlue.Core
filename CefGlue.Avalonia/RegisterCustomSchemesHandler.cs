using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    public class RegisterCustomSchemesEventArgs : EventArgs
    {
        public RegisterCustomSchemesEventArgs(CefSchemeRegistrar register)
        {
            Registrar = register;
        }

        public CefSchemeRegistrar Registrar { get; }
    }

    public delegate void RegisterCustomSchemesHandler(object sender, RegisterCustomSchemesEventArgs e);
}