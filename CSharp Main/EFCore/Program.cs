using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogContext())
            {
                // Создаем автора и пост
                var author = new Author { Name = "John Doe" };
                var post = new BlogPost { Title = "EF Core Example", Content = "This is an example of using EF Core.", Author = author };

                // Добавляем автора и пост в базу данных
                context.Authors.Add(author);
                context.BlogPosts.Add(post);
                context.SaveChanges();

                // Запрос для получения всех постов и их авторов
                var postsWithAuthors = context.BlogPosts.Include(p => p.Author).ToList();

                // Выводим результат
                foreach (var p in postsWithAuthors)
                {
                    Console.WriteLine($"Post: {p.Title}");
                    Console.WriteLine($"Author: {p.Author.Name}\n");
                }
            }

        }
    }
}