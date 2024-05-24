using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using Gh61.EdgePdfPreviewEnabler.Localization;

namespace Gh61.EdgePdfPreviewEnabler.Commands
{
    public class RestartAsAdminCommand : UICommandBase<object>
    {
        public static RestartAsAdminCommand Instance { get; } = new RestartAsAdminCommand();

        private RestartAsAdminCommand() : base(Resources.CommandRestartAsAdmin)
        {
        }

        protected override void Execute(object parameter)
        {
            var exePath = Assembly.GetExecutingAssembly().Location;

            var proc = new Process()
            {
                StartInfo =
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
