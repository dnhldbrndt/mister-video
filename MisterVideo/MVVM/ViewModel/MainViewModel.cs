using MisterVideo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisterVideo.MVVM.ViewModel
{
	internal class MainViewModel : ObservableObject
	{
		public RelayCommand HomeViewCommand {get; set; }
		public RelayCommand DiscoveryViewCommand {get; set; }
		public RelayCommand RentalViewCommand { get; set; }
		public RelayCommand CustomerViewCommand { get; set; }
		public RelayCommand MoviesViewCommand { get; set; }

		private HomeViewModel HomeVM { get; set; }
		private DiscoveryViewModel DiscoveryVM { get; set; }
		private RentalViewModel RentalVM { get; set; }
		private CustomerViewModel CustomerVM { get; set; }
		private MoviesViewModel MoviesVM { get; set; }

		private object _currentView;
		public object CurrentView
		{ 
			get { return _currentView; } 
			set { 
				_currentView = value; 
				OnPropertyChanged();
			}
		}
		public MainViewModel() 
		{ 
			HomeVM = new HomeViewModel();
			DiscoveryVM = new DiscoveryViewModel();
			RentalVM = new RentalViewModel();
			CustomerVM = new CustomerViewModel();
			MoviesVM = new MoviesViewModel();
			CurrentView = HomeVM;

			HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
			DiscoveryViewCommand = new RelayCommand(o => { CurrentView = DiscoveryVM; });
			RentalViewCommand = new RelayCommand(o => { CurrentView = RentalVM; });
			CustomerViewCommand = new RelayCommand(o => { CurrentView = CustomerVM; });
			MoviesViewCommand = new RelayCommand(o => { CurrentView = MoviesVM; });

		}
	}
}
