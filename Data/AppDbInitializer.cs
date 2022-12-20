﻿using Microsoft.EntityFrameworkCore;
using MovieTickets.Data.Enums;
using MovieTickets.Models;

namespace MovieTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                // Cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>() {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        }
                    });
                    context.SaveChanges();
                }

                // Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>() {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>() {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Movie
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            Category = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Title = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            Category = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Title = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            Category = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Title = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            Category = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Title = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            Category = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Title = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            Category = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }

                // Actor_Movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        }
                    });
                    context.SaveChanges();
                }
            }
                /*modelBuilder.Entity<Actor>().HasData(
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    );*/

                /*modelBuilder.Entity<Cinema>().HasData(
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            LogoURL = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        }
                    );*/

                /*modelBuilder.Entity<Producer>().HasData(
                    new Producer()
                    {
                        FullName = "Producer 1",
                        Bio = "This is the Bio of the first actor",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                    },
                    new Producer()
                    {
                        FullName = "Producer 2",
                        Bio = "This is the Bio of the second actor",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                    },
                    new Producer()
                    {
                        FullName = "Producer 3",
                        Bio = "This is the Bio of the second actor",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                    },
                    new Producer()
                    {
                        FullName = "Producer 4",
                        Bio = "This is the Bio of the second actor",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                    },
                    new Producer()
                    {
                        FullName = "Producer 5",
                        Bio = "This is the Bio of the second actor",
                        ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                    }
                );*/

                /*modelBuilder.Entity<Movie>().HasData(
                    new Movie()
                    {
                        Title = "Life",
                        Description = "This is the Life movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(10),
                        CinemaId = 3,
                        ProducerId = 3,
                        Category = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        Title = "The Shawshank Redemption",
                        Description = "This is the Shawshank Redemption description",
                        Price = 29.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(3),
                        CinemaId = 1,
                        ProducerId = 1,
                        Category = MovieCategory.Action
                    },
                    new Movie()
                    {
                        Title = "Ghost",
                        Description = "This is the Ghost movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        CinemaId = 4,
                        ProducerId = 4,
                        Category = MovieCategory.Horror
                    },
                    new Movie()
                    {
                        Title = "Race",
                        Description = "This is the Race movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-5),
                        CinemaId = 1,
                        ProducerId = 2,
                        Category = MovieCategory.Documentary
                    },
                    new Movie()
                    {
                        Title = "Scoob",
                        Description = "This is the Scoob movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(-2),
                        CinemaId = 1,
                        ProducerId = 3,
                        Category = MovieCategory.Cartoon
                    },
                    new Movie()
                    {
                        Title = "Cold Soles",
                        Description = "This is the Cold Soles movie description",
                        Price = 39.50,
                        ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                        StartDate = DateTime.Now.AddDays(3),
                        EndDate = DateTime.Now.AddDays(20),
                        CinemaId = 1,
                        ProducerId = 5,
                        Category = MovieCategory.Drama
                    }
                );*/

                /*modelBuilder.Entity<Actor_Movie>().HasData(
                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 1
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 1
                    },

                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 2
                    },

                    new Actor_Movie()
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 3
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 3
                    },


                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 4
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 4
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 4
                    },


                    new Actor_Movie()
                    {
                        ActorId = 2,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 5
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 5
                    },


                    new Actor_Movie()
                    {
                        ActorId = 3,
                        MovieId = 6
                    },
                    new Actor_Movie()
                    {
                        ActorId = 4,
                        MovieId = 6
                    },
                    new Actor_Movie()
                    {
                        ActorId = 5,
                        MovieId = 6
                    }
                );*/
        }
    }
}
