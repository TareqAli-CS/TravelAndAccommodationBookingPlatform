
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TravelAndAccommodationBookingPlatform.Application.Dtos;
using TravelAndAccommodationBookingPlatform.Application.Profiles;
using TravelAndAccommodationBookingPlatform.Application.Services;
using TravelAndAccommodationBookingPlatform.Application.Services.Interfaces;
using TravelAndAccommodationBookingPlatform.Application.Validators;
using TravelAndAccommodationBookingPlatform.Data;
using TravelAndAccommodationBookingPlatform.Data.Repositories;
using TravelAndAccommodationBookingPlatform.Data.Repositories.Interfaces;

namespace TravelAndAccommodationBookingPlatform.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration; // Get configuration


            // **Database Context**
            builder.Services.AddDbContext<TravelAndAccommodationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers().AddFluentValidation();

            // **Swagger Configuration**
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelAndAccommodationBookingPlatform", Version = "v1" });

                var jwtSettings = builder.Configuration.GetSection("JwtSettings");
                var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // **Register Dependencies (Repositories)**
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IDealRepository, DealRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // **Register Dependencies (Services)**
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IDealService, DealService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordService, PasswordService>();

            // **AutoMapper Configuration**
            builder.Services.AddAutoMapper(typeof(CityProfile), typeof(HotelProfile),
                typeof(RoomProfile), typeof(BookingProfile), typeof(HotelImageProfile),
                typeof(ReviewProfile), typeof(RoomImageProfile), typeof(DealProfile));

            // **FluentValidation Configuration**
            builder.Services.AddTransient<IValidator<CityDto>, CityDtoValidator>()
                .AddTransient<IValidator<HotelDto>, HotelDtoValidator>()
                .AddTransient<IValidator<HotelFilterDto>, HotelFilterDtoValidator>()
                .AddTransient<IValidator<BookingDto>, BookingDtoValidator>()
                .AddTransient<IValidator<DealDto>, DealDtoValidator>()
                .AddTransient<IValidator<RoomDto>, RoomDtoValidator>()
                .AddTransient<IValidator<LoginRequestDto>, LoginRequestDtoValidator>()
                .AddTransient<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();


            // **JWT Authentication**
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            builder.Services.AddAuthorization();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:7270")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");
            app.MapControllers();

            app.Run();
        }
    }
}
