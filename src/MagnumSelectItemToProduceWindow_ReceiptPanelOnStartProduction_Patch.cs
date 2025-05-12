using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_ProductionTweaks
{
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.ReceiptPanelOnStartProduction))]
    internal static class MagnumSelectItemToProduceWindow_ReceiptPanelOnStartProduction_Patch
    {
        /// <summary>
        /// Reset the "last amount produced" value if the production item has changed.
        /// </summary>
        /// <param name="__instancze"></param>
        public static void Prefix(MagnumSelectItemToProduceWindow __instance, ItemReceiptPanel panel)
        {
            var info = Plugin.ProductionInfo;


            string itemId = panel.Receipt.OutputItem;

            if (info.LastItemId != itemId)
            {
                info.LastAmount = 0;
            }

            info.LastItemId = itemId;

            Plugin.ProductionInfo.LastPosition = __instance._scrollRect.normalizedPosition;
            Plugin.ProductionInfo.LastReceiptCategory = __instance._receiptCategory;
        }
    }
}
