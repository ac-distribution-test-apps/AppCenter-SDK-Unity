// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if UNITY_WSA_10_0 && !UNITY_EDITOR
using Microsoft.AppCenter.Unity.Analytics.Internal;
using System;
using System.Collections.Generic;

namespace Microsoft.AppCenter.Unity.Analytics
{
    public class WrapperTransmissionTargetInternal
    {
        public static void TrackEvent(object transmissionTarget, string eventName)
        {
        }

        public static void TrackEventWithProperties(object transmissionTarget, string eventName, IDictionary<string, string> properties)
        {
        }

        public static AppCenterTask SetEnabledAsync(object transmissionTarget, bool enabled)
        {
            return AppCenterTask.FromCompleted();
        }

        public static AppCenterTask<bool> IsEnabledAsync(object transmissionTarget)
        {
            return AppCenterTask<bool>.FromCompleted(false);
        }

        public static Type GetTransmissionTarget(object transmissionTargetParent, string transmissionTargetToken)
        {
            return null;
        }

        public static Type GetPropertyConfigurator(object transmissionTargetParent)
        {
            return null;
        }
    }
}
#endif