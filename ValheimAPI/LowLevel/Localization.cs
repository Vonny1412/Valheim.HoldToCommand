using Localization_Alias = Localization;

namespace HoldToCommand.ValheimAPI.LowLevel
{
    public partial class Localization : Core.ClassPublicizer
    {
        public Localization(Localization_Alias instance) : base(instance)
        {
        }

        public static readonly Core.Invokers.VoidMethodInvoker __IAPI_AddWord_Invoker1 = new Core.Invokers.VoidMethodInvoker(typeof(Localization_Alias), "AddWord", new Core.Signatures.ParamSig[] { new Core.Signatures.NonGenericParamSig(typeof(string), false), new Core.Signatures.NonGenericParamSig(typeof(string), false) });

    }
}
