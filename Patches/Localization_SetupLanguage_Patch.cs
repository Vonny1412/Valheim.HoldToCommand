using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.Patches
{

    [HarmonyPatch(typeof(Localization), "SetupLanguage")]
    static class Localization_SetupLanguage_Patch
    {
        static void Prefix()
        {
            Plugin.InvalidateTranslations();
        }
    }

}
