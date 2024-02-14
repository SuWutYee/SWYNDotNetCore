using DotNetCoreTraining.WebApi.Models;

namespace DotNetCoreTraining.WebApi.EfCoreExamples
{
    public class EfCoreExample
    {
        public void Read()
        {
            using var db = new BlogDbContext();
            var lstBlog = db.Blogs.ToList();

            foreach (BlogModel item in lstBlog)
            {
                Console.WriteLine($"Title : {item.BlogTitle}");
                Console.WriteLine($"Author : {item.BlogAuthor}");
                Console.WriteLine($"Content : {item.BlogContent}");
            }
        }

        public void Edit(int id)
        {
            using var db = new BlogDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No data found!");
                return;
            }

            Console.WriteLine($"Title : {item.BlogTitle}");
            Console.WriteLine($"Author : {item.BlogAuthor}");
            Console.WriteLine($"Content : {item.BlogContent}");
        }

        public void Create(string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using var db = new BlogDbContext();
            db.Blogs.Add(blogModel);
            var result = db.SaveChanges();

            var message = result == 0 ? "Create Fail!" : "Create Success.";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            using var db = new BlogDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                Console.WriteLine("No data found!");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            var result = db.SaveChanges();

            var message = result == 0 ? "Edit Fail!" : "Edit Success.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            using var db = new BlogDbContext();
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No data found!");
                return;
            }
            db.Blogs.Remove(item);
            var result = db.SaveChanges();

            var message = result == 0 ? "Delete Fail!" : "Delete Success.";
            Console.WriteLine(message);
        }
    }
}
