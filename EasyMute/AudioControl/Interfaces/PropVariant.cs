using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyMute.AudioControl.Interfaces
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct PropVariant
    {
        [FieldOffset(0)] short vt;
        [FieldOffset(2)] short wReserved1;
        [FieldOffset(4)] short wReserved2;
        [FieldOffset(6)] short wReserved3;
        [FieldOffset(8)] sbyte cVal;
        [FieldOffset(8)] byte bVal;
        [FieldOffset(8)] short iVal;
        [FieldOffset(8)] ushort uiVal;
        [FieldOffset(8)] int lVal;
        [FieldOffset(8)] uint ulVal;
        [FieldOffset(8)] long hVal;
        [FieldOffset(8)] ulong uhVal;
        [FieldOffset(8)] float fltVal;
        [FieldOffset(8)] double dblVal;
        [FieldOffset(8)] int blobVal;
        [FieldOffset(8)] DateTime date;
        [FieldOffset(8)] bool boolVal;
        [FieldOffset(8)] int scode;
        [FieldOffset(8)] System.Runtime.InteropServices.ComTypes.FILETIME filetime;
        [FieldOffset(8)] IntPtr everything_else;

        public object Value
        {
            get
            {
                VarEnum ve = (VarEnum)vt;
                switch (ve)
                {
                    case VarEnum.VT_I1:
                        return bVal;
                    case VarEnum.VT_I2:
                        return iVal;
                    case VarEnum.VT_I4:
                        return lVal;
                    case VarEnum.VT_I8:
                        return hVal;
                    case VarEnum.VT_INT:
                        return iVal;
                    case VarEnum.VT_UI4:
                        return ulVal;
                    case VarEnum.VT_LPWSTR:
                        return Marshal.PtrToStringUni(everything_else);
                }
                return "FIXME Type = " + ve.ToString();
            }
        }
    }
}
