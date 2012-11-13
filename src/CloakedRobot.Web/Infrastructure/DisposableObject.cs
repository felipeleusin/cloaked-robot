using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloakedRobot.Web.Infrastructure
{
    public abstract class DisposableObject : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                OnDisposing(disposing);
            }
        }

        protected abstract void OnDisposing(bool disposing);

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}