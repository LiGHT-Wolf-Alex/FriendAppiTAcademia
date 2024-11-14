using FriendApp.BLL.Interfaces;
using FriendApp.BLL.Services;
using FriendApp.DAL.Interfaces;
using FriendApp.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IFriendRepository, FriendRepository>();
builder.Services.AddSingleton<IFriendService, FriendService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Friend}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();