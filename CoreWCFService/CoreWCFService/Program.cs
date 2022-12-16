using CoreWCFService.Core.Interfaces;
using CoreWCFService.Infrastructure.Data;
using CoreWCFService.Infrastructure.Repositorie;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
builder.Services.AddDbContext<WcfContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Wcf"));
});
builder.Services.AddTransient<IUsuarioRepository,UsuarioRepository>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<UsuarioService>();
    serviceBuilder.AddServiceEndpoint<UsuarioService, IUsuarioRepository>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Service.svc");
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();
