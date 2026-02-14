using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI.LowLevel.Core
{

    public abstract class ClassPublicizer
    {

        protected object __IAPI_instance = null;

        public ClassPublicizer(object instance)
        {
            __IAPI_instance = instance;
        }

        public ClassPublicizer()
        {
            __IAPI_instance = null;
        }

        public static Type __IAPI_GetInstanceType() => typeof(void);
        public object __IAPI_GetInstance() => __IAPI_instance;
        public void __IAPI_SetInstance(object instance) => __IAPI_instance = instance;

    }
}
