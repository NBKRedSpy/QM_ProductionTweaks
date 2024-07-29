using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using MGSC;
using UnityEngine;

namespace QM_ProductionTweaks
{
    [HarmonyPatch(typeof(MagnumSelectItemToProduceWindow), nameof(MagnumSelectItemToProduceWindow.InitPanels))]
    internal class MagnumSelectItemToProduceWindow_InitPanels_Patch
    {
        public static Vector2 LastPosition { get; set; } = Vector2.one;

        public static void Postfix(MagnumSelectItemToProduceWindow __instance)
        {
            __instance._scrollRect.normalizedPosition = LastPosition;
        }
    }
}
