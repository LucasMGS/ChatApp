using Chat.Infrastructure;
using Chat.WebApp.Configurations;
using Chat.WebApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/HomeChatRoom");
    options.Conventions.AllowAnonymousToPage("/Login");
    options.Conventions.AllowAnonymousToPage("/Register");
});
builder.Services.AddControllersWithViews();

builder.Services.AddAuth();

builder.Services.AddSignalR();
builder.Services.InjectApiServices(builder.Configuration);


builder.Services.AddControllers();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

//using (var scope = app.Services.CreateScope())
//{

//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();
//    var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
//    var identityUserCreate = new IdentityUser<Guid> { UserName = "Lucas", Email = "lucasmgs21@gmail.com" };
//    await userManager.CreateAsync(identityUserCreate, password: "chat123321");
//    var identityUser = await userManager.FindByEmailAsync("lucasmgs21@gmail.com");
//    var user = new User("Lucas", identityUser!.Id);
//    userRepository.Add(user);
//    await userRepository.SaveChangesAsync(new CancellationToken());
//}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/Chat/Hub");

app.MapRazorPages();

app.Run();
