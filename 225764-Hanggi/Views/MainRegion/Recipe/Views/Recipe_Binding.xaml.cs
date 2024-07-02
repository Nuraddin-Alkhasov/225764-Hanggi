using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

	[ExportView("Recipe_Binding")]
	public partial class Recipe_Binding : VisiWin.Controls.View
	{
        public Recipe_Binding()
		{
			this.InitializeComponent();
            this.DataContext = new RecipeBindingAdapter();

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
        }

        private void Grid_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if(this.IsVisible)
                ((RecipeBindingAdapter)this.DataContext).UpdateBarcodeList();
        }

        public int GetItem(string a)
        {
            for (int i = 0; i < dgv_bctor.Items.Count; i++)
            {
                if (((Barcode)dgv_bctor.Items[i]).BC == a)
                {
                    return i;
                }
            }
            return 0;
        }

    }
}