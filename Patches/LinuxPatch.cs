using System;
using System.IO;
using System.Runtime.InteropServices;
using HarmonyLib;
using static NativeGraphics.NET.OpenGL;

namespace ResoniteFix.Patches
{
    class LinuxPatch
    {
        // RuntimeInformation
        public static bool fake_OSDescription(ref string __result) {
            __result = "Loinx 6.2.1";
            return false;
        }

        public static bool fake_OSArchitecture(ref Architecture __result) {
            __result = Architecture.X64;
            return false;
        }

        public static bool fake_IsOsPlatform(OSPlatform osPlatform, ref bool __result) {
            __result = OSPlatform.Linux == osPlatform;
            return false;
        }

        // Brocolli :3
        public static void add_RuntimeDirectory(ref string[] __result) {
            // Make array beeg
            Array.Resize(ref __result, 7);

            // Should be the same as Brotli
            string directoryName = Path.GetDirectoryName(typeof(LinuxPatch).Assembly.Location);
            __result[6] = (directoryName + "/../../Resonite_Data/Plugins");

            FileLog.Log($"End: {string.Join(" | ", __result)}");
        }

        public static void replace_badGlFormat(ref TextureFormat format) {
            if(format == TextureFormat.GL_SRGB_ALPHA) {
                format = TextureFormat.GL_RGBA;
            }

        }

    }
}
