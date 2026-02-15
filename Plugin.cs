using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HoldToCommand
{
    public sealed partial class Plugin : BaseUnityPlugin
    {
        //internal static ManualLogSource Log;

        internal static ManualLogSource Log { get; private set; }

        internal const string LangFileName = "HoldToCommand.Translations.txt";

        internal static readonly Dictionary<string, (string holdTpl, string commandVerb)> TranslationsByLanguage
            = new Dictionary<string, (string holdTpl, string commandVerb)>(StringComparer.OrdinalIgnoreCase);

        private void Awake()
        {
            Log = this.Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
            LoadTranslationsFile();
        }

        private static void LoadTranslationsFile()
        {
            try
            {
                var asmPath = Assembly.GetExecutingAssembly().Location;
                var dir = Path.GetDirectoryName(asmPath);
                var file = Path.Combine(dir ?? ".", LangFileName);

                if (!File.Exists(file))
                {
                    Log?.LogWarning($"Translations file not found: {file} (will use English fallback)");
                    return;
                }

                foreach (var rawLine in File.ReadAllLines(file))
                {
                    var line = rawLine.Trim();
                    if (line.Length == 0 || line.StartsWith("#")) continue;

                    var parts = line.Split('|');
                    if (parts.Length < 3)
                    {
                        Log?.LogWarning($"Invalid translations line (expected 3 columns): {rawLine}");
                        continue;
                    }

                    var language = parts[0].Trim();
                    var holdTpl = parts[1].Trim();
                    var command = parts[2].Trim();

                    if (language.Length == 0) continue;
                    if (holdTpl.Length == 0 || command.Length == 0)
                    {
                        Log?.LogWarning($"Empty values in translations line: {rawLine}");
                        continue;
                    }

                    TranslationsByLanguage[language] = (holdTpl, command);
                }

                Log?.LogInfo($"Loaded {TranslationsByLanguage.Count} translation entries from HoldToCommand.Translations.txt");
            }
            catch (Exception ex)
            {
                Log?.LogError($"Failed to load translations file: {ex}");
            }
        }

    }
}
