using System;

namespace ExecuteSilentProcess.ProcessHelper
{
    public struct ProcessInformation
    {
        public IntPtr Process { get; set; }
        public IntPtr Thread { get; set; }
        public int ProcessId { get; set; }
        public int ThreadId { get; set; }
    }
}