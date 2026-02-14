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
        private static readonly Dictionary<string, string> CommandByLanguage = new Dictionary<string, string>()
        {
            ["English"] = "Command",
            ["German"] = "Befehl",
            ["French"] = "Commander",
            ["Spanish"] = "Ordenar",
            ["Italian"] = "Comanda",
            ["Dutch"] = "Bevel",

            ["Portuguese_Brazilian"] = "Comandar",
            ["Portuguese_European"] = "Comandar",

            ["Russian"] = "Команда",

            ["Swedish"] = "Kommendera",
            ["Finnish"] = "Komentaa",
            ["Danish"] = "Kommando",
            ["Norwegian"] = "Kommander",

            ["Czech"] = "Rozkaz",
            ["Hungarian"] = "Parancs",
            ["Polish"] = "Rozkaz",
            ["Slovak"] = "Rozkaz",

            ["Greek"] = "Εντολή",
            ["Turkish"] = "Komut",

            ["Chinese"] = "指挥",
            ["Chinese_Trad"] = "指揮",
            ["Japanese"] = "命令",
            ["Korean"] = "명령",
        };

        static void Postfix(Localization __instance, string language)
        {
            const string key = "htc_command";

            if (!CommandByLanguage.TryGetValue(language, out var value))
            {
                value = CommandByLanguage["English"]; // fallback
            }

            __instance.AddWord(key, value);
        }
    }
}
