using Class05.Models;

namespace Class05.Data
{
    public class DbInitializer
    {
        private Class05Context _context;

        public DbInitializer(Class05Context context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            var categorias = new Category[] { };

            if (_context.Category.Any() == false)
            {
                categorias = new Category[]{
                    new Category{ Name = "Programming", Description = "Algoritms and programming area courses", Date=DateTime.Now.AddDays(-5)},
                    new Category{ Name = "Administration", Description = "Public administration and business management courses", Date=DateTime.Parse("22/02/2021")},
                    new Category{ Name = "Communication", Description = "Business and institutional communication course", Date=DateTime.Now}
                };

                //_context.Category.AddRange(categorias);
                foreach (var c in categorias)
                {
                    _context.Category.Add(c);
                }
                _context.SaveChanges();
            }

            if (_context.Course.Any()) return;

            var courses = new Course[]
            {
                new Course
                {
                    Name="Web Engineering",
                    Description="Creating new sites using ASP.NET",
                    Cost=50, Credits=6,
                    CategoryId=categorias.Single(c=>c.Name=="Programming").Id
                },
                new Course
                {
                    Name="Strategic Leadership and Management",
                    Description="Leadership and Business Skill for Immediate Impact.",
                    Cost=100, Credits=6,
                    Category=categorias.Single(c=>c.Name=="Administration")
                },
                new Course
                {
                    Name="Master in Corporate Communication",
                    Description="This Master in Corporate Communication will provide required to organize a Communication Department.",
                    Cost=80,Credits=10,
                    Category=categorias.Single(c=>c.Name=="Communication")
                }
            };

            _context.Course.AddRange(courses);
            _context.SaveChanges();
        }


    }
}
