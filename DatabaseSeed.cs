using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIExercise.Data;
using WebAPIExercise.Data.Models;

namespace WebAPIExercise
{
    public class DatabaseSeed
    {
        private IApplicationBuilder _app;

        public DatabaseSeed(IApplicationBuilder application){
            _app = application;
        }
        public void Initialize()
        {
            using (var serviceScope = _app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<WebAPIExerciseContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if ( !context.Posts.Any() ){

                    context.Posts.AddRange(
                        new List<Post>{
                            new Post{
                                Id = 1,
                                Title = "Titulo 1",
                                Body = "Contenido test 1",
                                Autor = "El equipo"
                            },
                            new Post{
                                Id = 2,
                                Title = "Titulo 2",
                                Body = "Contenido test 2",
                                Autor = "El equipo"
                            }
                        }
                    );
                }

                
                
                if ( !context.Comments.Any() ){

                    context.Comments.AddRange(
                        new List<Comment>{
                            new Comment{
                                Id = 1,
                                Body = "Comentario 1 en el post 1",
                                Autor = "Luis",
                                PostId = 1   
                            },
                            new Comment{
                                Id = 2,
                                Body = "Comentario 2 en el post 1",
                                Autor = "Edith",
                                PostId = 1
                            },
                            new Comment{
                                Id = 3,
                                Body = "Comentario 3 en el post 2",
                                Autor = "Humberto",
                                PostId = 2
                            }
                        }
                    );
                }
                

                context.SaveChanges();

            }
        }
    }
}