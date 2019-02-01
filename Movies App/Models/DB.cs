using Movies_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Movie_App.Models
{
    public class DB
    {
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader rdr = null;
        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\output\My projects\ASP.NET\Management System v2\Movies App\Movies App\App_Data\database.mdf;Integrated Security=True";

        public DB()
        {
            connection = new SqlConnection(connString);
        }

        public List<Movie> getAll()
        {
            int i = 0;
            List<Movie> movies = new List<Movie>();
            
            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command with a query and connection
                cmd = new SqlCommand("select * from movie", connection);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Movie m = new Movie();

                    m.id = rdr.GetInt32(0);
                    m.name = rdr.GetString(1);
                    m.year = rdr.GetInt32(2);
                    m.type = rdr.GetString(3);
                    m.watched = rdr.GetBoolean(4);
                    m.img = rdr.GetString(5);
                    m.language = rdr.GetString(6);
                    m.deleted = rdr.GetBoolean(7);
                    m.userId = rdr.GetString(8);                  

                    movies.Add(m);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return movies;
        }

        public int add(Movie m)
        {
            int success=0;

            try
            {
                connection.Open();
                cmd = new SqlCommand(" insert into movie(name,year,type,img,watched,language,deleted,userId) values ('" + m.name + "',' " + m.year + "','" + m.type + "','" + m.img + "','" + m.watched + "','" + m.language + "','" + m.deleted + "','"  + m.userId + "') ", connection);
                success = cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return success;
        }

        public int update(Movie m)
        {
            int success = 0;

            try
            {
                connection.Open();
                string str = " update movie set name= '" + m.name + "',year=  '" + m.year + "',type= '" + m.type + "',watched= '" + m.watched +"',language='" + m.language + "',deleted='" + m.deleted + "',img='" + m.img + "' where id=  " + m.id  + "";
                Console.WriteLine(str);
                cmd = new SqlCommand(str , connection);
                success = cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return success;
        }

        public int delete(Movie m)
        {
            int success = 0;

            try
            {
                connection.Open();
                string str = "delete from movie where id='" + m.id + "'";
                Console.WriteLine(str);
                cmd = new SqlCommand(str, connection);
                success = cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return success;
        }

        public void towatch(ToWatchList toWatchList)
        {
            try
            {
                connection.Open();
                string str=" insert into towatch(userid,movieid) values ('" + toWatchList.userId + "',' " + toWatchList.movieId + "') ";
                //Console.WriteLine(str);
                cmd = new SqlCommand(str, connection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<ToWatchList> getToWatch()
        {
            List<ToWatchList> toWatchMovies = new List<ToWatchList>();

            connection.Open();
            cmd = new SqlCommand("select * from towatch", connection);
            rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                ToWatchList m = new ToWatchList();
                m.userId= rdr.GetString(0);
                m.movieId = rdr.GetInt32(1);
                toWatchMovies.Add(m);
            }

            return toWatchMovies;
        }

        public void watched(int movieId, string userId)
        {
            try
            {
                connection.Open();
                string str = " update movie set watched= '" + true  +"' where id=  " + movieId + " and userId='" +userId + "'" ;
                cmd = new SqlCommand(str, connection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
