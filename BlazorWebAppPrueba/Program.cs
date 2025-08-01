using Application;
using BlazorWebAppPrueba.Components;
using BlazorWebAppPrueba.Helpers;
using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Context;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//builder.Services.AddSession();
builder.Services.AddDbContext<AppContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbPokedex")));

builder.Services.AddScoped<IMapper<Pokemon, CarritoItem>, MapToCarritoItem>();
builder.Services.AddScoped<IRepositoryPokemon<Pokemon>, PokemonRepository>();
builder.Services.AddScoped<IRepositoryElemento<Elemento>, ElementoRepository>();
builder.Services.AddScoped<IRepositoryPedido<Pedido>, PedidoRepository>();
builder.Services.AddScoped<IRepositoryPedidoDetalle<PedidoDetalle>, PedidoDetalleRepository>();
builder.Services.AddScoped<IRepositoryUser<User>, UsuarioRepository>();
builder.Services.AddScoped<CarritoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<PedidoDetalleService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<SearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSession();
app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
