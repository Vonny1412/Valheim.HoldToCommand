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
                return;

            var pet = Localization.instance.Localize("$hud_pet");
            int idx = __result.IndexOf(pet, StringComparison.Ordinal);
            if (idx < 0) return;

            var useKey = Localization.instance.Localize("$KEY_Use");
            var holdUse = Localization.instance.Localize($"${Plugin.LangKeyHold}", useKey);
            var command = Localization.instance.Localize($"${Plugin.LangKeyCommand}");
            var insert = $"  [<color=yellow><b>{holdUse}</b></color>] {command}";

            __result = __result.Insert(idx + pet.Length, insert);
        }
    }
}
