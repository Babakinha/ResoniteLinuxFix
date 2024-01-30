using System.Runtime.InteropServices;

namespace ResoniteFix.Patches
{
    class LinuxPatch
    {
        public static bool fake_OSDescription(ref string __result) {
            __result = "Loinx 6.2.1";
            return false;
        }

        public static bool fake_OSArchitecture(ref Architecture __result) {
            __result = Architecture.X64;
            return false;
        }

    }
}
