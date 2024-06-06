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
using System.Xml.Linq;

namespace MisterVideo.MVVM.Model
{
	internal class Movie
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public string Director { get; set; }
		public string Actors { get; set; }
		public string Language { get; set; }
		public string Genre { get; set; }
		public string Format { get; set; }
		public int IsAvailable { get; set; }
		public string Section	{ get ; set; }

		public Movie(string title, int year, string director, string actors, 
			string language, string genre, string format, int isavailable, string section)
		{
			Title = title;
			Year = year;
			Director = director;
			Actors = actors;
			Language = language;
			Genre = genre;
			Format = format;
			IsAvailable = isavailable;
			Section = section;
		}

		public void Add()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"INSERT INTO Movies( title, year, director, actors, " +
				$"language, genre, format, isavailable, section) VALUES( '{Title}', " +
				$"'{Year}', '{Director}', '{Actors}', '{Language}', '{Genre}','{Format}'," +
				$"'{IsAvailable}','{Section}')";
			try
			{
				command.CommandText = statement;
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Trace.WriteLine(e);
			}
			var connectionID = MVDatabase.CreateConnection();
			var commandID = new SQLiteCommand(connectionID);
			commandID.CommandText = $"SELECT * FROM Movies WHERE title='{Title}'";
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
			command.CommandText = $"SELECT * FROM Movies WHERE id='{ID}'";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Trace.Write("Starting....");
				Trace.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} " +
					$"{reader.GetInt32(2)} {reader.GetString(3)} {reader.GetString(4)} " +
					$"{reader.GetString(5)} {reader.GetString(6)} {reader.GetString(7)} " +
					$"{reader.GetInt32(8)} {reader.GetString(9)} ");
			}
		}
		public void Update()
		{
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			string statement = $"UPDATE Movies SET title = '{Title}', " +
				$"year = '{Year}', director = '{Director}', actors = '{Actors}', " +
				$"language = '{Language}', genre = '{Genre}' , format= '{Format}' , " +
				$"isavailable= '{IsAvailable}', section = '{Section}'  WHERE id = '{ID}'";
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
			string statement = $"DELETE FROM Movies WHERE id = '{ID}'";
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
