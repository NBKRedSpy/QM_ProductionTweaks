.method private hidebysig 
	instance void ReceiptPanelOnStartProduction (
		class MGSC.ItemReceiptPanel panel
	) cil managed 
{
	// Method begins at RVA 0xc93e0
	// Header size: 12
	// Code size: 331 (0x14b)
	.maxstack 3
	.locals init (
		[0] class MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0',
		[1] int32,
		[2] class MGSC.CompositeItemRecord,
		[3] bool,
		[4] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.BasePickupItemRecord>,
		[5] class MGSC.BasePickupItemRecord,
		[6] class MGSC.IStackableRecord
	)

	// {
	IL_0000: newobj instance void MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::.ctor()
	IL_0005: stloc.0
	// _receiptToProduce = panel.Receipt;
	IL_0006: ldarg.0
	IL_0007: ldarg.1
	IL_0008: callvirt instance class MGSC.ItemProduceReceipt MGSC.ItemReceiptPanel::get_Receipt()
	IL_000d: stfld class MGSC.ItemProduceReceipt MGSC.MagnumSelectItemToProduceWindow::_receiptToProduce
	// int maxCraft = ItemProductionSystem.GetAvailableToProduceCount(_magnumCargo.ShipCargo, _receiptToProduce.RequiredItems);
	IL_0012: ldloc.0
	IL_0013: ldarg.0
	IL_0014: ldfld class MGSC.MagnumCargo MGSC.MagnumSelectItemToProduceWindow::_magnumCargo
	IL_0019: ldfld class [mscorlib]System.Collections.Generic.List`1<class MGSC.ItemStorage> MGSC.MagnumCargo::ShipCargo
	IL_001e: ldarg.0
	IL_001f: ldfld class MGSC.ItemProduceReceipt MGSC.MagnumSelectItemToProduceWindow::_receiptToProduce
	IL_0024: callvirt instance class [mscorlib]System.Collections.Generic.List`1<valuetype MGSC.ItemQuantity> MGSC.ItemProduceReceipt::get_RequiredItems()
	IL_0029: call int32 MGSC.ItemProductionSystem::GetAvailableToProduceCount<class MGSC.ItemStorage>(class [mscorlib]System.Collections.Generic.List`1<!!0>, class [mscorlib]System.Collections.Generic.List`1<valuetype MGSC.ItemQuantity>)
	IL_002e: stfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft
	// int num = 1;
	IL_0033: ldc.i4.1
	IL_0034: stloc.1
	// CompositeItemRecord compositeItemRecord = Data.Items.GetRecord(_receiptToProduce.OutputItem) as CompositeItemRecord;
	IL_0035: call class MGSC.ItemsCollection MGSC.Data::get_Items()
	IL_003a: ldarg.0
	IL_003b: ldfld class MGSC.ItemProduceReceipt MGSC.MagnumSelectItemToProduceWindow::_receiptToProduce
	IL_0040: callvirt instance string MGSC.ItemProduceReceipt::get_OutputItem()
	IL_0045: ldc.i4.1
	IL_0046: callvirt instance !0 class MGSC.ConfigRecordCollection`1<class MGSC.BasePickupItemRecord>::GetRecord(string, bool)
	IL_004b: isinst MGSC.CompositeItemRecord
	IL_0050: stloc.2
	// foreach (BasePickupItemRecord record in compositeItemRecord.Records)
	IL_0051: ldloc.2
	IL_0052: callvirt instance class [mscorlib]System.Collections.Generic.List`1<class MGSC.BasePickupItemRecord> MGSC.CompositeItemRecord::get_Records()
	IL_0057: callvirt instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class MGSC.BasePickupItemRecord>::GetEnumerator()
	IL_005c: stloc.s 4
	.try
	{
		// foreach (BasePickupItemRecord record in compositeItemRecord.Records)
		IL_005e: br.s IL_008a
		// loop start (head: IL_008a)
			IL_0060: ldloca.s 4
			IL_0062: call instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.BasePickupItemRecord>::get_Current()
			IL_0067: stloc.s 5
			// if (record is IStackableRecord stackableRecord && compositeItemRecord.PrimaryRecord == record)
			IL_0069: ldloc.s 5
			IL_006b: isinst MGSC.IStackableRecord
			IL_0070: stloc.s 6
			// (no C# code)
			IL_0072: ldloc.s 6
			IL_0074: brfalse.s IL_008a

			// num = stackableRecord.MaxStack;
			IL_0076: ldloc.2
			IL_0077: callvirt instance class MGSC.BasePickupItemRecord MGSC.CompositeItemRecord::get_PrimaryRecord()
			IL_007c: ldloc.s 5
			IL_007e: bne.un.s IL_008a

			IL_0080: ldloc.s 6
			IL_0082: callvirt instance int16 MGSC.IStackableRecord::get_MaxStack()
			IL_0087: stloc.1
			// break;
			IL_0088: leave.s IL_00a3

			// foreach (BasePickupItemRecord record in compositeItemRecord.Records)
			IL_008a: ldloca.s 4
			IL_008c: call instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.BasePickupItemRecord>::MoveNext()
			IL_0091: brtrue.s IL_0060
		// end loop

		// (no C# code)
		IL_0093: leave.s IL_00a3
	} // end .try
	finally
	{
		IL_0095: ldloca.s 4
		IL_0097: constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class MGSC.BasePickupItemRecord>
		IL_009d: callvirt instance void [mscorlib]System.IDisposable::Dispose()
		// bool num2 = num > 1;
		IL_00a2: endfinally
	} // end handler

	IL_00a3: ldloc.1
	IL_00a4: ldc.i4.1
	IL_00a5: cgt
	// (no C# code)
	IL_00a7: ldloc.0
	// bool flag = maxCraft == int.MaxValue;
	IL_00a8: ldfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft
	IL_00ad: ldc.i4 2147483647
	IL_00b2: ceq
	IL_00b4: stloc.3
	// if (num2)
	IL_00b5: brfalse.s IL_00d1

	// maxCraft = (flag ? num : Mathf.Min(maxCraft, num));
	IL_00b7: ldloc.0
	IL_00b8: ldloc.3
	IL_00b9: brtrue.s IL_00c9

	IL_00bb: ldloc.0
	IL_00bc: ldfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft
	IL_00c1: ldloc.1
	IL_00c2: call int32 [UnityEngine.CoreModule]UnityEngine.Mathf::Min(int32, int32)
	IL_00c7: br.s IL_00ca

	IL_00c9: ldloc.1

	IL_00ca: stfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft
	// (no C# code)
	IL_00cf: br.s IL_00e9

	// maxCraft = (flag ? 5 : Mathf.Min(maxCraft, 5));
	IL_00d1: ldloc.0
	IL_00d2: ldloc.3
	IL_00d3: brtrue.s IL_00e3

	IL_00d5: ldloc.0
	IL_00d6: ldfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft
	IL_00db: ldc.i4.5
	IL_00dc: call int32 [UnityEngine.CoreModule]UnityEngine.Mathf::Min(int32, int32)
	IL_00e1: br.s IL_00e4

	IL_00e3: ldc.i4.5

	IL_00e4: stfld int32 MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::maxCraft

	// 	UI.Chain<CommonContextMenu>().Invoke(delegate(CommonContextMenu v)
	// 	{
	// 		v.AddSliderCommand(1, 1, maxCraft);
	// 	}).Invoke(delegate(CommonContextMenu v)
	// 	{
	// 		v.SetupCommand(Localization.Get("ui.context.StartProduction"), 0);
	// 	})
	// 		.Show()
	// 		.SetBackgroundOrder(-1)
	// 		.SetBackOnBackgroundClick(value: true);
	IL_00e9: call class MGSC.UI/CmdChain`1<!!0> MGSC.UI::Chain<class MGSC.CommonContextMenu>()
	IL_00ee: ldloc.0
	IL_00ef: ldftn instance void MGSC.MagnumSelectItemToProduceWindow/'<>c__DisplayClass30_0'::'<ReceiptPanelOnStartProduction>b__0'(class MGSC.CommonContextMenu)
	IL_00f5: newobj instance void class [mscorlib]System.Action`1<class MGSC.CommonContextMenu>::.ctor(object, native int)
	IL_00fa: callvirt instance class MGSC.UI/CmdChain`1<!0> class MGSC.UI/CmdChain`1<class MGSC.CommonContextMenu>::Invoke(class [mscorlib]System.Action`1<!0>)
	IL_00ff: ldsfld class [mscorlib]System.Action`1<class MGSC.CommonContextMenu> MGSC.MagnumSelectItemToProduceWindow/'<>c'::'<>9__30_1'
	IL_0104: dup
	IL_0105: brtrue.s IL_011e

	// (no C# code)
	IL_0107: pop
	IL_0108: ldsfld class MGSC.MagnumSelectItemToProduceWindow/'<>c' MGSC.MagnumSelectItemToProduceWindow/'<>c'::'<>9'
	IL_010d: ldftn instance void MGSC.MagnumSelectItemToProduceWindow/'<>c'::'<ReceiptPanelOnStartProduction>b__30_1'(class MGSC.CommonContextMenu)
	IL_0113: newobj instance void class [mscorlib]System.Action`1<class MGSC.CommonContextMenu>::.ctor(object, native int)
	IL_0118: dup
	IL_0119: stsfld class [mscorlib]System.Action`1<class MGSC.CommonContextMenu> MGSC.MagnumSelectItemToProduceWindow/'<>c'::'<>9__30_1'

	IL_011e: callvirt instance class MGSC.UI/CmdChain`1<!0> class MGSC.UI/CmdChain`1<class MGSC.CommonContextMenu>::Invoke(class [mscorlib]System.Action`1<!0>)
	IL_0123: callvirt instance class MGSC.UI/CmdChain`1<!0> class MGSC.UI/CmdChain`1<class MGSC.CommonContextMenu>::Show()
	IL_0128: ldc.i4.m1
	IL_0129: callvirt instance class MGSC.UI/CmdChain`1<!0> class MGSC.UI/CmdChain`1<class MGSC.CommonContextMenu>::SetBackgroundOrder(int32)
	IL_012e: ldc.i4.1
	IL_012f: callvirt instance class MGSC.UI/CmdChain`1<!0> class MGSC.UI/CmdChain`1<class MGSC.CommonContextMenu>::SetBackOnBackgroundClick(bool)
	// UI.Get<CommonContextMenu>().SnapToPosition(panel.transform.GetCenterPosition());
	IL_0134: pop
	IL_0135: call !!0 MGSC.UI::Get<class MGSC.CommonContextMenu>()
	IL_013a: ldarg.1
	IL_013b: callvirt instance class [UnityEngine.CoreModule]UnityEngine.Transform [UnityEngine.CoreModule]UnityEngine.Component::get_transform()
	IL_0140: call valuetype [UnityEngine.CoreModule]UnityEngine.Vector3 MGSC.UnityHelper::GetCenterPosition(class [UnityEngine.CoreModule]UnityEngine.Transform)
	IL_0145: callvirt instance void MGSC.CommonContextMenu::SnapToPosition(valuetype [UnityEngine.CoreModule]UnityEngine.Vector3)
	// }
	IL_014a: ret
} // end of method MagnumSelectItemToProduceWindow::ReceiptPanelOnStartProduction
