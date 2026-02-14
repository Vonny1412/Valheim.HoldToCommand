using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.ValheimAPI
{
    internal static class LocalizationExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddWord(this Localization local, string key, string text)
            => LowLevel.Localization.__IAPI_AddWord_Invoker1.Invoke(local, key, text);

    }
}
