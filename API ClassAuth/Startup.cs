using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace API_ClassAuth
{

    public class Startup
    {
        // ...

        // This secret key should be stored securely in production.
        private readonly string secretKey = "your-secret-key";

        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                    };
                });

            // ...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            // Use authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // ...
        }
    }

}
