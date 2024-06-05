using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Controls;
using System.Data.Entity;

namespace MisterVideo.Core
{
	internal class MVDatabase
	{
		public MVDatabase() 
		{
			string connectionString = "Data Source=mydatabase.db;Version=3;";
			var connection = new SQLiteConnection(connectionString);
			connection.Open();

			var command = new SQLiteCommand(connection);
			try
			{ 
				command.CommandText = "DROP TABLE Movies"; 
				command.ExecuteNonQuery();
				command.CommandText = "DROP TABLE Customers";
				command.ExecuteNonQuery();
				command.CommandText = "DROP TABLE Rentals";
				command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex);
			}
			CreateTable(connection);
			command.CommandText = "SELECT * FROM sqlite_master WHERE type='table'";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Trace.Write("Starting....");
				Trace.WriteLine(reader.GetString(1));
			}
		}
	/*	     	   -----------------------------------------------------------------			*/
		public static SQLiteConnection CreateConnection()
		{
			 SQLiteConnection sqlite_conn;
			// Create a new database connection:
			sqlite_conn = new SQLiteConnection("Data Source=mydatabase.db; Version = 3; New = True;");
			// Open the connection:
			 try
			{
				sqlite_conn.Open();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
			}
			return sqlite_conn;
		}
		public void CreateTable(SQLiteConnection conn)
		{

			SQLiteCommand sqlite_cmd;
			string createMovies = "CREATE TABLE IF NOT EXISTS Movies(id INTEGER PRIMARY KEY AUTOINCREMENT, title VARCHAR(20), year INT, director VARCHAR(20), actors VARCHAR(255), language VARCHAR(20), genre VARCHAR(255), format VARCHAR(20), isAvailable INT, section VARCHAR(20))";
			string createCustomers = "CREATE TABLE IF NOT EXISTS Customers(id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(20), address VARCHAR(255), email VARCAHR(20), phone VARCHAR(20))";
			string createRentals = "CREATE TABLE IF NOT EXISTS Rentals(name VARCHAR(20), title VARCHAR(20), rentalid INT, duedate VARCHAR(20))";
			sqlite_cmd = conn.CreateCommand();
			sqlite_cmd.CommandText = createMovies;
			sqlite_cmd.ExecuteNonQuery();
			sqlite_cmd.CommandText = createCustomers;
			sqlite_cmd.ExecuteNonQuery();
			sqlite_cmd.CommandText = createRentals;
			sqlite_cmd.ExecuteNonQuery();
		}
		static void ReadData(SQLiteConnection conn, string table)
		{
			SQLiteDataReader sqlite_datareader;
			SQLiteCommand sqlite_cmd;
			try
			{
				sqlite_cmd = conn.CreateCommand();
				sqlite_cmd.CommandText = $"SELECT * FROM {table}";
				sqlite_datareader = sqlite_cmd.ExecuteReader();
				while (sqlite_datareader.Read())
				{
					string myreader = sqlite_datareader.GetString(0);
					Console.WriteLine(myreader);
				}

			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
			}
			conn.Close();
		}
	}
}
