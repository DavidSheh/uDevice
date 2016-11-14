#if UNITY_ANDROID
using System;
using UnityEngine;

namespace uDevice.Internal.Device
{
    public class AndroidDevice : BaseAndroidDevice
    {
        private const string unityTools = "com.xx.xxx";

        private static AndroidJavaClass ajc;

        protected override void Init()
        {
            if (ajc == null)
            {
                ajc = GetClass(unityTools);
            }
        }

        public override string Foo()
        {
            return CallStaticMethod<string>(ajc, "foo");
        }
    }
}
#endif
