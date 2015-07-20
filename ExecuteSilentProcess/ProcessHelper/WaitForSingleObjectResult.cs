using System;

namespace ExecuteSilentProcess.ProcessHelper
{
    public static class WaitForSingleObjectResult
    {
        /// <summary>
        /// The specified object is a mutex object that was not released by the thread that owned the mutex
        /// object before the owning thread terminated. Ownership of the mutex object is granted to the 
        /// calling thread and the mutex state is set to nonsignaled
        /// </summary>
        public const UInt32 WAIT_ABANDONED = 0x00000080;
        /// <summary>
        /// The state of the specified object is signaled.
        /// </summary>
        public const UInt32 WAIT_OBJECT_0 = 0x00000000;
        /// <summary>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </summary>
        public const UInt32 WAIT_TIMEOUT = 0x00000102;
    }
}