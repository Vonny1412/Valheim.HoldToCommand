using HarmonyLib;
using HoldToCommand.ValheimAPI;
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
        static void Postfix(Localization __instance, string language)
        {
            // Fallback: English entry
            if (!Plugin.TranslationsByLanguage.TryGetValue(language, out var values))
            {
                if (!Plugin.TranslationsByLanguage.TryGetValue("English", out values))
                {
                    // super-fallback: hardcoded minimal
                    values = ("Hold $1", "Command");
                }
            }

            __instance.AddWord(Plugin.LangKeyHold, values.holdTpl);
            __instance.AddWord(Plugin.LangKeyCommand, values.commandVerb);
        }
    }
}
