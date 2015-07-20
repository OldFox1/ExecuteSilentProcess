using System;
using System.Runtime.InteropServices;

namespace ExecuteSilentProcess.ProcessHelper
{
    public class Win32Api
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeProcess(IntPtr process, ref UInt32 exitCode);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr handle, UInt32 milliseconds);

        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess
            (string lpApplicationName,
                string lpCommandLine,
                ref SecurityAttributes lpProcessAttributes,
                ref SecurityAttributes lpThreadAttributes,
                bool bInheritHandles,
                Int32 dwCreationFlags,
                IntPtr lpEnvironment,
                string lpCurrentDirectory,
                [In] ref StartupInfo lpStartupInfo,
                out ProcessInformation lpProcessInformation);
    }
}