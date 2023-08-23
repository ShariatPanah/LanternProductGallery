using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lanternsoft
{
    public partial class ProductItem : UserControl
    {
        public ProductItem()
        {
            InitializeComponent();

            _product = new ProductViewModel();
        }

        private ProductViewModel _product;
        public ProductViewModel Product
        {
            get { return _product; }
            set
            {
                _product = value;

                if (_product.ProductPicture != null)
                {
                    using (var memoryStream = new MemoryStream(_product.ProductPicture))
                    {
                        pcbProductPicture.Image = new Bitmap(memoryStream);
                    }
                }

                lblProductName.Text = _product.Name;
                lblModel.Text = _product.Model;
                lblCategory.Text = _product.CategoryName;
                lblSalesPrice.Text = _product.SalesPriceDisplay;
                lblSoldQuantity.Text = _product.SoldQuantityDisplay;
                lblStock.Text = _product.QuantityAndMeasureUnitDisplay;
                //lblModifiedDate.Text = _product.ModifiedDateDisplay;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
    }
}
