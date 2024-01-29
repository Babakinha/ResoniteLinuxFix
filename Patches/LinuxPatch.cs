using System.Collections.Generic;
using System.Runtime.InteropServices;
using HarmonyLib;

namespace ResoniteFix.Patches
{
    class LinuxPatch
    {
        public static void Prefix()
        {
            FileLog.Log("Meow from Prefix");
        }

        public static string fake_OSDescription() {
            return "Loinx 6.6.6";
        }

        public static Architecture fake_OSArchitecture() {
            return Architecture.X64;
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var OSDescriptionMethod = typeof(RuntimeInformation).GetMethod("get_OSDescription");
            var OSArchitectureMethod = typeof(RuntimeInformation).GetMethod("get_OSArchitecture");
            FileLog.Log($"desc: {OSDescriptionMethod} {OSArchitectureMethod}");

            var fake_OSDescriptionMethod = typeof(LinuxPatch).GetMethod(nameof(fake_OSDescription));
            var fake_OSArchitectureMethod = typeof(LinuxPatch).GetMethod(nameof(fake_OSArchitecture));


            FileLog.Log($"Meow from Transpiler {instructions}");
            var meow = 0;
            foreach (var instruction in instructions) {
                meow += 1;
                if (instruction.Calls(OSDescriptionMethod)) {
                    var newOp = new CodeInstruction(instruction);
                    newOp.operand = fake_OSDescriptionMethod;
                    FileLog.Log($"{meow} -> Meowy (Changed/Puro'd): {newOp}");

                    yield return newOp;
                }else if (instruction.Calls(OSArchitectureMethod)) {
                    var newOp = new CodeInstruction(instruction);
                    newOp.operand = fake_OSArchitectureMethod;
                    FileLog.Log($"{meow} -> Meowy (Changed/Puro'd): {newOp}");

                    yield return newOp;
                }else {
                    FileLog.Log($"{meow} -> Meowy: {instruction}");
                    yield return instruction;
                }


            }
        }

    }
}
