using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace OSI.OTT.WebAPI.Extensions;

public static class IdentityExtension
{
   public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddAuthentication(options =>
      {
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
         options.SaveToken = true;
         options.RequireHttpsMetadata = false;
         options.TokenValidationParameters = new TokenValidationParameters()
         {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))

         };
      });
   }

   public static void UseIdentityConfiguration(this IApplicationBuilder app, IConfiguration configuration)
   {
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API V1");
      });
   }

   public static void AddSwaggerGenConfiguration(this IServiceCollection services)
   {
      services.AddSwaggerGen(option =>
      {
         option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
         option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
         {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
         });
         option.AddSecurityRequirement(new OpenApiSecurityRequirement
             {
                 {
                     new OpenApiSecurityScheme
                     {
                         Reference=new OpenApiReference
                         {
                             Type=ReferenceType.SecurityScheme,
                             Id="Bearer"
                         },
                         Scheme = "Bearer",
                         Name = "Bearer",
                         In = ParameterLocation.Header,
                     }, new List<string>()
                 }
             });
      });
   }
}
