using FirstMVCApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace FirstMVCApp.Models
{
    public class MovieDbRepository
    {
        public static List<Movie> GetMovieList()
        {
            List<Movie> movielist = new List<Movie>();
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand selectmoviecmd = cn.CreateCommand();
                String selectAllMovies = "Select * from mvtbl";
                selectmoviecmd.CommandText = selectAllMovies;
                SqlDataReader moviedr = selectmoviecmd.ExecuteReader();
                while (moviedr.Read())
                {
                    Movie movie = new Movie
                    {
                        mID = moviedr.GetInt32(0),
                        title = moviedr.GetString(1),
                        language = moviedr.GetString(2),
                        Hero = moviedr.GetString(3),
                        Director = moviedr.GetString(4),
                        MusicDirector = moviedr.GetString(5),
                        ReleaseDate=moviedr.GetDateTime(6),
                        cost = moviedr.GetDecimal(7),
                        collection= moviedr.GetInt32(8),
                        review=moviedr.GetInt32(9)
                    };
                    movielist.Add(movie);
                }
                return movielist;
            }
        }
        public static Movie GetMovieById(int id)
        {
            Movie movieFound = null;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand selectmoviecmd = cn.CreateCommand();
                String selectMovies = "Select * from movietbl where mID=@id";
                selectmoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                selectmoviecmd.CommandText = selectMovies;
                SqlDataReader moviedr = selectmoviecmd.ExecuteReader();
                while (moviedr.Read())
                {
                    movieFound = new Movie
                    {
                        mID = moviedr.GetInt32(0),
                        title = moviedr.GetString(1),
                        language = moviedr.GetString(2),
                        Hero = moviedr.GetString(3),
                        Director = moviedr.GetString(4),
                        MusicDirector = moviedr.GetString(5),
                        ReleaseDate = moviedr.GetDateTime(6),
                        cost = moviedr.GetDecimal(7),
                        collection = moviedr.GetInt32(8)
                    };
                }
            }
            return movieFound;
        }
        public static int AddNewMovie(Movie newMovie)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand insertMoviecmd = cn.CreateCommand();
                String insertNewMovieQuery = "insert into mvtbl values( @id,@title,@language,@hero,@director,@musicdirector,@releasedate,@cost,@collection,@review )";
                insertMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = newMovie.mID;
                insertMoviecmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = newMovie.title;
                insertMoviecmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = newMovie.language;
                insertMoviecmd.Parameters.Add("@hero", SqlDbType.NVarChar).Value = newMovie.Hero;
                insertMoviecmd.Parameters.Add("@director", SqlDbType.NVarChar).Value = newMovie.Director;
                insertMoviecmd.Parameters.Add("@musicdirector", SqlDbType.NVarChar).Value = newMovie.MusicDirector;
                insertMoviecmd.Parameters.Add("@releasedate", SqlDbType.DateTime).Value = newMovie.ReleaseDate;
                insertMoviecmd.Parameters.Add("@cost", SqlDbType.Decimal).Value = newMovie.cost;
                insertMoviecmd.Parameters.Add("@collection", SqlDbType.Int).Value = newMovie.collection;
                insertMoviecmd.Parameters.Add("@review", SqlDbType.Int).Value = newMovie.review;
                insertMoviecmd.CommandText = insertNewMovieQuery;
                query_result = insertMoviecmd.ExecuteNonQuery();
            }
            return query_result;



        }
        public static int UpdateMovie(Movie modifiedMovie)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand updateMoviecmd = cn.CreateCommand();
                String updateMovieQuery = "insert into mvtbl values( @id,@title,@language,@hero,@director,@musicdirector,@releasedate,@cost,@collection,@review )";
                updateMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = modifiedMovie.mID;
                updateMoviecmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = modifiedMovie.title;
                updateMoviecmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = modifiedMovie.language;
                updateMoviecmd.Parameters.Add("@hero", SqlDbType.NVarChar).Value = modifiedMovie.Hero;
                updateMoviecmd.Parameters.Add("@director", SqlDbType.NVarChar).Value = modifiedMovie.Director;
                updateMoviecmd.Parameters.Add("@musicdirector", SqlDbType.NVarChar).Value = modifiedMovie.MusicDirector;
                updateMoviecmd.Parameters.Add("@releasedate", SqlDbType.DateTime).Value = modifiedMovie.ReleaseDate;
                updateMoviecmd.Parameters.Add("@cost", SqlDbType.Decimal).Value = modifiedMovie.cost;
                updateMoviecmd.Parameters.Add("@collection", SqlDbType.Int).Value = modifiedMovie.collection;
                updateMoviecmd.Parameters.Add("@review", SqlDbType.Int).Value = modifiedMovie.review;
                updateMoviecmd.CommandText = updateMovieQuery;
                query_result = updateMoviecmd.ExecuteNonQuery();
            }
            return query_result;
        }
        public static int DeleteMovie(int id)
        {
            int query_result = 0;
            using (SqlConnection cn = SqlHelper.CreateConnection())
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                SqlCommand deleteMoviecmd = cn.CreateCommand();
                String deleteMovieQuery = "Delete from mvtbl where mID=@id";
                deleteMoviecmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                deleteMoviecmd.CommandText = deleteMovieQuery;
                query_result = deleteMoviecmd.ExecuteNonQuery();
            }
            return query_result;
        }
    }
}
