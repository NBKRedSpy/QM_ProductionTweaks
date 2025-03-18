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

        /// <summary>
        /// The GUI configure is a lambda, so have to set the target this way.
        /// Have to find the name from the IL first.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MethodBase> TargetMethods()
        {
            MethodInfo directMethod = typeof(MagnumSelectItemToProduceWindow)
                .GetNestedTypes(AccessTools.all)
                .Single(x => x.Name == "<>c__DisplayClass30_0")
                .GetMethods(AccessTools.all)
                .Single(x => x.Name == "<ReceiptPanelOnStartProduction>b__0");


            yield return directMethod;
        }


        public static bool Prefix(object __instance, MGSC.CommonContextMenu v, int ___maxCraft)
        {
            //------- The goal is to change the slider's value to default to the max value instead of 1.
            //  ...
            // 	UI.Chain<CommonContextMenu>().Invoke(delegate(CommonContextMenu v)
            // 	{
            // 		v.AddSliderCommand(1, 1, maxCraft);
            // 	}).Invoke(delegate(CommonContextMenu v)
            // 	{
            //  ...

            v.AddSliderCommand(___maxCraft, 1, ___maxCraft);
            return false;
        }
    }

}
