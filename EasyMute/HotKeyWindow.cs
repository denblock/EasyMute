using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMute
{
    public class HotKeyWindow : NativeWindow
    {
        public event EventHandler<int> HotKeyPressed;

        private const int WM_HOTKEY = 0x0312;
        private const int WM_DESTROY = 0x0002;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly HashSet<int> _Registered = new HashSet<int>();

        public HotKeyWindow()
        {
            CreateHandle(new CreateParams());

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            DestroyHandle();
        }

        public void RegisterHotKey(int id, KeyModifiers fsModifiers, Keys key)
        {
            if (_Registered.Contains(id))
            {
                UnregisterHotKey(Handle, id);
            }

            if (RegisterHotKey(Handle, id, (int)fsModifiers | 0x4000, (int)key))
            {
                _Registered.Add(id);
            }
        }

        public void UnregisterHotKey(int id) => UnregisterHotKey(Handle, id);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    HotKeyPressed?.Invoke(this, m.WParam.ToInt32());
                    break;
                case WM_DESTROY:
                    foreach(var id in _Registered)
                    {
                        UnregisterHotKey(Handle, id);
                    }

                    break;
            }

            base.WndProc(ref m);
        }
    }

    [Flags]
    public enum KeyModifiers
    {
        None = 0x0000,
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008
    }
}
