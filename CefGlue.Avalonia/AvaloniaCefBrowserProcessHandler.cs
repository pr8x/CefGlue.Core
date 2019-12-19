using System;
using System.Reactive.Linq;
using Avalonia.Threading;
using Xilium.CefGlue;

namespace CefGlue.Avalonia
{
    internal sealed class AvaloniaCefBrowserProcessHandler : CefBrowserProcessHandler
    {
        private IDisposable _current;
        private readonly object schedule = new object();

        protected override void OnScheduleMessagePumpWork(long delayMs)
        {
            lock (schedule)
            {
                _current?.Dispose();

                if (delayMs <= 0)
                {
                    delayMs = 1;
                }

                _current = Observable.Interval(TimeSpan.FromMilliseconds(delayMs)).ObserveOn(AvaloniaScheduler.Instance)
                    .Subscribe(i => { CefRuntime.DoMessageLoopWork(); });
            }
        }
    }
}