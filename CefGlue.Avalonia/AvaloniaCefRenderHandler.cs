using System;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal sealed class AvaloniaCefRenderHandler : CefRenderHandler
    {
        private readonly AvaloniaCefBrowser _owner;

        public AvaloniaCefRenderHandler(AvaloniaCefBrowser owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        protected override bool GetRootScreenRect(CefBrowser browser, ref CefRectangle rect)
        {
            return _owner.GetViewRect(ref rect);
        }

        protected override bool GetViewRect(CefBrowser browser, ref CefRectangle rect)
        {
            return _owner.GetViewRect(ref rect);
        }

        protected override bool GetScreenPoint(CefBrowser browser, int viewX, int viewY, ref int screenX,
            ref int screenY)
        {
            _owner.GetScreenPoint(viewX, viewY, ref screenX, ref screenY);
            return true;
        }

        protected override bool GetScreenInfo(CefBrowser browser, CefScreenInfo screenInfo)
        {
            return false;
        }

        protected override void OnPopupShow(CefBrowser browser, bool show)
        {
            //_owner.OnPopupShow(show);
        }

        protected override void OnPopupSize(CefBrowser browser, CefRectangle rect)
        {
            // _owner.OnPopupSize(rect);
        }

        protected override void OnPaint(CefBrowser browser, CefPaintElementType type, CefRectangle[] dirtyRects,
            IntPtr buffer, int width, int height)
        {
            if (type == CefPaintElementType.View)
            {
                _owner.HandleViewPaint(browser, type, dirtyRects, buffer, width, height);
            }
            //else if (type == CefPaintElementType.Popup)
            //{
            //    _owner.HandlePopupPaint(width, height, dirtyRects, buffer);
            //}
        }

        protected override void OnCursorChange(CefBrowser browser, IntPtr cursorHandle, CefCursorType type,
            CefCursorInfo customCursorInfo)
        {
        }

        protected override void OnScrollOffsetChanged(CefBrowser browser, double x, double y)
        {
        }

        protected override void OnImeCompositionRangeChanged(CefBrowser browser, CefRange selectedRange,
            CefRectangle[] characterBounds)
        {
        }
    }
}