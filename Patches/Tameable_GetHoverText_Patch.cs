using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace HoldToCommand.Patches
{
    [HarmonyPatch(typeof(Tameable), "GetHoverText")]
    static class Tameable_GetHoverText_Patch
    {
        [HarmonyPriority(Priority.Last)]
        static void Postfix(Tameable __instance, ref string __result)
        {
            if (__instance.IsTamed() && __instance.m_commandable)
            {
                var pet = Localization.instance.Localize("$hud_pet");
                int idx = __result.IndexOf(pet, StringComparison.Ordinal);
                if (idx >= 0)
                {
                    var insert = Localization.instance.Localize(
                        "  [<color=yellow><b>$ui_hold $KEY_Use</b></color>] $htc_command"
                    );
                    __result = __result.Insert(idx + pet.Length, insert);
                }
            }
        }
    }
}
