using Autofac.Extensions.DependencyInjection;
using Autofac;
using SampleArch.Web.Module;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//初始化並建立一個實例
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//註冊autofac這個容器
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModuleRegister()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //builder.RegisterControllers(typeof(Program).Assembly).PropertiesAutowired();

    builder.RegisterModule(new RepositoryModule());
    builder.RegisterModule(new ServiceModule());
    builder.RegisterModule(new EFModule());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
