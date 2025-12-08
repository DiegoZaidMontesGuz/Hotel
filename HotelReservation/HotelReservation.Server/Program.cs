using Microsoft.Extensions.Hosting;
using HotelReservation.Server.BLL;
using HotelReservation.Server.Models;
using Microsoft.Data.SqlClient;
using HotelReservation.Server.Models;
using HotelReservation.Server.DAL;
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Allow our services/repositories to get connection string
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    // Register BLL + DAL services (we'll create these)
    builder.Services.AddScoped<IHotelService, HotelService>();
    builder.Services.AddScoped<IRoomService, RoomService>();
    builder.Services.AddScoped<IGuestService, GuestService>();
    builder.Services.AddScoped<IBookingService, BookingService>();

    builder.Services.AddScoped<IHotelRepository, HotelRepository>();
    builder.Services.AddScoped<IRoomRepository, RoomRepository>();
    builder.Services.AddScoped<IGuestRepository, GuestRepository>();
    builder.Services.AddScoped<IBookingRepository, BookingRepository>();

    // Existing stuff from template ...



    var app = builder.Build();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.MapFallbackToFile("/index.html");

    app.Run();
}
