using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(); //uses for dependency injection and configuration
    builder.Services.AddScoped<IBreakfastService, BreakfastService>(); //this is where we are telling the application to use the breakfast service
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error"); //this is where we are telling the application to use the error controller so we dont give the client sensitive information
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}

