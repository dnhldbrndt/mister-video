using MisterVideo.Core;
using MisterVideo.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisterVideo.MVVM.ViewModel
{
	internal class MoviesViewModel : ObservableObject
	{
		public List<Movie> Movies { get; set; }
		public MoviesViewModel()
		{
			Movies = new List<Movie>();
			BuildMoviesList();
		}
		public void BuildMoviesList()
		{
			Movies.Clear();
			var connection = MVDatabase.CreateConnection();
			var command = new SQLiteCommand(connection);
			command.CommandText = $"SELECT * FROM Movies";
			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				Movie movie = new Movie(reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
				movie.ID = reader.GetInt32(0);
				Movies.Add(movie);
				Trace.WriteLine($"Added... {reader.GetString(1)}");
			}
		}
		public void PrintCustomerList()
		{
			foreach (var customer in Movies)
			{
				Trace.WriteLine(customer.ToString());
			}
		}
		public void AddMovie(string title, int year, string director, string actors,
			string language, string genre, string format, int isavailable, string section)
		{
			Movie movie = new Movie(title, year, director, actors, language, genre, format, isavailable, section);
			movie.Add();
			Movies.Add(movie);
		}
		public void RemoveMovie(string arg)
		{
			Movie movie = Movies.First(item => item.Title == arg);
			movie.Remove();
			Movies.Remove(movie);
		}
		public void UpdateMovie(string arg, string attribute, string value)
		{
			attribute = attribute.ToLower();
			Movie movie= Movies.First(item => item.Title == arg);
			int tmpID = movie.ID;
			switch (attribute)
			{
				case "title":
					movie.Title = value;
					break;
				case "year":
					movie.Year = int.Parse(value);
					break;
				case "director":
					movie.Director = value;
					break;
				case "actors":
					movie.Actors = value;
					break;
				case "language":
					movie.Language = value;
					break;
				case "genre":
					movie.Genre= value;
					break;
				case "format":
					movie.Format = value;
					break;
				case "isavailable":
					movie.IsAvailable = int.Parse(value);
					break;
				case "section":
					movie.Section = value;
					break;
				default:
					break;
			}
			movie.Update();
		}
		public Movie ReturnMovie(string arg)
		{
			Movie movie = Movies.First(item => item.Title == arg);
			return movie;
		}
	}
}
