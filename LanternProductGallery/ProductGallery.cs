using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Lanternsoft
{
    public delegate void ProductMouseClickDelegate(ProductItem Item);
    public delegate void ProductMouseDoubleClickDelegate(MouseEventArgs e);
    public delegate void ProductKeyDownDelegate(KeyEventArgs e);

    public partial class ProductGallery : UserControl
    {
        public ProductMouseClickDelegate ProductMouseClick;
        public ProductMouseDoubleClickDelegate ProductMouseDoubleClick;
        public ProductKeyDownDelegate ProductKeyDown;

        private List<ProductItem> ProductControls;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ProductViewModel> Products { get; set; }
        public ContextMenuStrip ProductContextMenuStrip { get; set; }
        public ProductViewModel SelectedProduct { get; private set; }

        public int RecordPageSize = 2;
        private int PanelProductsCols = 1;
        private int UcProductDetailsHeight = 134;
        private int UcProductDetailsWidth = 600;

        public ProductGallery()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
                           BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                           null, pnlGallery, new object[] { true });

            ProductControls = new List<ProductItem>();
            Products = new List<ProductViewModel>();
        }

        public void RefreshGallery()
        {
            pnlGallery.SuspendLayout();
            pnlGallery.Controls.Clear();
            int panelWidth;
            int rows = (int)Math.Ceiling((double)Products.Count / PanelProductsCols);

            for (int i = 0; i < rows; i++)
            {
                int a = i == 0 ? 1 : i;
                int b = Products.Count % (a * PanelProductsCols);
                int c = (i != rows - 1 ? PanelProductsCols : b == 0 ? PanelProductsCols : b);

                for (int j = 0; j < c; j++)
                {
                    panelWidth = pnlGallery.DisplayRectangle.Size.Width;

                    ProductItem productItem = new ProductItem() { Product = Products[i * PanelProductsCols + j] };
                    productItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    productItem.ContextMenuStrip = ProductContextMenuStrip;
                    productItem.Location = new Point(panelWidth - ((j + 1) * productItem.Width) - (j * 5), i * productItem.Height + (i * 5));

                    productItem.MouseClick += (source, args) =>
                    {
                        UcProductDetails_MouseClick(productItem);
                        ProductMouseClick?.Invoke(productItem);
                    };

                    productItem.MouseDoubleClick += (sender, args) => ProductMouseDoubleClick?.Invoke(args);

                    foreach (Control control in productItem.Controls)
                    {
                        control.MouseClick += (source, args) =>
                        {
                            UcProductDetails_MouseClick(productItem);
                            ProductMouseClick?.Invoke(productItem);
                        };

                        control.MouseDoubleClick += (sender, args) => ProductMouseDoubleClick?.Invoke(args);
                    }

                    productItem.KeyDown += (sender, e) => ProductKeyDown?.Invoke(e);
                    pnlGallery.Controls.Add(productItem);
                }
            }

            pnlGallery.ResumeLayout();
            var firstItem = pnlGallery.Controls.OfType<ProductItem>().FirstOrDefault();
            if (firstItem != null)
            {
                firstItem.BackColor = Color.SkyBlue;
                SelectedProduct = firstItem.Product;
            }
        }

        private void UcProductDetails_MouseClick(ProductItem details)
        {
            SelectedProduct = details.Product;
            foreach (ProductItem item in pnlGallery.Controls.OfType<ProductItem>().Where(u => u.BackColor == Color.SkyBlue))
            {
                item.BackColor = Color.Transparent;
            }
            details.BackColor = Color.SkyBlue;
        }

        private void pnlGallery_SizeChanged(object sender, EventArgs e)
        {
            int newpageSize = ((pnlGallery.Height - 60) / UcProductDetailsHeight) * PanelProductsCols;
            if ((newpageSize > 0 && newpageSize != RecordPageSize) || (pnlGallery.Width / UcProductDetailsWidth > 0 && pnlGallery.Width / UcProductDetailsWidth != PanelProductsCols))
            {
                RecordPageSize = (pnlGallery.Height - 60) / UcProductDetailsHeight >= 1 ? (pnlGallery.Height - 60) / UcProductDetailsHeight : 1;
                PanelProductsCols = pnlGallery.Width / UcProductDetailsWidth >= 1 ? pnlGallery.Width / UcProductDetailsWidth : 1;
                RecordPageSize *= PanelProductsCols;
            }
        }
    }

    //public class CustomPanel : Panel
    //{
    //    public CustomPanel() : base()
    //    {
    //        this.DoubleBuffered = true;
    //        this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    //    }

    //    protected override void OnScroll(ScrollEventArgs se)
    //    {
    //        this.Invalidate();

    //        base.OnScroll(se);
    //    }

    //    protected override CreateParams CreateParams
    //    {
    //        get
    //        {
    //            CreateParams cp = base.CreateParams;
    //            cp.ExStyle |= 0x02000000; // WS_CLIPCHILDREN
    //            return cp;
    //        }
    //    }
    //}
}
