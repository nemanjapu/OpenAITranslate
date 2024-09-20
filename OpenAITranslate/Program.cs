using Autofac;
using Autofac.Extensions.DependencyInjection;
using GeminiAPI.Interfaces;
using GeminiAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Mscc.GenerativeAI.Web;
using OpenAITranslate.OpenAI.Helpers;
using OpenAITranslate.OpenAI.Interfaces;
using OpenAITranslate.OpenAI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddGenerativeAI(builder.Configuration.GetSection("Gemini"));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(conBuilder =>
    {

        conBuilder.RegisterType<ConfigReader>()
                .AsSelf()
                .SingleInstance();

        conBuilder.RegisterType<OpenAIServiceAsync>()
        .As<IOpenAiServiceAsync>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        conBuilder.RegisterType<GeminiApiServiceAsync>()
        .As<IGeminiApiServiceAsync>()
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
