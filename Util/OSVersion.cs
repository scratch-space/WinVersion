// Copyright (c) Vatsan Madhavan. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WinVersion.Util
{
    /// <summary>
    /// Utility class for identifying OS platform by version.
    /// </summary>
    internal class OSVersion
    {
        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1507 (TH1) or greater.
        /// </summary>
        public static bool IsWindows101507OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 10240, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1511 (TH2) or greater.
        /// </summary>
        public static bool IsWindows101511OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 10586, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1607 (RS1) or greater.
        /// </summary>
        public static bool IsWindows101607OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 14393, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1703 (RS2) or greater.
        /// </summary>
        public static bool IsWindows101703OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 15063, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1709 (RS3) or greater.
        /// </summary>
        public static bool IsWindows101709OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 16299, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1803 (RS4) or greater.
        /// </summary>
        public static bool IsWindows101803OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 17134, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 18 1809 (RS5) or greater.
        /// </summary>
        public static bool IsWindows181809OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 17763, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1903 (19H1) or greater.
        /// </summary>
        public static bool IsWindows101903OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 18362, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 1909 (19H2) or greater.
        /// </summary>
        public static bool IsWindows101909OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 18363, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 2004 (Vb) or greater.
        /// </summary>
        public static bool IsWindows102004OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 19041, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 20H2 (20H2) or greater.
        /// </summary>
        public static bool IsWindows1020H2OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 19042, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 20 21H1 (21H1) or greater.
        /// </summary>
        public static bool IsWindows2021H1OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 19043, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 10 21H2 (21H2) or greater.
        /// </summary>
        public static bool IsWindows1021H2OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 19044, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows Server 2022 (Iron) or greater.
        /// </summary>
        public static bool IsWindowsServer2022OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 20348, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is Windows 11 21H2 (Sun Valley) or greater.
        /// </summary>
        public static bool IsWindows1121H2OrGreater { get; } = VersionHelpers.IsWindowsVersionOrGreater(10, 0, 22000, 0);

        /// <summary>
        /// Gets a value indicating whether the current platform is greater than the latest known platform version, i.e., greter than Windows 11 21H2.
        /// </summary>
        public static bool IsWindowsLatestVersionOrGreater { get; } = VersionHelpers.IsWindowsBuildNumberStrictlyGreater(10, 0, 22000, 0);
    }
}
