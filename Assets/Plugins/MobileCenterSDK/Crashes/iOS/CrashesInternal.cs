﻿#if UNITY_IOS && !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Mobile.Crashes.Internal
{
	class CrashesInternal
    {
        [DllImport("__Internal")]
        public static extern IntPtr mobile_center_unity_crashes_get_type();

        [DllImport("__Internal")]
        public static extern void mobile_center_unity_crashes_set_enabled(bool isEnabled);

        [DllImport("__Internal")]
        public static extern bool mobile_center_unity_crashes_is_enabled();

	}
}
#endif