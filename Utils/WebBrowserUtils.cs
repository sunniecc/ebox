using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace EBoxClient
{
    public class WebBrowserUtils
    {
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        public static void SetIEVersion()
        {
            if (IntPtr.Size == 8)
            {
                var reg = @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
                Utils.RegistryHelper helper = new Utils.RegistryHelper(reg, Registry.LocalMachine);
                helper.SaveValue(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location),
                    9000, RegistryValueKind.DWord);
            }
            else
            {
                var reg = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
                Utils.RegistryHelper helper = new Utils.RegistryHelper(reg, Registry.LocalMachine);
                helper.SaveValue(Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location),
                    9000, RegistryValueKind.DWord);
            }
        }

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        public static void ClearSession()
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
        }

        public static void ChangeUserAgent(string userAgent)
        {
            UserAgentHelper.ChangeUserAgent(userAgent);
        }

        public static void DisableSound()
        { UnmanagedCode.DisableSound(); }

        public static class UnmanagedCode
        {
            private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
            private const int SET_FEATURE_ON_THREAD = 0x00000001;
            private const int SET_FEATURE_ON_PROCESS = 0x00000002;
            private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
            private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
            private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
            private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
            private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
            private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;

            [DllImport("urlmon.dll")]
            [PreserveSig]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern int CoInternetSetFeatureEnabled(int FeatureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, bool fEnable);

            public static void DisableSound()
            {
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_IN_REGISTRY, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD_LOCALMACHINE, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD_INTRANET, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD_TRUSTED, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD_INTERNET, true);
                UnmanagedCode.CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_THREAD_RESTRICTED, true);
            }
        }
    }
}
