// Copyright (c) Vatsan Madhavan. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1200 // Using directives should be placed correctly
using WinVersion.Util;

if (!OSVersion.IsWindows101607OrGreater)
{
    Console.WriteLine("Older than RS1");
}
else if (OSVersion.IsWindows101607OrGreater && !OSVersion.IsWindows101703OrGreater)
{
    Console.WriteLine("RS1");
}
else if (OSVersion.IsWindows181809OrGreater && !OSVersion.IsWindows101903OrGreater)
{
    Console.WriteLine("RS5");
}
else if (OSVersion.IsWindows101903OrGreater && !OSVersion.IsWindows102004OrGreater)
{
    Console.WriteLine("19H1/19H2");
}
else if (OSVersion.IsWindows102004OrGreater && !OSVersion.IsWindowsServer2022OrGreater)
{
    Console.WriteLine("Vb");
}
else if (OSVersion.IsWindowsServer2022OrGreater && !OSVersion.IsWindows1121H2OrGreater)
{
    Console.WriteLine("Fe");
}
else if (OSVersion.IsWindows1121H2OrGreater && !OSVersion.IsWindowsLatestVersionOrGreater)
{
    Console.WriteLine("Win11");
}
else if (OSVersion.IsWindowsLatestVersionOrGreater)
{
    Console.WriteLine("Latest version (newer than Win11)");
}
