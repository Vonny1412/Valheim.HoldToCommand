using Tameable_Alias = Tameable;

namespace HoldToCommand.ValheimAPI.LowLevel
{
    public partial class Tameable : UnityEngine.MonoBehaviour
    {
        public Tameable(Tameable_Alias instance) : base(instance)
        {
        }

        public static readonly Core.Invokers.FieldMutateInvoker<float> __IAPI_m_lastPetTime_Invoker = new Core.Invokers.FieldMutateInvoker<float>(typeof(Tameable_Alias), "m_lastPetTime");
        public static readonly Core.Invokers.VoidMethodInvoker __IAPI_SetName_Invoker1 = new Core.Invokers.VoidMethodInvoker(typeof(Tameable_Alias), "SetName", new Core.Signatures.ParamSig[] { });
    
    }
}