using HMI.UserControls;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using VisiWin.ApplicationFramework;
using WpfAnimatedGif;

namespace HMI.Views.MainRegion
{

	[ExportView("MO_DataPicker")]
	public partial class MO_DataPicker : VisiWin.Controls.View
	{
  
        public MO_DataPicker()
		{
			this.InitializeComponent();

          
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri((new Resources.LocalResources()).Paths.LoadingGif);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(gif, image);
              
           
            
        }

      
        bool isLoaded=false;
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                this.DataContext = new DataPickerAdapter();
                isLoaded = true;
            }
            doWorkAsync();
        }

        private async void doWorkAsync()
        {
            DataPickerAdapter DPA = (DataPickerAdapter)this.DataContext;
            await DPA.UpdateFileList();

        }

        private void Button_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (h1.IsVisible)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 160, new Duration(TimeSpan.FromMilliseconds(750)));
                h1.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation);
            }
        }

        private void Button_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (h2.IsVisible)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, 160, new Duration(TimeSpan.FromMilliseconds(750)));
                h2.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation);
            }
        }
        private void Button_Click1(object sender, System.Windows.RoutedEventArgs e)
        {
            pn_dp.ScrollNext();
        }
        private void Button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            pn_dp.ScrollPrevious();
        }

        private void pn_dp_SelectedPanoramaRegionChanged(object sender, VisiWin.Controls.SelectedPanoramaRegionChangedEventArgs e)
        {
            if (pn_dp.SelectedPanoramaRegionIndex == 0)
            {
                b1.Visibility = System.Windows.Visibility.Visible;
                b2.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                b1.Visibility = System.Windows.Visibility.Hidden;
                b2.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }

}