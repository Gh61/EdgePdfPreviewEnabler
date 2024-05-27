using System;
using System.Runtime.InteropServices;

namespace Gh61.EdgePdfPreviewEnabler
{
    internal static class ConsoleManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        private const uint ATTACH_PARENT_PROCESS = 0xFFFFFFFF;

        /// <summary>
        /// If the application is run from console, it will attach it to this process, so we can write to the console.
        /// If not, it returns false.
        /// </summary>
        /// <remarks>
        /// After all writings to console is done, call <see cref="DetachConsole"/> method.
        /// </remarks>
        public static bool TryAttachConsole()
        {
            return AttachConsole(ATTACH_PARENT_PROCESS);
        }

        /// <summary>
        /// Will detach console after successful <see cref="TryAttachConsole"/> call.
        /// </summary>
        public static void DetachConsole()
        {
            Console.Out.Flush();
            FreeConsole();
        }
    }
}
