using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM_ProductionTweaks
{
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.ContextMenuOnHide))]
    internal static class MagnumSelectItemToProduceWindow_Hide_Patch
    {
        public static void Postfix(MagnumSelectItemToProduceWindow __instance)
        {
            MagnumSelectItemToProduceWindow_InitPanels_Patch.LastPosition = __instance._scrollRect.normalizedPosition;
        }
    }
}
