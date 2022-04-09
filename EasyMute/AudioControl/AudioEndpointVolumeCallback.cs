using EasyMute.AudioControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl
{
    internal class AudioEndpointVolumeCallback : IAudioEndpointVolumeCallback
    {
        private readonly CaptureDevice _Device;

        internal AudioEndpointVolumeCallback(CaptureDevice device)
        {
            _Device = device;
        }

        [PreserveSig]
        public int OnNotify(IntPtr notifyData)
        {
            var data = Marshal.PtrToStructure<AUDIO_VOLUME_NOTIFICATION_DATA>(notifyData);

            _Device.InvokeMuteChanged(data.bMuted);

            return 0;
        }
    }
}
