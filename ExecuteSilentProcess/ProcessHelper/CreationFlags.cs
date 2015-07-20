using System;

namespace ExecuteSilentProcess.ProcessHelper
{
    [Flags]
    public enum CreationFlags
    {
        CreateSuspended = 0x00000004,

        CreateNewConsole = 0x00000010,

        CreateNewProcessGroup = 0x00000200,

        CreateNoWindow = 0x08000000,

        CreateUnicodeEnvironment = 0x00000400,

        CreateSeparateWowVdm = 0x00000800,

        CreateDefaultErrorMode = 0x04000000,
    }
}