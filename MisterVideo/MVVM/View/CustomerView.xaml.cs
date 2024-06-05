using MisterVideo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MisterVideo.MVVM.View
{
	/// <summary>
	/// Interaction logic for CustomerView.xaml
	/// </summary>
	public partial class CustomerView : UserControl
	{
		public CustomerView()
		{
			InitializeComponent();
		}
		void OnClick1(object sender, RoutedEventArgs e)
		{
			btnAdd.Background = Brushes.LightBlue;
		}

		void OnClick2(object sender, RoutedEventArgs e)
		{
			btnUpdate.Background = Brushes.LightBlue;
		}

		void OnClick3(object sender, RoutedEventArgs e)
		{
			btnRemove.Background = Brushes.LightBlue;
 
		}
		void OnClick4(object sender, RoutedEventArgs e)
		{
			btnSelect.Background = Brushes.LightBlue;
		}
		private void TheList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Customer SelectedItem = (Customer)TheList.SelectedItem;

			if (SelectedItem != null)
			{
				Trace.WriteLine(SelectedItem.Name);
			}
		}
	}
}
