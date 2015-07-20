using System;

namespace ExecuteSilentProcess.ProcessHelper
{
    public class ProcessStartResult
    {
        public bool Started { get; set; }
  
        public int ExitCode { get; set; }

        public bool HasExited { get; set; }

        public Exception Error { get; set; }
        public int ProcessId { get; set; }
    }
}