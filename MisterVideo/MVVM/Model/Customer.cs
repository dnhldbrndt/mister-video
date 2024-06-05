using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MisterVideo.Core;

namespace MisterVideo.MVVM.Model
{
	class Customer
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		public int ID { get; set; }

		public Customer(string name, string address, string email, string phone) 
		{
			Name = name;
			Address = address;
			Email = email;	
			Phone = phone;
		}
		public void Add()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"INSERT INTO Customers( name, address, email, phone) VALUES( '{Name}', '{Address}', '{Email}', '{Phone}')";
			try
			{
				command.CommandText = statement;
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Trace.WriteLine(e);
			}
			var commandID = new SQLiteCommand(connection);
			commandID.CommandText = $"SELECT * FROM Customers WHERE name='{Name}'";
			var reader = commandID.ExecuteReader();
			while (reader.Read())
			{
				ID = reader.GetInt32(0);
			}
		}
		public void Read()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			command.CommandText = $"SELECT * FROM Customers WHERE id='{ID}'";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Trace.Write("Starting....");
				Trace.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)} {reader.GetString(4)}");
			}
		}
		public void Update()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"UPDATE Customers SET name = '{Name}', address = '{Address}', email = '{Email}', phone = '{Phone}' WHERE id = '{ID}'";
			try
			{
				command.CommandText = statement;
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Trace.WriteLine(e);
			}
		}
		public void Remove()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"DELETE FROM Customers WHERE id = '{ID}'";
			try
			{
				command.CommandText = statement;
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Trace.WriteLine(e);
			}
		}
		public void Rentals()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			command.CommandText = $"SELECT title, Customers.name, duedate, rentalid FROM Rentals LEFT JOIN Customers ON Rentals.name = Customers.name WHERE Customers.name='{Name}'";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Trace.Write("Starting....");
				Trace.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)}  ");
			}
		}
	}
}
