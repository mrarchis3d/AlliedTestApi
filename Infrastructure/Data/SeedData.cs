using Domain.Entities;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(this MovieDbContext context)
        {
            context.Database.EnsureCreated(); 

            if (!context.Movies.Any())
            {
                var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "The End Of The Line",
                    Description = "Tom Bush and Ciaran Churchman in The 42 Years (2024)",
                    Year = 2024,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BNzA0NTdkYmMtZGQ0YS00MGUyLTg0YmItN2VmOTcyYzM3ZDM5XkEyXkFqcGdeQXVyMTI3MTQzNzk1._V1_.jpg" }
                },
                new Movie
                {
                    Title = "The Gods of Darkness",
                    Description = "Nunc nisi justo, semper vel mollis sed, ultricies in tellus. Nunc lacinia lobortis hendrerit.,",
                    Year = 2023,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BZGRjMTQ5NTAtYmM3Yi00ODFlLWE5ZDUtNjM1MGUwYzZiNjU2XkEyXkFqcGdeQXVyMTI3MTQzNzk1._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Paltrocast",
                    Description = "Miranda Otto + Neil deGrasse Tyson + Scott Hamilton Kennedy + Devon Allman",
                    Year = 2023,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BOGVkNjIyY2UtMDQyZS00NGRmLTkzYjgtOTVjYjE4MDc0M2ViXkEyXkFqcGdeQXVyMTQ1MjM1NDU@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "The Devil's Dandruff",
                    Description = "sit amet, consectetur adipiscing elit. Pellentesque vel neque vitae ligula porttitor scelerisque. Quisque ac ullamcorper",
                    Year = 2024,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BYTYzNzkzMDctOGVjOS00MzQwLWE4MTYtMDYwOGQ5ODQ0ZjE5XkEyXkFqcGdeQXVyMjMxNjQ4MDI@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Untitled Silver Screen Showdown Finale",
                    Description = " in justo accumsan, nec vestibulum erat feugiat. Curabitur rutrum gravida erat, a sollicitudin lacus hendrerit posuere. Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Year = 2018,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BOGU3YzZlOWEtZDkzNi00NDRjLWJmNDUtNWE4ZmQ1YTljY2VjXkEyXkFqcGdeQXVyNTA4OTUyMTE@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Caleb Lee Hutchinson + Gitty",
                    Description = "nsectetur adipiscing elit. Vestibulum eleifend tortor in justo",
                    Year = 2025,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BNmEwY2FkMTMtZDBjNi00YjMwLThkOGEtOTFhNjRiZTE0ZTZkXkEyXkFqcGdeQXVyMTQ1MjM1NDU@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "The Divine Comedy: Inferno, Purgatory and Paradise",
                    Description = "Tom Bush and Ciaran Churchman in The 42 Years (2024)",
                    Year = 2022,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BZWIyNzE3NzEtMGExNS00ZjRkLWJmMTYtMWFlNTNkNDgyNWUzXkEyXkFqcGdeQXVyODUwMzI5ODk@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Dark Forest: Dante's Sins. Virgil appears.",
                    Description = "Vittorio Matteucci and Lalo Cibelli in The Divine Comedy: Inferno, Purgatory and Paradise (2024)",
                    Year = 2022,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BNjMxNzRjMzQtOTI3Ny00ZmUyLTg4ZDMtMTA4NzdlNDZlYzhiXkEyXkFqcGdeQXVyODUwMzI5ODk@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Dessinateur: Von Bismark",
                    Description = "rit posuere. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vel neque vitae ligula porttitor scelerisque. Quisque ac ullamcorper nisl, nec rhoncus lorem",
                    Year = 1896,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BZGUxMmJiZjEtMDdkNC00MGMzLWI3MTItOTJiYmNhOGM0Mjk5XkEyXkFqcGdeQXVyNTI2NTY2MDI@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Cripple Creek Bar-Room Scene",
                    Description = " lorem. Nunc nisi justo, semper vel mollis sed, ultricies in tellus. Nunc lacinia lobo",
                    Year = 1899,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BNjg1MGM4Y2MtYThkNy00NDc0LWIxMzItYzk0MDc1ZTRhNTkxXkEyXkFqcGdeQXVyNzg5OTk2OA@@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Les haleurs de bateaux",
                    Description = "Les haleurs de bateaux (1910)",
                    Year = 1910,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BM2ZlYjA4NmItZTYxYy00MGFiLTg3MWUtNzZmYjE1ODZmMThjXkEyXkFqcGdeQXVyNTI2NTY2MDI@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "El Tango del Viudo y Su Espejo Deformantex",
                    Description = "El Tango del Viudo y Su Espejo Deformante (2020)",
                    Year = 2020,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BZWU2NzQ4NDgtZTdlNC00OGQ4LTk0OGItMTliOTE2YTViZmE3XkEyXkFqcGdeQXVyMTAxMDQ0ODk@._V1_.jpg" }
                },
                new Movie
                {
                    Title = "Pit Bull",
                    Description = "Pbitur rutrum gravida erat, a sollicitudin lacus hendrerit posuere. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vel neque vitae ligula porttitor scelerisque",
                    Year = 2020,
                    PosterImage = new Image{ UrlImage = "https://m.media-amazon.com/images/M/MV5BOTdjOGViMjUtYWE0MS00NDQzLTlmZWQtNjQyMThhMjMwMTI1XkEyXkFqcGdeQXVyNjg5ODE0MDQ@._V1_.jpg" }
                },
            };

                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}
