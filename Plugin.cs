using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace HoldToCommand
{
    public sealed partial class Plugin : BaseUnityPlugin
    {
        //internal static ManualLogSource Log;

        internal static ManualLogSource Log { get; private set; }

        private void Awake()
        {
            Log = this.Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }
    }
}
