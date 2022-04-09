using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl.Interfaces
{
    [Flags]
    internal enum EDeviceState : uint
    {
        DEVICE_STATE_ACTIVE = 0x00000001,
        DEVICE_STATE_UNPLUGGED = 0x00000002,
        DEVICE_STATE_NOTPRESENT = 0x00000004,
        DEVICE_STATEMASK_ALL = 0x00000007
    }
}
