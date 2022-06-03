using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sociala__Web_UI_.Entities;
using Sociala__Web_UI_.Helpers;
using Sociala__Web_UI_.Models;
using Sociala__Web_UI_.Services;
using Sociala_Business.Abstract;
using Sociala_Business.Concrete;
using Sociala_DataAccesss.Abstract;
using Sociala_DataAccesss.Concrete;
using Sociala_Entities.Concrete.DatabaseFirst;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddControllers().AddNewtonsoftJson();


builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddControllers().AddJsonOptions(o =>
{

    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

builder.Services.AddSignalR();
builder.Services.AddSignalRCore();


builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = 2147483648;
});


builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-JGUKKG5;User ID=sa; Password=admin1234;Initial Catalog=CustomUserDB; Integrated Security=True; ApplicationIntent=ReadWrite; MultipleActiveResultSets=True; Trusted_Connection=True;"));


builder.Services.AddSqlServer<SocialadbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>()
    .AddDefaultTokenProviders();




builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDAL, EF_CommentDAL>();

builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<IPostDAL, EF_PostDAL>();

builder.Services.AddScoped<IReactionService, ReactionManager>();
builder.Services.AddScoped<IReactionDAL, EF_ReactionDAL>();

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDAL, EF_UserDAL>();

builder.Services.AddScoped<ITagService, TagManager>();
builder.Services.AddScoped<ITagDAL, EF_TagDAL>();

builder.Services.AddScoped<IPostandTagService, PostandTagManager>();
builder.Services.AddScoped<IPostandTagDAL, EF_PostandTagDAL>();

builder.Services.AddScoped<INotificationService, NotificationManage>();
builder.Services.AddScoped<INotificationDAL, EF_NotificationDAL>();

builder.Services.AddScoped<INotificationReceiverService, NotificationReceiverManager>();
builder.Services.AddScoped<INotificationReceiverDAL, EF_NotificationReceiverDAL>();

builder.Services.AddScoped<INotificationSenderService, NotificationSenderManager>();
builder.Services.AddScoped<INotificationSenderDAL, EF_NotificationSenderDAL>();

builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IMessageDAL, EF_MessageDAL>();

builder.Services.AddScoped<IFriendService, FriendManager>();
builder.Services.AddScoped<IFriendDAL, EF_FriendDAL>();

builder.Services.AddScoped<INotificationSessionService, NotificationSessionService>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpContextAccessor();





IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<SocialadbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseDBConnString")));



builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();


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

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.MapControllers();

app.MapRazorPages();


    app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/{id2?}");
app.MapHub<ChatHub>("/chathub");


app.Run();
