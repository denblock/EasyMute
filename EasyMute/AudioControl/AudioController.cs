using EasyMute.AudioControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl
{
    public class AudioController
    {
        private readonly IMMDeviceEnumerator _RealEnumerator = new MMDeviceEnumerator() as IMMDeviceEnumerator;

        public IEnumerable<CaptureDevice> GetCaptureDevices()
        {
            Marshal.ThrowExceptionForHR(_RealEnumerator.EnumAudioEndpoints(EDataFlow.eCapture, EDeviceState.DEVICE_STATE_ACTIVE, out var result));

            Marshal.ThrowExceptionForHR(result.GetCount(out var count));

            for (var i = 0u; i < count; i++)
            {
                Marshal.ThrowExceptionForHR(result.Item(i, out var device));

                yield return new CaptureDevice(device);
            }
        }
    }
}
