#if UNITY_ANDROID
using UnityEngine;

namespace uDevice.Internal.Device
{
    public abstract class BaseAndroidDevice :  BaseDevice
    {
        protected AndroidJavaObject androidActivity;

        /// <summary>
        /// 连接Android的UnityPlayer的Activity
        /// </summary>
        protected virtual void ConnectToActivity()
        {
            try
            {
                using (AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    androidActivity = player.GetStatic<AndroidJavaObject>("currentActivity");
                }
            }
            catch (AndroidJavaException e)
            {
                androidActivity = null;
                Debug.LogError("Exception while connecting to the Activity: " + e);
            }
        }

        /// <summary>
        /// 获取Java类（无参构造方法）
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static AndroidJavaClass GetClass(string className)
        {
            try
            {
                return new AndroidJavaClass(className);
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception getting class " + className + ": " + e);
                return null;
            }
        }

        /// <summary>
        /// 实例化Java对象（有参构造方法）
        /// </summary>
        /// <param name="className"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static AndroidJavaObject Create(string className, params object[] args)
        {
            try
            {
                return new AndroidJavaObject(className, args);
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception creating object " + className + ": " + e);
                return null;
            }
        }

        /// <summary>
        /// 调用Java无返回值得静态方法
        /// </summary>
        /// <param name="jo"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool CallStaticMethod(AndroidJavaObject jo, string name, params object[] args)
        {
            if (jo == null)
            {
                Debug.LogError("Object is null when calling static method " + name);
                return false;
            }
            try
            {
                jo.CallStatic(name, args);
                return true;
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception calling static method " + name + ": " + e);
                return false;
            }
        }

        /// <summary>
        /// 调用Java无返回值的一般方法
        /// </summary>
        /// <param name="jo"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool CallObjectMethod(AndroidJavaObject jo, string name, params object[] args)
        {
            if (jo == null)
            {
                Debug.LogError("Object is null when calling method " + name);
                return false;
            }
            try
            {
                jo.Call(name, args);
                return true;
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception calling method " + name + ": " + e);
                return false;
            }
        }

        /// <summary>
        /// 调用Java有返回值的静态方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jo"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CallStaticMethod<T>(AndroidJavaObject jo, string name, params object[] args)
        {
            if (jo == null)
            {
                Debug.LogError("Object is null when calling static method " + name);
                return default(T);
            }
            try
            {
                return jo.CallStatic<T>(name, args);
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception calling static method " + name + ": " + e);
                return default(T);
            }
        }

        /// <summary>
        /// 调用Java有返回值的一般方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jo"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CallObjectMethod<T>(AndroidJavaObject jo, string name, params object[] args)
        {
            if (jo == null)
            {
                Debug.LogError("Object is null when calling method " + name);
                return default(T);
            }
            try
            {
                return jo.Call<T>(name, args);
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError("Exception calling method " + name + ": " + e);
                return default(T);
            }
        }
    }
}

#endif