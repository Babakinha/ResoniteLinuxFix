using System.Runtime.InteropServices;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ResoniteFix
{
    [BepInPlugin(ResoniteFixMod.PLUGIN_GUID, ResoniteFixMod.PLUGIN_NAME, ResoniteFixMod.PLUGIN_VERSION)]
    public class ResoniteFixMod : BaseUnityPlugin
    {

        private const string PLUGIN_GUID = "Babakinha.ResoniteFix";
        private const string PLUGIN_NAME = "ResoniteFix";
        private const string PLUGIN_VERSION = "0.0.1";

        private static ResoniteFixMod Instance;
        private readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public static ManualLogSource TestLogger;

        private void Awake()
        {
            ResoniteFixMod.TestLogger = BepInEx.Logging.Logger.CreateLogSource(ResoniteFixMod.PLUGIN_GUID);

            if (ResoniteFixMod.Instance == null)
            {
                ResoniteFixMod.Instance = this;
            }
            else
            {
                ResoniteFixMod.TestLogger.LogInfo($"{ResoniteFixMod.PLUGIN_GUID} got loaded again?");
            }

            ResoniteFixMod.TestLogger.LogInfo($"Plugin {ResoniteFixMod.PLUGIN_GUID} is loaded!");

            // Patching
            var OSDescriptionMethod = typeof(RuntimeInformation).GetMethod("get_OSDescription");
            var OSArchitectureMethod = typeof(RuntimeInformation).GetMethod("get_OSArchitecture");

            var fake_OSDescriptionMethod = typeof(Patches.LinuxPatch).GetMethod(nameof(Patches.LinuxPatch.fake_OSDescription));
            var fake_OSArchitectureMethod = typeof(Patches.LinuxPatch).GetMethod(nameof(Patches.LinuxPatch.fake_OSArchitecture));

            harmony.Patch(OSDescriptionMethod, prefix: new HarmonyMethod(fake_OSDescriptionMethod));
            harmony.Patch(OSArchitectureMethod, prefix: new HarmonyMethod(fake_OSArchitectureMethod));
        }
    }
}
