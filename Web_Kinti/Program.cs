using Web_Kinti.Services.Interface;
using Web_Kinti.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(IAdmin), new AdminRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IComida), new ComidaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IComida), new AdminRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ICategoria), new CategoriaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IRol), new RolRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IReserva), new ReservaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IUsuario), new UsuarioRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ITemporalVenta), new TemporalVentaRepository()));



builder.Services.AddControllersWithViews();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(3600); });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();
