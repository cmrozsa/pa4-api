using api.model;
namespace mis321_pa4_cmrozsa
{
    public interface ISavePosts
    {
         public void CreatePosts(Post myPost);
         public void SavePosts(Post myPost);
    }
}