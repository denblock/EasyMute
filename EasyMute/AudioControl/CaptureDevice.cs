using EasyMute.AudioControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl
{
    public class CaptureDevice : IDisposable
    {
        public event EventHandler<bool> MuteChanged;

        public string InterfaceName { get; private set; }
        public bool IsMuted
        {
            get
            {
                Marshal.ThrowExceptionForHR(_AudioEndpointVolume.GetMute(out var isMuted));

                return isMuted;
            }
        }

        private readonly IAudioEndpointVolume _AudioEndpointVolume;
        private IAudioEndpointVolumeCallback _Callback;

        private static Guid IID_IAudioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
        private static readonly Guid PKEY_DeviceInterface_FriendlyName = new Guid("026E516E-B814-414B-83CD-856D6FEF4822");

        internal CaptureDevice(IMMDevice device)
        {
            Marshal.ThrowExceptionForHR(device.OpenPropertyStore(EStgmAccess.STGM_READ, out var propStore));
            Marshal.ThrowExceptionForHR(propStore.GetCount(out var propStoreCount));

            for (var i = 0; i < propStoreCount; i++)
            {
                Marshal.ThrowExceptionForHR(propStore.GetAt(i, out var key));

                if (key.fmtid == PKEY_DeviceInterface_FriendlyName)
                {
                    Marshal.ThrowExceptionForHR(propStore.GetValue(ref key, out var value));

                    InterfaceName = (string)value.Value;

                    break;
                }
            }

            Marshal.ThrowExceptionForHR(device.Activate(ref IID_IAudioEndpointVolume, CLSCTX.INPROC, IntPtr.Zero, out var result));

            _AudioEndpointVolume = result as IAudioEndpointVolume;

            _Callback = new AudioEndpointVolumeCallback(this);
            Marshal.ThrowExceptionForHR(_AudioEndpointVolume.RegisterControlChangeNotify(_Callback));
        }

        public bool ToggleMute()
        {
            var isMuted = IsMuted;

            Marshal.ThrowExceptionForHR(_AudioEndpointVolume.SetMute(!isMuted, Guid.Empty));

            return !isMuted;
        }

        internal void InvokeMuteChanged(bool mute)
        {
            MuteChanged?.Invoke(this, mute);
        }

        public void Dispose()
        {
           if (_Callback != null)
            {
                Marshal.ThrowExceptionForHR(_AudioEndpointVolume.UnregisterControlChangeNotify(_Callback));
                _Callback = null;
            }
        }
    }
}
