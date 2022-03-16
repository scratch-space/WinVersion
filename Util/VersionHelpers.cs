// Copyright (c) Vatsan Madhavan. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WinVersion.Util
{
    using PInvoke;

    /// <summary>
    /// Contains helper routines for identifying the Platform version.
    /// </summary>
    internal class VersionHelpers
    {
        /// <summary>
        /// Retrieves the high-order byte from the given 16-bit value.
        /// </summary>
        /// <param name="n">The value to be converted.</param>
        /// <returns>The return value is the high-order byte of the specified value.</returns>
        public static byte HiByte(ushort n)
        {
            return (byte)(n >> 8);
        }

        /// <summary>
        /// Retrieves teh low-order byte from a specified value.
        /// </summary>
        /// <param name="n">The value to be converted.</param>
        /// <returns>The return value is the low-order byte of the specified value.</returns>
        public static byte LoByte(ushort n)
        {
            return (byte)(n & 0x00ff);
        }

        /// <summary>
        /// Indicates if the current OS version matches, or is greater than, the Windows version specified by the parameters.
        /// </summary>
        /// <param name="wMajorVersion">The major version number of the operating system.</param>
        /// <param name="wMinorVersion">The minor version number of the operating system.</param>
        /// <param name="wBuildNumber">The build number of the operating system.</param>
        /// <param name="wServicePackMajor">
        /// The major version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the major version number is 3. If no Service Pack has been installed, the value is zero.
        /// </param>
        /// <returns>True if the current OS version matches, or is greater than, the Windows version specified by the parameters; otherwise, false.</returns>
        public static bool IsWindowsVersionOrGreater(int wMajorVersion, int wMinorVersion, int wBuildNumber, short wServicePackMajor)
        {
            var osvi = Kernel32.OSVERSIONINFOEX.Create();
            osvi.dwMajorVersion = wMajorVersion;
            osvi.dwMinorVersion = wMinorVersion;
            osvi.dwBuildNumber = wBuildNumber;
            osvi.wServicePackMajor = wServicePackMajor;

            long dwlConditionMask = 0;
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_MAJORVERSION, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_MINORVERSION, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_SERVICEPACKMAJOR, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);

            var dwFlags = Kernel32.VER_MASK.VER_MAJORVERSION | Kernel32.VER_MASK.VER_MINORVERSION | Kernel32.VER_MASK.VER_SERVICEPACKMAJOR;
            if (wBuildNumber > 0)
            {
                dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_BUILDNUMBER, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
                dwFlags |= Kernel32.VER_MASK.VER_BUILDNUMBER;
            }

            return NTDll.RtlVerifyVersionInfo(ref osvi, dwFlags, dwlConditionMask).Value == NTSTATUS.Code.STATUS_SUCCESS;
        }

        /// <summary>
        /// Indicates if the current OS is greater than the Windows version specified by the parameters.
        /// </summary>
        /// <param name="wMajorVersion">The major version number of the operating system.</param>
        /// <param name="wMinorVersion">The minor version number of the operating system.</param>
        /// <param name="wBuildNumber">The build number of the operating system.</param>
        /// <param name="wServicePackMajor">
        /// The major version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the major version number is 3. If no Service Pack has been installed, the value is zero.
        /// </param>
        /// <returns>True if the current OS is greater than the Windows version specified by the parameters; otherwise, false.</returns>
        public static bool IsWindowsBuildNumberStrictlyGreater(int wMajorVersion, int wMinorVersion, int wBuildNumber, short wServicePackMajor)
        {
            var osvi = Kernel32.OSVERSIONINFOEX.Create();
            osvi.dwMajorVersion = wMajorVersion;
            osvi.dwMinorVersion = wMinorVersion;
            osvi.dwBuildNumber = wBuildNumber;
            osvi.wServicePackMajor = wServicePackMajor;

            var dwFlags =
                Kernel32.VER_MASK.VER_MAJORVERSION |
                Kernel32.VER_MASK.VER_MINORVERSION |
                Kernel32.VER_MASK.VER_SERVICEPACKMAJOR |
                Kernel32.VER_MASK.VER_BUILDNUMBER;

            long dwlConditionMask = 0;
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_MAJORVERSION, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_MINORVERSION, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_SERVICEPACKMAJOR, Kernel32.VER_CONDITION.VER_GREATER_EQUAL);
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_BUILDNUMBER, Kernel32.VER_CONDITION.VER_GREATER);

            return NTDll.RtlVerifyVersionInfo(ref osvi, dwFlags, dwlConditionMask).Value == NTSTATUS.Code.STATUS_SUCCESS;
        }

        /// <summary>
        /// Indicates if the current OS is a Windows Server edition.
        /// </summary>
        /// <returns>True if the current OS is a Windows Server edition; otherwise, false.</returns>
        public static bool IsWindowsServer()
        {
            // We'd like to test for any version that does NOT match VER_NT_WORKSTATION
            var osvi = Kernel32.OSVERSIONINFOEX.Create();
            osvi.wProductType = Kernel32.OS_TYPE.VER_NT_WORKSTATION;

            long dwlConditionMask = 0;
            dwlConditionMask = Kernel32.VerSetConditionMask(dwlConditionMask, Kernel32.VER_MASK.VER_PRODUCT_TYPE, Kernel32.VER_CONDITION.VER_EQUAL);

            return NTDll.RtlVerifyVersionInfo(ref osvi, Kernel32.VER_MASK.VER_PRODUCT_TYPE, dwlConditionMask).Value != NTSTATUS.Code.STATUS_SUCCESS;
        }
    }
}
