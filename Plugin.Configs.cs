using BepInEx.Configuration;

namespace HoldToCommand
{
    public sealed partial class Plugin
    {
        public class Configs
        {

            private const string Section_General = "General";

            public static ConfigEntry<float> HoldThreshold { get; private set; }

            public static void Initialize(ConfigFile Config)
            {
                string section = "";

                section = Section_General;

                HoldThreshold = Config.Bind<float>(
                    section,
                    "HoldThreshold",
                    0.45f,
                    new ConfigDescription(
                        "Time in seconds the Use key must be held to issue a command.",
                        new AcceptableValueRange<float>(0f, 1f)
                    )
                );

            }
        }
    }
}
