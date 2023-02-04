using BeanBag.Api;

var builder = WebApplication.CreateBuilder(args);

const string AllCorsPolicy = "All"; 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductStore>();
builder.Services.AddCors(options => options.AddPolicy(AllCorsPolicy, build =>
{
    build.AllowAnyOrigin();
    build.AllowAnyMethod();
    build.AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllCorsPolicy);

app.MapDefaultControllerRoute();
    
app.Run();