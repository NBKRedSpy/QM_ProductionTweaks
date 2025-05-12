using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using UnityEngine;
using static MGSC.MagnumSelectItemToProduceWindow;

namespace QM_ProductionTweaks
{
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.Configure))]
    internal class MagnumSelectItemToProduceWindow_InitPanels_Patch
    {
        public static void Postfix(MagnumSelectItemToProduceWindow __instance)
        {
            __instance._receiptCategory = Plugin.ProductionInfo.LastReceiptCategory;
            __instance.InitPanels();    //Invoke the init panels again.  Init just means refresh in the code.

            __instance._scrollRect.normalizedPosition = Plugin.ProductionInfo.LastPosition;  //InitPanels resets the location.

        }
    }
}
