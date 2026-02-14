using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI.LowLevel.Core.Signatures
{
    public abstract class ParamSig
    {
        public bool IsGeneric;
        public int GenericIndex; // only if IsGeneric
        public Type ConcreteType; // only if !IsGeneric
        public bool IsByRef;
        public abstract bool Matches(ParameterInfo p);
    }
}
