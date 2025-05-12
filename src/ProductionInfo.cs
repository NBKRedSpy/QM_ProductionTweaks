using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static MGSC.MagnumSelectItemToProduceWindow;

namespace QM_ProductionTweaks
{
    public class ProductionInfo
    {
        /// <summary>
        /// The last item that was selected for production
        /// </summary>
        public string LastItemId { get; set; }

        /// <summary>
        /// The amount that the user selected last time.
        /// </summary>
        public int LastAmount { get; set; }

        /// <summary>
        /// Stores the last location for the production window's content.
        /// Used to keep the dialog at the same place when reopened.
        /// </summary>
        public Vector2 LastPosition { get; set; } = Vector2.one;

        /// <summary>
        /// The last filter that was selected.
        /// Used to keep on the same page.
        /// </summary>
        public ReceiptCategory LastReceiptCategory { get; set; } = ReceiptCategory.All;

    }
}
