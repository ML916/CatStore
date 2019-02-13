using System;
using System.Collections.Generic;
using System.Text;

namespace CatStore.Models
{
    /// <summary>
    /// Klass motsvarande kvitto-objekt hämtade på api/orders/id/receipts
    /// </summary>
    public class Receipt
    {

        public string status {
            get; set;
        }
        public double sum {
            get;
            set;
        }
    }
}
