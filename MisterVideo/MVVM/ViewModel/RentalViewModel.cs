using MisterVideo.Core;
using MisterVideo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisterVideo.MVVM.ViewModel
{
	internal class RentalViewModel : ObservableObject
	{
		public List<Rental> Rentals { get; set; }
		public string Test {get; set;}	
		public RentalViewModel() 
		{
			Test = "test";
			 
		}
	}
}
