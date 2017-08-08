using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliaBlogv1.Models.ViewModels
{
    public class PostsIndexViewModel
    {
      public PostsIndexViewModel(string id)
      {
         var db = new ApplicationDbContext();

         Posts = db.Posts.Where(x => x.AuthorId == id).ToList();

      }
      public List<Post> Posts { get; set; }
    }
}
