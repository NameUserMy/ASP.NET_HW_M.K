var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");
app.Run(async (context) =>
{
    
    context.Response.ContentType = "text/html; text/javaScript;  charset=UTF-8";
    await context.Response.SendFileAsync("wwwroot/index.html");
   

});
app.Run();
