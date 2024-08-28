using NagarPalika.Application;
using NagarPalika.IOC;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddHealthChecks();
//builder.Services.AddControllers();
//builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Home/Index";
                     config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                 });
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddApplicationDependencyInjection();
builder.Services.AddMediatRDependencyInjection();
builder.Services.AddServiceDependency(builder);
builder.AddSerilogDependencyInjection();
builder.Services.AddEmailService(builder.Configuration);
builder.Services.AddGEOLocation(builder.Configuration);
builder.Services.AddEncryptionService(builder.Configuration);
builder.Services.AddJWTService(builder.Configuration);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("ApiCorsPolicy",
//        builder => builder.AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader());
//});

//#region content Negotiation 
//builder.Services.AddMvc(option => option.RespectBrowserAcceptHeader = true);
//#endregion

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver(),
    NullValueHandling = NullValueHandling.Ignore
};




var app = builder.Build();


//app.UseCors("ApiCorsPolicy");
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");

app.Run();