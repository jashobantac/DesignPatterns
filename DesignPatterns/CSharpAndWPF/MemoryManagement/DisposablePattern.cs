using System;
using System.ComponentModel;

namespace CSharpAndWPF.MemoryManagement
{
    public class DisposablePattern : IDisposable
    {
        // Pointer to an external unmanaged resource. 
        private IntPtr _handle;
        // Other managed resource this class uses. 
        private readonly Component _component = new Component();
        // Track whether Dispose has been called. 
        private bool _disposed = false;

        // Use interop to call the method necessary 
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Creates an instance of type <see cref="DisposablePattern"/>
        /// </summary>
        /// <param name="handle">IntPtr Handle.</param>
        public DisposablePattern(IntPtr handle)
        {
            _handle = handle;
        }

        private void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    _component.Dispose();
                }

                CloseHandle(_handle);
                _handle = IntPtr.Zero;
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer (Destructor)
        /// </summary>
        ~DisposablePattern()
        {
            Dispose(false);
        }
    }
}
