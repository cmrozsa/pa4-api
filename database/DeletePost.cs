using System;
using System.Data;
using MySql.Data.MySqlClient;
//using System.MySql.data;

namespace mis321_pa4_cmrozsa.database
{
    public class DeletePosts : IDeletePost
    {
        public static void DropPostTable()
        {
            ConnectionString myConnection = new ConnectionString();//creates connection
            string cs = myConnection.cs;//creates connection string
            using var con = new MySqlConnection(cs);//connects to database
            con.Open();//opens connection to database

            string stm = @"DROP TABLE IF EXISTS posts";//if there is a table called posts, delete it

            using var cmd = new MySqlCommand(stm, con);//sets it
            cmd.ExecuteNonQuery();//runs it and officially changes it
        }
        public void DeletePost(int id)
        {
            ConnectionString myConnection = new ConnectionString();//creates connection
            string cs = myConnection.cs;//creates connection string
            using var con = new MySqlConnection(cs);//connects to database
            con.Open();//opens connection to database

            string stm = $@"DELETE FROM ub2s5wmclxqi2la8.posts WHERE ID = {id}";//delete line from database where postID = userinputed ID
            
            try{
                MySqlCommand cmd = new MySqlCommand(stm, con);//sets it
                cmd.ExecuteNonQuery();//runs it and changes it officially

            }
            finally {
                con.Close();//close connection
            }
        }
    }
}