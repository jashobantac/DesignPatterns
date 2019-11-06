using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace CSharpAndWPF.MemoryManagement
{
    public class JcbSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        // Pointer to an external unmanaged resource. 
        private IntPtr _handle;
        // Other managed resource this class uses. 
        private readonly Component _component = new Component();
        // Track whether Dispose has been called. 
        private readonly bool _disposed = false;

        // Use interop to call the method necessary 
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private static extern bool CloseHandle(IntPtr handle);

        public JcbSafeHandle(IntPtr handle) : base(true)
        {
            _handle = handle;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            _component.Dispose();

            CloseHandle(_handle);
            _handle = IntPtr.Zero;
            return true;
        }
    }
}
