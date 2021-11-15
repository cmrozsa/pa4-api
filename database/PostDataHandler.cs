using System.Dynamic;
using System.Data.Common;
using System.Net.Mime;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using api.interfaces;
using api.model;
using api.database;

namespace api.database
{
    public class PostDataHandler : IPostDataHandler
    { 
        private database db;
        public PostDataHandler() {
            db = new database();
        }
        public void Delete(Post post){
            string sql = "UPDATE posts SET deleted = 'Y' WHERE id = @id";
            
            var values = GetValues(post);
            db.Open();
            db.Insert(sql, values);
            db.Close();

         }

         public void Insert(Post post){
             string sql = "INSERT INTO posts (post, date, deleted) ";
            sql += "VALUES (@post, @date, 'N')";

            post.Date = DateTime.Now.ToString();

            var values = GetValues(post);
            db.Open();
            db.Insert(sql, values);
            db.Close();
         }

        public List<Post> Select(){ 
            db.Open();
            string sql = "SELECT * FROM posts WHERE deleted = 'N' order by id desc";
            List<ExpandoObject> result = db.Select(sql);

            List<Post> posts = new List<Post>();
            foreach (dynamic item in result)
            {
                Post temp = new Post(){
                    PostID = item.id,
                    PostText = item.post,
                    Date = item.date
                };
                db.Close();
                posts.Add(temp);
            }

            return posts;
        }

         
         public void Update(Post post){
             Console.WriteLine("Made it to the Update" + post.PostText);
             
             string sql = "UPDATE posts SET post = @post, date = @date WHERE id= @id; ";
 
            var values = GetValues(post);
            db.Open();
            db.Insert(sql, values);
            db.Close();
         }

        public Dictionary<string, object> GetValues(Post post)
        {
            Console.WriteLine("MAde it to dictionary"+ post.PostText);
            var values = new Dictionary<string, object>(){
                {"@id", post.PostID},
                {"@post", post.PostText},
                {"@date", post.Date}
            };
            return values;
        }
    }
}