using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI.LowLevel.Core.Signatures
{
    public class NonGenericParamSig : CommonParamSig
    {
        public NonGenericParamSig(Type ConcreteType, bool IsByRef)
        {
            IsGeneric = false;
            GenericIndex = -1;
            base.ConcreteType = ConcreteType;
            base.IsByRef = IsByRef;
        }
    }
}
