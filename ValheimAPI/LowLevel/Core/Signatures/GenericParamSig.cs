using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI.LowLevel.Core.Signatures
{
    public class GenericParamSig : CommonParamSig
    {
        public GenericParamSig(int GenericIndex, bool IsByRef)
        {
            IsGeneric = true;
            base.GenericIndex = GenericIndex;
            ConcreteType = null;
            base.IsByRef = IsByRef;
        }
    }
}
