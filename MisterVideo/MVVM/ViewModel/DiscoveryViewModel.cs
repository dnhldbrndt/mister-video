using MisterVideo;
using MisterVideo.Core;
using MisterVideo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace MisterVideo.MVVM.ViewModel
{
	internal class DiscoveryViewModel  : ObservableObject
	{
		MVDatabase test = new MVDatabase();
		public Customer Customer1 { get; set; }
		public Customer Customer2 { get; set; }
		public Customer Customer3 { get; set; }
		public Customer Customer4 { get; set; }
		public Customer Customer5 { get; set; }
		public DiscoveryViewModel() 
		{
			Trace.WriteLine("Hello!");
			Customer1 = new Customer("bob", "188 Hudson Stravenue, Apt. 814", "bob@mail.com", "555-123467");
			Customer2 = new Customer("john goodman", "92222 O'Conner Motorway, Suite 302", "goodman@mail.com", "555-123467");
			Customer3 = new Customer("netalee hershlag", "3334 Alayna Drives, Apt. 160", "netalee@mail.com", "555-123467");
			Customer4 = new Customer("bill murray", "048 Parisian Islands, Apt. 699", "bmurray@mail.com", "555-123467");
			Customer5 = new Customer("emily rataj", "7573 Connelly Points, Suite 598", "emrata@mail.com", "555-123467");

			Customer2.Add();
			Customer3.Add();
			Customer4.Add();
			Customer5.Add();

			Customer1.Add();
			Customer1.Read();
			Customer1.Name = "alex";
			Customer1.Update();
			Customer1.Read();
			Movie testmovie = new Movie("Jurassic Park", 1993, "Spielberg", "Sam Neil, Laura Dern, Geoff Goldblum", "English", "Science-Fiction, Adventure", "DVD", 1, "Main");
			testmovie.Add();
			testmovie.Read();
			testmovie.Director = "Steven Spielberg";
			testmovie.Update();
			testmovie.Read();

			Movie testmovie2 = new Movie("Star Wars", 1977, "George Lucas", "Mark Hamill, Carrie Fisher, Harrison Ford", "English", "Science-Fiction, Adventure", "DVD", 1, "Main");
			testmovie2.Add();
			testmovie2.Read();

			Rental testrental = new Rental("alex", "Jurassic Park", "12.31.1999");
			testrental.Add();
			testrental.Read();

			Rental testrental2 = new Rental("alex", "Star Wars", "12.31.1999");
			testrental2.Add();
			testrental2.Read();
			Customer1.Rentals();
		}
	}
}
