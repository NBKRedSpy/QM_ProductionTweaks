using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_ProductionTweaks
{

    /// <summary>
    /// Change the initial value to be the maximum that can be produced instead of 1.
    /// </summary>
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.ReceiptPanelOnStartProduction))]
    internal static class MagnumSelectItemToProduceWindow_ReceiptPanelOnStartProduction_Patch
    {
        public static bool Prefix(MagnumSelectItemToProduceWindow __instance, ItemReceiptPanel panel)
        {

            //Debug testing
            __instance._receiptToProduce = panel.Receipt;
            int maxCraft = ItemProductionSystem.GetAvailableToProduceCount(__instance._magnumCargo.ShipCargo,
                __instance._receiptToProduce.RequiredItems);
            int num = 1;
            CompositeItemRecord compositeItemRecord = Data.Items.GetRecord(__instance._receiptToProduce.OutputItem) as CompositeItemRecord;
            foreach (BasePickupItemRecord record in compositeItemRecord.Records)
            {
                if (record is IStackableRecord stackableRecord && compositeItemRecord.PrimaryRecord == record)
                {
                    num = stackableRecord.MaxStack;
                    break;
                }
            }
            bool num2 = num > 1;
            bool flag = maxCraft == int.MaxValue;
            if (num2)
            {
                maxCraft = (flag ? num : Mathf.Min(maxCraft, num));
            }
            else
            {
                maxCraft = (flag ? 5 : Mathf.Min(maxCraft, 5));
            }
            UI.Chain<CommonContextMenu>().Invoke(delegate (CommonContextMenu v)
            {
                v.AddSliderCommand(maxCraft, 1, maxCraft);
            }).Invoke(delegate (CommonContextMenu v)
            {
                v.SetupCommand(Localization.Get("ui.context.StartProduction"), 0);
            })
                .Show()
                .SetBackgroundOrder(-1)
                .SetBackOnBackgroundClick(value: true);
            UI.Get<CommonContextMenu>().SnapToPosition(panel.transform.GetCenterPosition());

            return false;
        }

        
    }
}
