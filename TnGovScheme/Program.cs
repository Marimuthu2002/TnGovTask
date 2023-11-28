using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using TnGovtSchemeCommon.Helper;
using TnGovtSchemeLogic.Handler;
using TnGovtSchemeRepository.InterFace;
using TnGovtSchemeRepository.Service;

namespace TnGovScheme
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
            });

            builder.Services.AddMediatR(typeof(CandidateRegisterHandler).Assembly);

            builder.Services.AddScoped<IcandidateRegister, CandidateRegister>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}