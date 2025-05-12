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
    [HarmonyPatch("MGSC.MagnumSelectItemToProduceWindow+<>c__DisplayClass30_0", "<ReceiptPanelOnStartProduction>b__0")]
    internal static class MagnumSelectItemToProduceWindow_ReceiptPanelOnStartProduction_ContextMenu_Patch
    {
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

            int lastAmount = Plugin.ProductionInfo.LastAmount;

            int defaultAmount = lastAmount == 0 ? ___maxCraft : Math.Min(lastAmount, ___maxCraft);

            v.AddSliderCommand(defaultAmount, 1, ___maxCraft);
            return false;
        }
    }

}
