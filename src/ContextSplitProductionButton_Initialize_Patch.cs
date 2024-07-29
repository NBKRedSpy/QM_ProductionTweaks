using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_ProductionTweaks
{

    /// <summary>
    /// Change the initial value to be the maximum that can be produced instead of 1.
    /// </summary>
    [HarmonyPatch(typeof(ContextSplitProductionButton), nameof(ContextSplitProductionButton.Initialize))]
    internal static class ContextSplitProductionButton_Initialize_Patch
    {
        public static void Postfix(ContextSplitProductionButton __instance)
        {
            if(__instance._maxCount > 1)
            {
                __instance.OnValueChanged(__instance._maxCount);
                __instance._slider.value = __instance._slider.maxValue;
            }
        }
    }
}
