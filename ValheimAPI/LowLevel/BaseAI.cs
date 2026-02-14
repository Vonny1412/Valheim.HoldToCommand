using BaseAI_Alias = BaseAI;

namespace HoldToCommand.ValheimAPI.LowLevel
{
    public partial class BaseAI : UnityEngine.MonoBehaviour
    {
        public BaseAI(BaseAI_Alias instance) : base(instance)
        {
        }

        public static readonly Core.Invokers.VoidMethodInvoker __IAPI_SetAlerted_Invoker1 = new Core.Invokers.VoidMethodInvoker(typeof(BaseAI_Alias), "SetAlerted", new Core.Signatures.ParamSig[] { new Core.Signatures.NonGenericParamSig(typeof(bool), false) });
        public static readonly Core.Invokers.FieldMutateInvoker<float> __IAPI_m_fleeTargetUpdateTime_Invoker = new Core.Invokers.FieldMutateInvoker<float>(typeof(BaseAI_Alias), "m_fleeTargetUpdateTime");
    
    }
}