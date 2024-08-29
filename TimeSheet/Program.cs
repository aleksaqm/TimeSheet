using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions;
using Services.Abstractions;
using Services.Implementations;
using Services.MappingProfiles;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

        builder.Services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
        builder.Services.AddTransient<ITeamMemberService, TeamMemberService>();

        builder.Services.AddTransient<IClientRepository, ClientRepository>();
        builder.Services.AddTransient<IClientService, ClientService>();

        builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
        builder.Services.AddTransient<IProjectService, ProjectService>();

        builder.Services.AddTransient<IActivityRepository, ActivityRepository>();
        builder.Services.AddTransient<IActivityService, ActivityService>();

        builder.Services.AddDbContext<RepositoryDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddAutoMapper(typeof(MappingProfile));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}