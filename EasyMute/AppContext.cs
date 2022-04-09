using EasyMute.AudioControl;
using EasyMute.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMute
{
    public class AppContext : ApplicationContext
    {
        private readonly HotKeyWindow _HotKeyWindow = new HotKeyWindow();
        private readonly NotifyIcon _TrayIcon;

        private const int ID_MUTE_HOTKEY = 1001;

        public static readonly AudioController AudioController = new AudioController();

        public AppContext()
        {
            _HotKeyWindow.HotKeyPressed += HotKeyWindow_HotKeyPressed;
            _HotKeyWindow.RegisterHotKey(ID_MUTE_HOTKEY, Settings.Default.HotKeyModifiers, Settings.Default.HotKey);

            _TrayIcon = new NotifyIcon
            {
                Icon = Resources.not_muted,
                Text = "EasyMute",
                ContextMenu = new ContextMenu(new[]
                {
                    new MenuItem("Einstellungen", OpenSettings),
                    new MenuItem("Beenden", Exit)
                }),
                Visible = true
            };

            if (!string.IsNullOrWhiteSpace(Settings.Default.CaptureDevice))
            {
                var captureDevice = GetCaptureDevice();

                if (captureDevice != null)
                {
                    captureDevice.MuteChanged += (s, muted) => UpdateTrayIcon(muted);

                    UpdateTrayIcon(captureDevice.IsMuted);
                }
            }
        }

        private void UpdateTrayIcon(bool muted)
        {
            _TrayIcon.Icon = muted ? Resources.muted : Resources.not_muted;
        }

        private void HotKeyWindow_HotKeyPressed(object sender, int id)
        {
            switch (id)
            {
                case ID_MUTE_HOTKEY:
                    ToggleMute();
                    break;
            }
        }

        private void ToggleMute()
        {
            var captureDevice = GetCaptureDevice();

            if (captureDevice != null)
            {
                var muted = captureDevice.ToggleMute();

                UpdateTrayIcon(muted);

                if (Settings.Default.ShowNotifications)
                    _TrayIcon.ShowBalloonTip(2000, "", muted ? "Stummgeschaltet" : "Stummschaltung aufgehoben", ToolTipIcon.Info);
            }
        }

        private CaptureDevice GetCaptureDevice()
        {
            CaptureDevice captureDevice = null;

            try
            {
                var devices = AudioController.GetCaptureDevices();

                captureDevice = devices.FirstOrDefault(d => d.InterfaceName == Settings.Default.CaptureDevice);
            }
            catch
            {
            }

            if (captureDevice == null)
                _TrayIcon.ShowBalloonTip(2000, "", "Eingestelltes Mikrofon konnte nicht gefunden werden.", ToolTipIcon.Error);

            return captureDevice;
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            _HotKeyWindow.UnregisterHotKey(ID_MUTE_HOTKEY);

            var settingsForm = new SettingsForm();

            if (settingsForm.ShowDialog() == DialogResult.OK)
                Settings.Default.Save();
            else
                Settings.Default.Reload();

            _HotKeyWindow.RegisterHotKey(ID_MUTE_HOTKEY, Settings.Default.HotKeyModifiers, Settings.Default.HotKey);
        }

        private void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _TrayIcon.Visible = false;

            Application.Exit();
        }
    }
}
