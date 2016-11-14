using System;

namespace uDevice.Internal.Device
{
    public abstract class BaseDevice
    {
        private static BaseDevice device = null;

        protected BaseDevice()
        {
			Init();
		}

        /// <summary>
        /// 获取设备
        /// </summary>
        /// <returns></returns>
        public static BaseDevice GetDevice()
        {
            if (device == null)
            {
#if UNITY_EDITOR || UNITY_STANDALONE || DEBUG
        device = new EditorDevice();
#elif UNITY_ANDROID
        device = new AndroidDevice();
#elif UNITY_IOS
        device = new iOSDevice();
#else
        throw new InvalidOperationException("Unsupported device.");
#endif
			}
			return device;
        }

		protected virtual void Init() { }

        /// <summary>
        /// 示例方法
        /// </summary>
        /// <returns></returns>
        public virtual string Foo()
        {
            return "";
        }
    }
}
