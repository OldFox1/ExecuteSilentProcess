using System;
using System.Runtime.InteropServices;

namespace ExecuteSilentProcess.ProcessHelper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SecurityAttributes
    {
        public int Length;
        public IntPtr SecurityDescriptor;
        public int InheritHandle;
    }
}