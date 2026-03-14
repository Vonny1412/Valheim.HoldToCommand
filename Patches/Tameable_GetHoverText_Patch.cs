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
            if (!__instance.IsTamed() || !__instance.m_commandable)
            {
                return;
            }

            var loc = Localization.instance;
            if (!Plugin.RegisterTranslations(loc))
            {
                return;
            }

            var pet = loc.Localize("$hud_pet");
            int idx = __result.IndexOf(pet, StringComparison.Ordinal);
            if (idx < 0)
            {
                return;
            }

            var useKey = loc.Localize("$KEY_Use");
            var holdUse = Plugin.HoldTemplate.Replace("$1", useKey);
            var command = Plugin.CommandVerb;
            var seperator = Plugin.Configs.ShowInNewLine.Value == true ? "\n" : "  ";

            __result = __result.Insert(idx + pet.Length, seperator + "[<color=yellow><b>" + holdUse + "</b></color>] " + command);
        }
    }
}
