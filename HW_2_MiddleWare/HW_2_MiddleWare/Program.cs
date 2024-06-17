
using HW_2_MiddleWare;
var builder = WebApplication.CreateBuilder(args);


//session include
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
/**/
var app = builder.Build();
app.UseSession();

//10000-100000
//1000-10000

app.Test();//100-1000
app.UseFromTwentyToHundred();//20-100
app.UseFromElevenToNineteen();//11-19
app.UseFromOneToTen();//1-9

app.Run();
