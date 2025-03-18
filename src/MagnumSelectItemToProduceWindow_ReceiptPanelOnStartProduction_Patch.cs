using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Rewired.Demos.CustomPlatform.MyPlatformControllerExtension;

namespace QM_ProductionTweaks
{

    /// <summary>
    /// Change the initial value to be the maximum that can be produced instead of 1.
    /// </summary>
    [HarmonyPatch]
    internal static class MagnumSelectItemToProduceWindow_ReceiptPanelOnStartProduction_Patch
    {

        public static IEnumerable<MethodBase> TargetMethods()
        {
            MethodInfo directMethod = typeof(MagnumSelectItemToProduceWindow)
                .GetNestedTypes(AccessTools.all)
                .Single(x => x.Name == "<>c__DisplayClass30_0")
                .GetMethods(AccessTools.all)
                .FirstOrDefault(x => x.Name == "<ReceiptPanelOnStartProduction>b__0");


            yield return directMethod;
        }

        public static bool Prefix(object __instance, MGSC.CommonContextMenu v, int ___maxCraft)
        {
            v.AddSliderCommand(___maxCraft, 1, ___maxCraft);
            return false;
        }


        //public static void Prefix(MagnumSelectItemToProduceWindow __instance)
        //{
        //    //Set the initial value to the maximum that can be produced.

        //    Type myClassType = typeof(MagnumSelectItemToProduceWindow);
        //    List<MethodInfo> anonymousMethods = myClassType
        //        .GetMethods(
        //              BindingFlags.NonPublic
        //            | BindingFlags.Public
        //            | BindingFlags.Instance
        //            | BindingFlags.Static)
        //        .Where(method =>
        //              method.GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any())
        //        .ToList();
        //}

        //public static Enumerable<CodeInstruction> Transpile(Enumerable<CodeInstruction> instructions)
        //{

        //    // See original IL source here: OriginalILReference / MGSC.SpawnItemCommand.il

        //    //Goal: The spawn duplicates the DatadiskRecord unlock randomization that is already
        //    //  in the CreateForInventory function.  This would undo the Pity unlock code when using
        //    //  this spawn command for testing.

        //    List<CodeInstruction> original = instructions.ToList();

        //    //Debugging
        //    //Utils.LogIL(original);


        //    List<CodeInstruction> result = new CodeMatcher(original)

        //        //Goal: replace the type check with a false to just bypass the if block.

        //        //// if (basePickupItem.Is<DatadiskRecord>())
        //        //IL_000f: ldloc.0
        //        //IL_0010: callvirt instance bool MGSC.BasePickupItem::Is<class MGSC.DatadiskRecord>()

        //        .MatchStartForward(
        //            new CodeMatch(OpCodes.Ldloc_0),
        //            new CodeMatch(OpCodes.Callvirt,
        //                AccessTools.Method(typeof(BasePickupItem), "Is", new Type[] { }, new Type[] { typeof(DatadiskRecord) })),
        //            new CodeMatch(OpCodes.Brfalse_S)
        //        )
        //        .ThrowIfNotMatch("Did not find 'if (basePickupItem.Is<DatadiskRecord>())'")

        //        .RemoveInstructions(2)

        //        //Push a 0 (false)
        //        .InsertAndAdvance(
        //            new CodeInstruction(OpCodes.Ldc_I4_0)
        //        )
        //        .InstructionEnumeration()
        //        .ToList();

        //    //Post update.
        //    //Utils.LogIL(result);

        //    return result;
        //}


    }
}
