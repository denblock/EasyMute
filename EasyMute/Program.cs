using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMute
{
    internal static class Program
    {
        static readonly Mutex _Mutex = new Mutex(true, "EasyMuteMutex");

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!_Mutex.WaitOne(TimeSpan.Zero, false))
            {
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AppContext());
            }
            finally { _Mutex.ReleaseMutex(); }
        }
    }
}
