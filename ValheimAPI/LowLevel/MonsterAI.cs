using MonsterAI_Alias = MonsterAI;

namespace HoldToCommand.ValheimAPI.LowLevel
{
    public partial class MonsterAI : BaseAI
    {
        public MonsterAI(MonsterAI_Alias instance) : base(instance)
        {
        }

        public static readonly Core.Invokers.VoidMethodInvoker __IAPI_SetAlerted_Invoker1 = new Core.Invokers.VoidMethodInvoker(typeof(MonsterAI_Alias), "SetAlerted", new Core.Signatures.ParamSig[] { new Core.Signatures.NonGenericParamSig(typeof(bool), false) });
    
    }
}