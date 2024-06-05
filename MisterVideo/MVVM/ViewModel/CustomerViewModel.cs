using MisterVideo.Core;
using MisterVideo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.TextFormatting;

namespace MisterVideo.MVVM.ViewModel
{
	internal class CustomerViewModel : ObservableObject
	{
		public List<Customer> Customers { get; set; }
		public CustomerViewModel() 
		{
			Customers = new List<Customer>();	
			BuildCustomerList();
		}
		public void BuildCustomerList()
		{
			Customers.Clear();
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			command.CommandText = $"SELECT * FROM Customers";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Customer customer = new Customer(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
				customer.ID = reader.GetInt32(0);
				Customers.Add(customer);
				Trace.WriteLine($"Added... {reader.GetString(1)}");
			}
		}
		public void PrintCustomerList()
		{
			foreach (var customer in Customers)
			{
				Trace.WriteLine(customer.ToString());
			}
		}
		public void AddCustomer(string name, string address, string email, string phone)
		{
			Customer customer = new Customer(name,address, email, phone);
			customer.Add();
			Customers.Add(customer);
		}
		public void RemoveCustomer(string arg)
		{
			Customer customer = Customers.First(item => item.Name == arg);
			customer.Remove();
			Customers.Remove(customer);
		}
		public void UpdateCustomer(string arg, string attribute, string value)
		{
			attribute = attribute.ToLower(); 
			Customer customer = Customers.First(item => item.Name == arg);
			int tmpID = customer.ID;
			switch (attribute) 
			{
				case "name":
					customer.Name = value;
					break;
				case "address":
					customer.Address = value;
					break;
				case "email":
					customer.Email = value;
					break;
				case "phone":
					customer.Phone = value;
					break;
				default:
					break;
			}
			customer.Update();
		}
		public Customer ReturnCustomer(string arg)
		{
			Customer customer = Customers.First(item => item.Name == arg);
			return customer;
		}
 

	}
}
