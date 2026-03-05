using HarmonyLib;
using HoldToCommand.ValheimAPI;
using System;

namespace HoldToCommand.Patches
{
    [HarmonyPatch(typeof(Tameable), "Interact")]
    static class Tameable_Interact_Patch
    {
        [HarmonyPriority(Priority.Last)]
        static bool Prefix(Tameable __instance, Humanoid user, bool hold, bool alt, ref bool __result, bool __runOriginal)
        {
            if (!__runOriginal)
            {
                return false;
            }
            __result = __instance.CustomInteract(user, hold, alt);
            return false;
        }
    }
}
