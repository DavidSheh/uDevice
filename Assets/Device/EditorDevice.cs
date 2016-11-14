#if UNITY_EDITOR || UNITY_STANDALONE || DEBUG

namespace uDevice.Internal.Device
{
    public class EditorDevice : BaseDevice
    {
        public override string Foo()
        {
            return "EditorDivice";
        }
    }
}
#endif

