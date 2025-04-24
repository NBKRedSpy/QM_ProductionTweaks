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
        public static Vector2 LastPosition { get; set; } = Vector2.one;

        /// <summary>
        /// The filter by type
        /// </summary>
        public static ReceiptCategory LastReceiptCategory { get; set; } = ReceiptCategory.All;

        public static void Postfix(MagnumSelectItemToProduceWindow __instance)
        {
            __instance._receiptCategory = LastReceiptCategory;
            __instance.InitPanels();    //Invoke the init panels again.  Init just means refresh since the UI refresh.
            __instance._scrollRect.normalizedPosition = LastPosition;   //InitPanels resets the location.

        }
    }
}
