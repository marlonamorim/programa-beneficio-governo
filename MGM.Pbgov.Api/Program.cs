using MGM.Pbgov.Api;
using MGM.Pbgov.Infrastructure.Api.Filters;
using MGM.Pbgov.Infrastructure.DependencyInjection;
using MGM.Pbgov.Core.DependencyInjection;
using MGM.Pbgov.AppServices.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opts =>
{
    opts.Conventions.Add(new RouteTokenTransformerConvention(new ToKebabParameterTransformer()));
    opts.Filters.Add<ExceptionFilter>();
});
builder.Services.AddErrorHandlerServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{

    opt.TagActionsBy(api =>
    {
        if (api.GroupName != null)
            return [api.GroupName];

        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            return [controllerActionDescriptor.ControllerName];

        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });

    opt.DocInclusionPredicate((name, api) => true);
    opt.EnableAnnotations();
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddQueryables();
builder.Services.AddDomainServices();
builder.Services.AddAssertions();
builder.Services.AddDomainServices();
builder.Services.AddAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
