using System.Reflection;
using System.Runtime.CompilerServices;
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
            var targetMethod = typeof(FrooxEngine.Engine).GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Public);
            var stateMachineAttr = targetMethod.GetCustomAttribute<AsyncStateMachineAttribute>();
            var moveNextMethod = stateMachineAttr.StateMachineType.GetMethod("MoveNext", BindingFlags.NonPublic | BindingFlags.Instance);

            var prefix = typeof(Patches.LinuxPatch).GetMethod(nameof(Patches.LinuxPatch.Prefix));
            var prefixMethod = new HarmonyMethod(prefix);

            var transpiler = typeof(Patches.LinuxPatch).GetMethod(nameof(Patches.LinuxPatch.Transpiler));
            var transpilerMethod = new HarmonyMethod(transpiler);

            ResoniteFixMod.TestLogger.LogInfo($"TargetMethod: {targetMethod}");
            ResoniteFixMod.TestLogger.LogInfo($"MoveNext: {moveNextMethod}");
            ResoniteFixMod.TestLogger.LogInfo($"Prefix: {prefix}");

            FileLog.Log("Meow from Init uwu");
            harmony.Patch(moveNextMethod, prefix: prefixMethod, transpiler: transpilerMethod); // Workyy >:3
        }
    }
}
