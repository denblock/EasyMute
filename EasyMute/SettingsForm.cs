using EasyMute.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyMute
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            Icon = Resources.not_muted;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var captureDevices = AppContext.AudioController.GetCaptureDevices();

            foreach (var device in captureDevices)
            {
                CaptureDevicesComboBox.Items.Add(device.InterfaceName);
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.CaptureDevice))
                CaptureDevicesComboBox.SelectedItem = Settings.Default.CaptureDevice;

            HotKeyTextBox.Text = GetHotKeyString();

            SoundsCheckBox.Checked = Settings.Default.PlaySounds;
            NotificationsCheckBox.Checked = Settings.Default.ShowNotifications;
        }

        private void CaptureDevicesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Default.CaptureDevice = CaptureDevicesComboBox.SelectedItem as string;
        }

        private void HotKeyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Alt && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.LWin && e.KeyCode != Keys.Menu && e.KeyCode != Keys.Capital)
            {
                var modifiers = KeyModifiers.None;

                if (e.Control)
                    modifiers |= KeyModifiers.Ctrl;

                if(e.Shift)
                    modifiers |= KeyModifiers.Shift;

                if (e.Alt)
                    modifiers |= KeyModifiers.Alt;

                Settings.Default.HotKeyModifiers = modifiers;
                Settings.Default.HotKey = e.KeyCode;

                HotKeyTextBox.Text = GetHotKeyString();
            }
        }

        private void SoundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PlaySounds = SoundsCheckBox.Checked;
        }

        private void NotificationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.ShowNotifications = NotificationsCheckBox.Checked;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private static string GetHotKeyString()
        {
            var modifiers = Settings.Default.HotKeyModifiers;
            var key = Settings.Default.HotKey;

            return $"{(modifiers.HasFlag(KeyModifiers.Ctrl) ? "STRG+" : "")}{(modifiers.HasFlag(KeyModifiers.Shift) ? "SHIFT+" : "")}{(modifiers.HasFlag(KeyModifiers.Alt) ? "ALT+" : "")}{key}";
        }
    }
}
