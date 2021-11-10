using System;
using mis321_pa4_cmrozsa.database;
using api.interfaces;
using api.database;

namespace api.model
{
    public class Post
    {
        public int PostID {get; set;}
        public string PostText {get; set;}
        public string Date {get; set;}
        public IPostDataHandler dataHandler {get; set;}
        public Post(){
            dataHandler = new PostDataHandler();
        } 
    }
}