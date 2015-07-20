using System;

namespace ExecuteSilentProcess.ProcessHelper
{
    public struct StartupInfo
    {
        public int Cb;
        public String Reserved;
        public String Desktop;
        public String Title;
        public int X;
        public int Y;
        public int XSize;
        public int YSize;
        public int XCountChars;
        public int YCountChars;
        public int FillAttribute;
        public int Flags;
        public UInt16 ShowWindow;
        public UInt16 Reserved2;
        public byte Reserved3;
        public IntPtr StdInput;
        public IntPtr StdOutput;
        public IntPtr StdError;
    }
}