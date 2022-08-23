
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();


// enforce use of periods as decimal separator
var cultureInfo = new CultureInfo("en-US"); 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Home", action = "About" }
    );

app.MapControllerRoute(
    name: "about",
    pattern: "about",
    defaults: new { controller = "Home", action = "About" }
    );

app.MapControllerRoute(
    name: "contact",
    pattern: "contact",
    defaults: new { controller = "Home", action = "Contact" }
    );

app.MapControllerRoute(
    name: "projects",
    pattern: "projects",
    defaults: new { controller = "Home", action = "Projects" }
    );

app.MapControllerRoute(
    name: "fevercheck",
    pattern: "fevercheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" }
    );

app.MapControllerRoute(
    name: "guessinggame",
    pattern: "guessinggame",
    defaults: new { controller = "GuessNumber", action = "GuessNumber" }
    );

app.MapControllerRoute(
    name: "guessinggame/delete-cookies",
    pattern: "guessinggame/delete-cookies",
    defaults: new { controller = "GuessNumber", action = "DeleteCookies" }
    );

app.MapControllerRoute(
    name: "guessinggame/delete-session",
    pattern: "guessinggame/delete-session",
    defaults: new { controller = "GuessNumber", action = "DeleteSession" }
    );

app.MapControllerRoute(
    name: "people",
    pattern: "people",
    defaults: new { controller = "People", action = "Index" }
    );

app.Run();
