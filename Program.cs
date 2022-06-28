using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

// using var context = new BlogDataContext();

// var user = new User
// {
//     Name = "Dodo of Fire",
//     Slug = "dodooffire",
//     Bio = "Dodo of the old ages of fire",
//     Email = "dodo@dodo.com",
//     PasswordHash = "271198",
//     Image = "dodo.png"
// };

// var category = new Category
// {
//     Name = "Backend",
//     Slug = "backend"
// };

// var post = new Post
// {
//     Author = user,
//     Category = category,
//     Body = "<p>hello World<p>",
//     Slug = "comecando-com-ef-core",
//     Summary = "neste artigo vamos aprender ef core",
//     Title = "Comecando com EF Core",
//     CreateDate = DateTime.Now,
//     LastUpdateDate = DateTime.Now
// };

// context.Posts.Add(post);

// context.SaveChanges();

// var posts = context
//     .Posts
//     .AsNoTracking()
//     .Include(x => x.Author)
//     .Include(x => x.Category)
//     .OrderBy(x => x.LastUpdateDate)
//     .ToList();

// foreach (var post in posts)
//     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");

// var post = context
//     .Posts
//     .Include(x => x.Author)
//     .Include(x => x.Category)
//     .OrderBy(x => x.LastUpdateDate)
//     .FirstOrDefault();

// post.Author.Name = "Dodo Of Little Fire";

// context.Posts.Update(post);

// context.SaveChanges();


// using var context = new BlogDataContext();

// context.Users.Add(new User
// {
//     Name = "Dodo of Ice",
//     Slug = "dodoofice",
//     Bio = "Dodo of the old ages of Ice",
//     Email = "dodoIce@dodo.com",
//     PasswordHash = "271198",
//     Image = "dodo.png"
// });

// var user = context.Users.FirstOrDefault();

// var post = new Post
// {
//     Author = user,
//     Category = new Category
//     {
//         Name = "Backend2",
//         Slug = "backend2"
//     },
//     Body = "<p>hello World<p>",
//     Slug = "comecando-com-ef-core2",
//     Summary = "neste artigo vamos aprender ef core",
//     Title = "Comecando com EF Core",
//     CreateDate = DateTime.Now,
// };

// context.Posts.Add(post);

// context.SaveChanges();

using var context = new BlogDataContext();

static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
{
    var posts = context
                .Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();

    return posts;
}

var posts = GetPosts(context, 0, 25);
posts = GetPosts(context, 25, 25);
posts = GetPosts(context, 50, 25);
posts = GetPosts(context, 75, 25);