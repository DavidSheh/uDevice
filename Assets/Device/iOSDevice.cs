#if UNITY_IOS
using System.Runtime.InteropServices;
using UnityEngine;

namespace uDevice.Internal.Device
{
    public class iOSDevice : BaseDevice
    {
        [DllImport("__Internal")]
        private static extern string _foo();
        public override string Foo()
        {
            return _foo();
        }
}
#endif
