using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_ProductionTweaks
{
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.ContextMenuOnCmdSelected))]
    internal static class MagnumSelectItemToProduceWindow_ContextMenuOnCmdSelected_Patch
    {
        public static void Postfix(MagnumSelectItemToProduceWindow __instance)
        {
            ProductionInfo info = Plugin.ProductionInfo;

            info.LastPosition = __instance._scrollRect.normalizedPosition;
            info.LastReceiptCategory = __instance._receiptCategory;

            //Last item's ID is set when the "amount" slider window is shown.

            info.LastAmount = info.LastItemId == null ? 0 : UI.Get<CommonContextMenu>().SliderButtonSelectedValue;
        }
    }
}
