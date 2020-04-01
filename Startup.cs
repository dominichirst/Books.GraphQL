using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Server;

using GraphQL.Server.Ui.Playground;
using Books.GraphQL.DbContexts;
using Books.GraphQL.Services;
using Books.GraphQL.Subscriptions;
using Npgsql;

namespace Books.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<BooksContext>(options =>
            {
                var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                var databaseUri = new Uri(databaseUrl);
                var userInfo = databaseUri.UserInfo.Split(':');

                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/')
                };

                var connectionString =  builder.ToString();
                options.UseNpgsql(connectionString);
            });

            services.AddSingleton<IAuthorMessageService, AuthorMessageService>();
            services.AddSingleton<AuthorAddedSubscription>();
            services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
            services.AddScoped<BooksSchema>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddGraphQL(o => o.ExposeExceptions = true)
                    .AddWebSockets()
                    .AddGraphTypes(ServiceLifetime.Scoped)
                    .AddDataLoader()
                    .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWebSockets();
            app.UseGraphQLWebSockets<BooksSchema>("/graphql");
            app.UseGraphQL<BooksSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
