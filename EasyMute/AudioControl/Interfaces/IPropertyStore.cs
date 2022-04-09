using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl.Interfaces
{
    [Guid("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPropertyStore
    {
        [PreserveSig]
        int GetCount(out int count);
        [PreserveSig]
        int GetAt(int iProp, out PropertyKey pkey);
        [PreserveSig]
        int GetValue(ref PropertyKey key, out PropVariant pv);
    }
}
