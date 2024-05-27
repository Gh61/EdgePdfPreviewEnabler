using System;
using System.Globalization;
using System.Threading;

namespace Gh61.EdgePdfPreviewEnabler
{
    public static class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args.Length != 2)
                    return ArgumentsHelp();

                if (args[0] != "-culture")
                    return ArgumentsHelp();

                var cultureName = args[1];
                CultureInfo ci;
                try
                {
                    ci = CultureInfo.GetCultureInfo(cultureName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return ArgumentsHelp();
                }

                // set the UI culture
                Thread.CurrentThread.CurrentUICulture = ci;
            }

            // run default App instance
            App.Main();

            return 0;
        }

        private static int ArgumentsHelp()
        {
            Console.WriteLine(@"The application supports only this arguments:");
            Console.WriteLine(@"-culture en-US");

            // error code
            return 1;
        }
    }
}
