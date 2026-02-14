using HarmonyLib;
using HoldToCommand.ValheimAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldToCommand.Patches
{
    [HarmonyPatch(typeof(Tameable), "Interact")]
    static class Tameable_Interact_Patch
    {
        static bool Prefix(Tameable __instance, Humanoid user, bool hold, bool alt, ref bool __result)
        {
            __result = __instance.CustomInteract(user, hold, alt);
            return false; // always skip vanilla
        }
    }
}
