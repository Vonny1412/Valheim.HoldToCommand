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

        internal static ManualLogSource Log { get; private set; }

        internal const string TranslationsFile = "HoldToCommand.Translations.txt";
        internal static string HoldTemplate { get; private set; } = "";
        internal static string CommandVerb { get; private set; } = "";

        internal static readonly Dictionary<string, (string holdTpl, string commandVerb)> TranslationsByLanguage
            = new Dictionary<string, (string holdTpl, string commandVerb)>(StringComparer.OrdinalIgnoreCase);

        private void Awake()
        {
            Log = this.Logger;
            Plugin.Configs.Initialize(Config);
            LoadTranslationsFile();
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }

        private static void LoadTranslationsFile()
        {
            try
            {
                var asmPath = Assembly.GetExecutingAssembly().Location;
                var dir = Path.GetDirectoryName(asmPath);
                var file = Path.Combine(dir ?? ".", TranslationsFile);

                if (!File.Exists(file))
                {
                    Log.LogInfo($"Translations file not found: {file} (will use English fallback)");
                    return;
                }

                foreach (var rawLine in File.ReadAllLines(file))
                {
                    var line = rawLine.Trim();
                    if (line.Length == 0 || line.StartsWith("#")) continue;

                    var parts = line.Split('|');
                    if (parts.Length < 3)
                    {
                        Log.LogWarning($"Invalid translations line (expected 3 columns): {rawLine}");
                        continue;
                    }

                    var language = parts[0].Trim();
                    var holdTpl = parts[1].Trim();
                    var command = parts[2].Trim();

                    if (language.Length == 0) continue;
                    if (holdTpl.Length == 0 || command.Length == 0)
                    {
                        Log.LogWarning($"Empty values in translations line: {rawLine}");
                        continue;
                    }

                    TranslationsByLanguage[language] = (holdTpl, command);
                }

                Log.LogDebug($"Loaded {TranslationsByLanguage.Count} translation entries from {TranslationsFile}");
            }
            catch (Exception ex)
            {
                Log.LogError($"Failed to load translations file: {ex}");
            }
        }

        internal static bool TranslationsRegistered { get; private set; } = false;

        internal static void InvalidateTranslations()
        {
            TranslationsRegistered = false;
        }

        internal static bool RegisterTranslations(Localization loc)
        {
            if (TranslationsRegistered)
            {
                return true;
            }

            if (loc == null)
            {
                return false;
            }

            string language;
            try
            {
                language = loc.GetSelectedLanguage();
            }
            catch
            {
                return false;
            }

            if (!TranslationsByLanguage.TryGetValue(language, out var values) &&
                !TranslationsByLanguage.TryGetValue("English", out values))
            {
                values = ("Hold $1", "Command");
            }

            HoldTemplate = values.holdTpl;
            CommandVerb = values.commandVerb;
            TranslationsRegistered = true;
            return true;
        }
    }
}
