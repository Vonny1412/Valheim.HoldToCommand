using BaseAI_Alias = BaseAI;

namespace HoldToCommand.ValheimAPI.LowLevel
{
    public partial class BaseAI : UnityEngine.MonoBehaviour
    {
        public BaseAI(BaseAI_Alias instance) : base(instance)
        {
        }

    }
}