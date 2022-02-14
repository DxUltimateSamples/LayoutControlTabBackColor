namespace LayoutControlTabBackColor
{
    using DevExpress.XtraLayout;

    public partial class Form3 : DevExpress.XtraEditors.XtraForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void LayoutControl1_CustomDraw(object sender, DevExpress.XtraLayout.ItemCustomDrawEventArgs e)
        {
            if (e.Item is LayoutControlGroup groupItem
                && groupItem.AppearanceGroup.Options.UseBackColor
                && groupItem.Parent?.ParentTabbedGroup != null)
            {
                // This assumes that TabbedControlGroup.Padding.All == -1;
                var bounds = e.Bounds;
                bounds.Offset(1, 1);
                bounds.Width -= 1;
                bounds.Height -= 1;

                groupItem.PaintAppearanceGroup.AppearanceGroup.FillRectangle(e.Cache, bounds);
                e.Handled = true;
            }

        }
    }
}
