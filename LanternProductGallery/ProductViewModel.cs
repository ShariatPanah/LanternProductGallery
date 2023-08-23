using System;
using System.Collections.Generic;

namespace Lanternsoft
{
    [Serializable]
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            //ModifiedDate = DateTime.Now;
            Quantity = 0;
            SalesPrice = 0;
            SoldQuantity = 0;
            ExtraValues = new Dictionary<string, string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Quantity { get; set; }
        public int SalesPrice { get; set; }
        public decimal SoldQuantity { get; set; }
        public byte[] ProductPicture { get; set; }
        //public DateTime ModifiedDate { get; set; }
        public string CategoryTitle { get; set; }
        public string MeasureUnitTitle { get; set; }
        public Dictionary<string, string> ExtraValues { get; set; }

        public string SalesPriceDisplay { get { return string.Format("{0:n0} تومان", SalesPrice); } }
        //public string ModifiedDateDisplay { get { return ModifiedDate.ToString("yyyy/MM/dd HH:mm"); } }
        public string CategoryName { get { return CategoryTitle ?? "تعریف نشده"; } }
        public string QuantityAndMeasureUnitDisplay { get { return !string.IsNullOrEmpty(MeasureUnitTitle) ? string.Format("{0:n0}", Quantity) + " " + MeasureUnitTitle : string.Format("{0:n0}", Quantity); } }
        public string SoldQuantityDisplay { get { return string.IsNullOrEmpty(MeasureUnitTitle) || SoldQuantity == 0 ? string.Format("{0:n0}", SoldQuantity) : string.Format("{0:n0}", SoldQuantity) + " " + MeasureUnitTitle; } }
    }
}
