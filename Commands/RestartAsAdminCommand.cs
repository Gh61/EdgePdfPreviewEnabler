using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    internal class RestartAsAdminCommand : UICommandBase<object>
    {
        public static RestartAsAdminCommand Instance { get; } = new RestartAsAdminCommand();

        private RestartAsAdminCommand()
            : base("Restart as Administrator")
        {
        }

        protected override void Execute(object parameter)
        {
            var exePath = Assembly.GetExecutingAssembly().Location;

            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = exePath,
                    UseShellExecute = true,
                    Verb = "runas"
                }
            };

            var isElevated = false;
            try
            {
                proc.Start();
                isElevated = true;
            }
            catch (Exception)
            {
                // user canceled the elevation prompt
            }

            if (isElevated)
            {
                // close current application
                Application.Current.Shutdown();
            }
        }
    }
}
