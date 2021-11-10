//using Internal;
using System;
using MySql.Data.MySqlClient;
using System.Data;
//using System.MySql.data;
using mis321_pa4_cmrozsa;
using api.model;

namespace mis321_pa4_cmrozsa.database
{

    public class SavePost : ISavePosts
    {
        public static void CreatePostTable()
        {
            ConnectionString myConnection = new ConnectionString();//creates connection
            string cs = myConnection.cs;//creates connection string
            using var con = new MySqlConnection(cs);//connects to database
            con.Open();//opens connection to database

            string stm = @"CREATE TABLE posts(id INTEGER PRIMARY KEY AUTO_INCREMENT, post TEXT, date TIMESTAMP)";
            //creates a table called posts and has the primary key as id and is automatically incremented, post as type text, and date as type timestamp


            using var cmd = new MySqlCommand(stm, con);//sets it
            cmd.ExecuteNonQuery();//runs it and officially changes it
        }
        public void SavePosts(Post myPost)
        {

        }
        public void CreatePosts(Post myPost)
        {
            ConnectionString myConnection = new ConnectionString();//creates connection
            string cs = myConnection.cs;//creates connection string
            using var con = new MySqlConnection(cs);//connects to database
            con.Open();//opens connection to database

            string stm = @"INSERT INTO posts(post, date) VALUES(@post, @date)";

            using var cmd = new MySqlCommand(stm, con);//sets it
            DateTime dateTimeVariable = DateTime.Now;//sets the date and time to the curent date and time on the system being used
            cmd.Parameters.AddWithValue("@post", myPost.PostText);//sets the post equal to user inputed text
            cmd.Parameters.AddWithValue("@date", dateTimeVariable);//sets date equal to the inputed date time variable
            cmd.Prepare();//prepares to run

            cmd.ExecuteNonQuery();//runs it and updates it officially
        }


    }
}