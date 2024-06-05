using MisterVideo.Core;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MisterVideo.MVVM.Model
{
	internal class Rental 
	{
		public string Name { get; set; }
		public string Title { get; set;}
		public int RentalID { get; set; }
		public string Duedate { get; set; }

		public Rental(string customer, string movie, string date)
		{
			Name = customer;
			Title = movie;
			Duedate = date;
		}
		public void Add()
		{
			var connectionID = MVDatabase.CreateConnection();
			var commandID = new SQLiteCommand(connectionID);
			commandID.CommandText = $"SELECT id FROM Movies WHERE title='{Title}'";
			var reader = commandID.ExecuteReader();
			while (reader.Read())
			{
				RentalID = reader.GetInt32(0);
			}
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"INSERT INTO Rentals( name, title, duedate, rentalid) VALUES( '{Name}', '{Title}', '{Duedate}', '{RentalID}')";
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
		public void Read()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			command.CommandText = $"SELECT title, Customers.name, duedate, rentalid FROM Rentals LEFT JOIN Customers ON Rentals.name = Customers.name WHERE Rentals.name='{Name}'";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Trace.Write("Starting....");
				Trace.WriteLine($"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)}  ");
				//{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetString(4)}"
			}
		}
		public void Remove()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"DELETE FROM Rentals WHERE rentalid = '{RentalID}'";
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

	}
}
