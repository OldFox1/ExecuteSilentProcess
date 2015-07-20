using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ExecuteSilentProcess.ProcessHelper
{
    public class ProcessHelper
    {

        public const Int32 USE_STD_HANDLES = 0x00000100;
        public const Int32 STD_OUTPUT_HANDLE = -11;
        public const Int32 STD_ERROR_HANDLE = -12;

        //this flag instructs StartProcessWithLogonW to consider the value StartupInfo.showWindow when creating the process
        public const Int32 STARTF_USESHOWWINDOW = 0x00000001;



        public static ProcessStartResult StartProcess(string exe,
                                                      string[] args = null,
                                                      bool isHidden = false,
                                                      bool waitForExit = false,
                                                      uint waitTimeout = 0)
        {
            string command;

            var startupInfo = CreateStartupInfo(exe, args, isHidden, out command);

            ProcessInformation processInfo;

            var processSecAttributes = new SecurityAttributes();

            processSecAttributes.Length = Marshal.SizeOf(processSecAttributes);

            var threadSecAttributes = new SecurityAttributes();

            threadSecAttributes.Length = Marshal.SizeOf(threadSecAttributes);

            CreationFlags creationFlags = 0;

            if (isHidden)
            {
                creationFlags = CreationFlags.CreateNoWindow;
            }

            var started = Win32Api.CreateProcess(exe,
                                                    command,
                                                    ref processSecAttributes,
                                                    ref threadSecAttributes,
                                                    false,
                                                    Convert.ToInt32(creationFlags),
                                                    IntPtr.Zero,
                                                    null,
                                                    ref startupInfo,
                                                    out processInfo);


            var result = CreateProcessStartResult(waitForExit, waitTimeout, processInfo, started);

            return result;
        }

        private static StartupInfo CreateStartupInfo(string exe, string[] args, bool isHidden, out string command)
        {
            var startupInfo = new StartupInfo();

            startupInfo.Flags &= USE_STD_HANDLES;
            startupInfo.StdOutput = (IntPtr) STD_OUTPUT_HANDLE;
            startupInfo.StdError = (IntPtr) STD_ERROR_HANDLE;

            if (isHidden)
            {
                startupInfo.ShowWindow = 0;
                startupInfo.Flags = STARTF_USESHOWWINDOW;
            }

            command = CreateArguments(exe, args);

            return startupInfo;
        }

        private static string CreateArguments(string exe, string[] args)
        {
            if (args == null)
                return exe;

            var argsWithExeName = new string[ args.Length + 1];

            argsWithExeName[0] = exe;

            args.CopyTo(argsWithExeName, 1);

            var argsString = ToCommandLineArgsString(argsWithExeName);
            return argsString;
        }

        private static string ToCommandLineArgsString(Array array)
        {
            var argumentsBuilder = new StringBuilder();

            foreach (var item in array)
            {
                if (item != null)
                {
                    var escapedArgument = item.ToString().Replace("\"", "\"\"");
                    argumentsBuilder.AppendFormat("\"{0}\" ", escapedArgument);
                }
            }

            return argumentsBuilder.ToString();
        }

        private static ProcessStartResult CreateProcessStartResult(bool waitForExit, uint waitTimeout,
            ProcessInformation processInfo, bool started)
        {
            uint exitCode = 0;
            var hasExited = false;

            if (started && waitForExit)
            {
                var waitResult = Win32Api.WaitForSingleObject(processInfo.Process, waitTimeout);

                if (waitResult == WaitForSingleObjectResult.WAIT_OBJECT_0)
                {
                    Win32Api.GetExitCodeProcess(processInfo.Process, ref exitCode);
                    hasExited = true;
                }
            }

            var result = new ProcessStartResult()
            {
                ExitCode = (int) exitCode,
                Started = started,
                HasExited = hasExited,
                ProcessId = processInfo.ProcessId
            };
            return result;
        }

    }
}
